using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Tensee.Banch
{
    [DependsOn(typeof(BanchClientModule), typeof(AbpAutoMapperModule))]
    public class BanchXamarinSharedModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.IsEnabled = false;
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BanchXamarinSharedModule).GetAssembly());
        }
    }
}