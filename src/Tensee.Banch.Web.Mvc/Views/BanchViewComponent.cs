using Abp.AspNetCore.Mvc.ViewComponents;

namespace Tensee.Banch.Web.Views
{
    public abstract class BanchViewComponent : AbpViewComponent
    {
        protected BanchViewComponent()
        {
            LocalizationSourceName = BanchConsts.LocalizationSourceName;
        }
    }
}