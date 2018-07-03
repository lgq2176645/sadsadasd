using Abp.Auditing;
using Microsoft.AspNetCore.Mvc;

namespace Tensee.Banch.Web.Controllers
{
    public class HomeController : BanchControllerBase
    {
        [DisableAuditing]
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}
