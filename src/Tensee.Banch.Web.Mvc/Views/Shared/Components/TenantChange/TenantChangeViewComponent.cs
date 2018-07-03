using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tensee.Banch.Web.Session;

namespace Tensee.Banch.Web.Views.Shared.Components.TenantChange
{
    public class TenantChangeViewComponent : BanchViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public TenantChangeViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loginInfo = await _sessionCache.GetCurrentLoginInformationsAsync();
            var model = ObjectMapper.Map<TenantChangeViewModel>(loginInfo);
            return View(model);
        }
    }
}
