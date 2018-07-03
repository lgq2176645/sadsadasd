using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Tensee.Web.Authentication.External
{
    public class WechatMiniProgramAuthModule : AbpModule
    {
        public override void PreInitialize()
        {

        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WechatMiniProgramAuthModule).GetAssembly());
        }

        public override void PostInitialize()
        {

        }
    }
}
