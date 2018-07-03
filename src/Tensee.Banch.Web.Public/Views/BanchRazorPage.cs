using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace Tensee.Banch.Web.Public.Views
{
    public abstract class BanchRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected BanchRazorPage()
        {
            LocalizationSourceName = BanchConsts.LocalizationSourceName;
        }
    }
}
