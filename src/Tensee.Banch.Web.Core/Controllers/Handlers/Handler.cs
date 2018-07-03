using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Tensee.Banch.Web.Controllers.Handlers
{
    /// <summary>
    /// Handler 的摘要说明
    /// </summary>
    public abstract class Handler
    {
        public Handler(HttpContext context)
        {
            this.Request = context.Request;
            this.Response = context.Response;
            this.Context = context;
        }

        public abstract ContentResult Process();

        protected ContentResult WriteJson(object response)
        {
            ContentResult result = new ContentResult
            {
                Content = JsonConvert.SerializeObject(response)
            };
            string jsonpCallback = Request.Query["callback"];
            if (String.IsNullOrWhiteSpace(jsonpCallback))
            {
                result.ContentType = "text/plain";
                //await Response.WriteAsync(json);
            }
            else
            {
                result.ContentType = "application/json";
                //await Response.WriteAsync(String.Format("{0}({1});", jsonpCallback, json));
            }
            return result;
        }

        public HttpRequest Request { get; private set; }
        public HttpResponse Response { get; private set; }
        public HttpContext Context { get; private set; }
    }
}
