using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tensee.Banch.Web.Areas.AppAreaName.Models.Layout;
using Tensee.Banch.Web.Session;
using Tensee.Banch.Web.Views;

namespace Tensee.Banch.Web.Areas.AppAreaName.Views.Shared.Components.AppAreaNameFooter
{
    public class AppAreaNameFooterViewComponent : BanchViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppAreaNameFooterViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footerModel = new FooterViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(footerModel);
        }
    }
}
