using Microsoft.AspNetCore.Mvc;
using Tensee.Banch.Web.Controllers;

namespace Tensee.Banch.Web.Public.Controllers
{
    public class HomeController : BanchControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}