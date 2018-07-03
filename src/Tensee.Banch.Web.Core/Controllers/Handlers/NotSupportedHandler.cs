using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Tensee.Banch.Web.Controllers.Handlers
{
    public class NotSupportedHandler : Handler
    {
        public NotSupportedHandler(HttpContext context)
            : base(context)
        {
        }

        public override ContentResult Process()
        {
           return WriteJson(new
            {
                state = "action 参数为空或者 action 不被支持。"
            });
        }
    }
}
