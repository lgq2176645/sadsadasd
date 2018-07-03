using Microsoft.AspNetCore.Antiforgery;

namespace Tensee.Banch.Web.Controllers
{
    public class AntiForgeryController : BanchControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
