using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Tensee.Banch.Web.Controllers.Handlers
{
    public class ConfigHandler : Handler
    {
        public ConfigHandler(HttpContext context) : base(context) { }

        public override ContentResult  Process()
        {
            return WriteJson(Config.Items);
        }
    }
}
