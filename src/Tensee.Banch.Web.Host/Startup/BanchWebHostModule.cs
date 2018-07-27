using Abp.AspNetCore.SignalR;
using Abp.AspNetZeroCore;
using Abp.AspNetZeroCore.Web.Authentication.External;
using Abp.AspNetZeroCore.Web.Authentication.External.Facebook;
using Abp.AspNetZeroCore.Web.Authentication.External.Google;
using Abp.AspNetZeroCore.Web.Authentication.External.Microsoft;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Runtime.Caching.Redis;
using Abp.Threading.BackgroundWorkers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Tensee.Banch.Configuration;
using Tensee.Banch.EntityFrameworkCore;
using Tensee.Banch.MultiTenancy;
using Tensee.Web.Authentication.External;

namespace Tensee.Banch.Web.Startup
{
    [DependsOn(
        typeof(WechatMiniProgramAuthModule),
        typeof(BanchWebCoreModule),
        typeof(AbpAspNetCoreSignalRModule)
    )]
    public class BanchWebHostModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;


        public BanchWebHostModule(
            IHostingEnvironment env
          
            )
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
          //  _wechat = wechat;
        }

        public override void PreInitialize()
        {
            Configuration.Modules.AbpWebCommon().MultiTenancy.DomainFormat = _appConfiguration["App:ServerRootAddress"] ?? "http://localhost:22742/";
            Configuration.Modules.AspNetZero().LicenseCode = _appConfiguration["AbpZeroLicenseCode"];
            Configuration.Caching.UseRedis();
            Configuration.Caching.ConfigureAll(cache => cache.DefaultSlidingExpireTime = System.TimeSpan.FromMinutes(2));
            Configuration.Caching.Configure("WechatAccessTokenCache", cache => cache.DefaultSlidingExpireTime = System.TimeSpan.FromHours(2));
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BanchWebHostModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!DatabaseCheckHelper.Exist(_appConfiguration["ConnectionStrings:Default"]))
            {
                return;
            }

            if (IocManager.Resolve<IMultiTenancyConfig>().IsEnabled)
            {
                var workManager = IocManager.Resolve<IBackgroundWorkerManager>();
                workManager.Add(IocManager.Resolve<SubscriptionExpirationCheckWorker>());
                workManager.Add(IocManager.Resolve<SubscriptionExpireEmailNotifierWorker>());
            }
          //  _wechat.StartGetCheckAll();
            ConfigureExternalAuthProviders();
        }

        private void ConfigureExternalAuthProviders()
        {
            var externalAuthConfiguration = IocManager.Resolve<ExternalAuthConfiguration>();

            if (bool.Parse(_appConfiguration["Authentication:Facebook:IsEnabled"]))
            {
                externalAuthConfiguration.Providers.Add(
                    new ExternalLoginProviderInfo(
                        FacebookAuthProviderApi.Name,
                        _appConfiguration["Authentication:Facebook:AppId"],
                        _appConfiguration["Authentication:Facebook:AppSecret"],
                        typeof(FacebookAuthProviderApi)
                    )
                );
            }

            if (bool.Parse(_appConfiguration["Authentication:Google:IsEnabled"]))
            {
                externalAuthConfiguration.Providers.Add(
                    new ExternalLoginProviderInfo(
                        GoogleAuthProviderApi.Name,
                        _appConfiguration["Authentication:Google:ClientId"],
                        _appConfiguration["Authentication:Google:ClientSecret"],
                        typeof(GoogleAuthProviderApi)
                    )
                );
            }

            //not implemented yet. Will be implemented with https://github.com/aspnetzero/aspnet-zero-angular/issues/5
            if (bool.Parse(_appConfiguration["Authentication:Microsoft:IsEnabled"]))
            {
                externalAuthConfiguration.Providers.Add(
                    new ExternalLoginProviderInfo(
                        MicrosoftAuthProviderApi.Name,
                        _appConfiguration["Authentication:Microsoft:ConsumerKey"],
                        _appConfiguration["Authentication:Microsoft:ConsumerSecret"],
                        typeof(MicrosoftAuthProviderApi)
                    )
                );
            }

            if (bool.Parse(_appConfiguration["Authentication:Wechat:IsEnabled"]))
            {
                externalAuthConfiguration.Providers.Add(
                    new ExternalLoginProviderInfo(
                        WechatAuthProviderApi.Name,
                        _appConfiguration["Authentication:Wechat:AppId"],
                        _appConfiguration["Authentication:Wechat:Secret"],
                        typeof(WechatAuthProviderApi)
                    )
                );
            }

            if (bool.Parse(_appConfiguration["Authentication:WechatMiniProgram:IsEnabled"]))
            {
                externalAuthConfiguration.Providers.Add(
                    new ExternalLoginProviderInfo(
                        WechatMiniProgramAuthProviderApi.ProviderName,
                        _appConfiguration["Authentication:WechatMiniProgram:AppId"],
                        _appConfiguration["Authentication:WechatMiniProgram:Secret"],
                        typeof(WechatMiniProgramAuthProviderApi)
                    )
                );
            }

            if (bool.Parse(_appConfiguration["Authentication:DingTalk:IsEnabled"]))
            {
                externalAuthConfiguration.Providers.Add(
                    new ExternalLoginProviderInfo(
                        DingTalkAuthProviderApi.Name,
                        _appConfiguration["Authentication:DingTalk:CorpId"],
                        _appConfiguration["Authentication:DingTalk:CorpSecret"],
                        typeof(DingTalkAuthProviderApi)
                    )
                );
            }


        }
    }
}
