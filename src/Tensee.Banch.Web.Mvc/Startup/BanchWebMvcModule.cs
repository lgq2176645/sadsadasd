using Abp.AspNetZeroCore;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Threading.BackgroundWorkers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Tensee.Banch.Configuration;
using Tensee.Banch.EntityFrameworkCore;
using Tensee.Banch.MultiTenancy;
using Tensee.Banch.Web.Areas.AppAreaName.Startup;

namespace Tensee.Banch.Web.Startup
{
    [DependsOn(
        typeof(BanchWebCoreModule)
    )]
    public class BanchWebMvcModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public BanchWebMvcModule(
            IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Modules.AbpWebCommon().MultiTenancy.DomainFormat = _appConfiguration["App:WebSiteRootAddress"] ?? "http://localhost:62114/";
            Configuration.Modules.AspNetZero().LicenseCode = _appConfiguration["AbpZeroLicenseCode"];
            Configuration.Navigation.Providers.Add<AppAreaNameNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BanchWebMvcModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!IocManager.Resolve<IMultiTenancyConfig>().IsEnabled)
            {
                return;
            }

            if (!DatabaseCheckHelper.Exist(_appConfiguration["ConnectionStrings:Default"]))
            {
                return;
            }

            var workManager = IocManager.Resolve<IBackgroundWorkerManager>();
            workManager.Add(IocManager.Resolve<SubscriptionExpirationCheckWorker>());
            workManager.Add(IocManager.Resolve<SubscriptionExpireEmailNotifierWorker>());
        }
    }
}