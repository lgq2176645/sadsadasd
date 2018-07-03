using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tensee.Banch.Web.Controllers;

namespace Tensee.Banch.Web.Areas.AppAreaName.Controllers
{
    [Area("AppAreaName")]
    [AbpMvcAuthorize]
    public class WelcomeController : BanchControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}