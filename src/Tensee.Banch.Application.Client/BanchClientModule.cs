using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Tensee.Banch
{
    public class BanchClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BanchClientModule).GetAssembly());
        }
    }
}
