using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Tensee.Banch
{
    [DependsOn(typeof(BanchXamarinSharedModule))]
    public class BanchXamarinAndroidModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BanchXamarinAndroidModule).GetAssembly());
        }
    }
}