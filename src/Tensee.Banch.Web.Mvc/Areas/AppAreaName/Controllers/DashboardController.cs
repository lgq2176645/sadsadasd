using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tensee.Banch.Authorization;
using Tensee.Banch.Web.Controllers;

namespace Tensee.Banch.Web.Areas.AppAreaName.Controllers
{
    [Area("AppAreaName")]
    [AbpMvcAuthorize(AppPermissions.Pages_Tenant_Dashboard)]
    public class DashboardController : BanchControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}