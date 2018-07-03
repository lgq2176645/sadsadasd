using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tensee.Banch.Authorization;
using Tensee.Banch.Web.Areas.AppAreaName.Models.HostDashboard;
using Tensee.Banch.Web.Controllers;

namespace Tensee.Banch.Web.Areas.AppAreaName.Controllers
{
    [Area("AppAreaName")]
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Host_Dashboard)]
    public class HostDashboardController : BanchControllerBase
    {
        private const int DashboardOnLoadReportDayCount = 7;

        public ActionResult Index()
        {
            return View(new HostDashboardViewModel(DashboardOnLoadReportDayCount));
        }
    }
}