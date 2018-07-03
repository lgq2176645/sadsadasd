using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Abp.AspNetZeroCore.Web.Authentication.External;
using Castle.Core.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace Tensee.Web.Authentication.External
{
    public class WechatMiniProgramAuthProviderApi : ExternalAuthProviderApiBase
    {
        /// <summary>
        /// 微信小程序
        /// </summary>
        public const string ProviderName = "WeChatMiniProgram";
        WeChatMiniProgramOptions _options;
        JSchema schema = JSchema.Parse(JsonConvert.SerializeObject(new WeChatSession()));
        JSchema accessSchema = JSchema.Parse(JsonConvert.SerializeObject(new { AccessCode="", Name="" }));
        const string url = "https://api.weixin.qq.com/sns/jscode2session?appid={0}&secret={1}&grant_type=authorization_code&js_code={2}";
        private readonly IExternalAuthConfiguration _externalAuthConfiguration;
        private readonly ILogger logger;
        public WechatMiniProgramAuthProviderApi(IExternalAuthConfiguration externalAuthConfiguration, ILogger logger)
        {
            _externalAuthConfiguration = externalAuthConfiguration;
            var r = externalAuthConfiguration.Providers.First(p => p.Name == ProviderName);
            _options = new WeChatMiniProgramOptions
            {
                AppId = r.ClientId,
                Secret = r.ClientSecret
            };

            this.logger = logger;
        }

        public async override Task<ExternalAuthUserInfo> GetUserInfo(string accessCode)
        {
            JObject jObject = JObject.Parse(accessCode);
            if (!jObject.IsValid(accessSchema))
            {
                throw new Abp.UI.UserFriendlyException("accessCode Json inVaild");
            }
            accessCode = jObject["AccessCode"].ToString();
            string name = jObject["Name"].ToString();
            //string rowData = jObject["RowData"].ToString();
            var result = await GetOpenId(accessCode);
            //logger.Info("OpenId:" + result.Openid);
            var t = result == null ? new ExternalAuthUserInfo() : new ExternalAuthUserInfo
            {
                EmailAddress = result.Openid + "@tensee.cn",
                Surname = name,
                ProviderKey = result.Openid,
                Provider = ProviderName,
                Name = name
            };
            return t;
            
        }

        private async Task<WeChatSession>  GetOpenId(string code)
        {
            //string appId = "wx46d0cb729a1e39bc";
            //string Secret = "314d78c5bd46072381d716d4732a34b7";
            //string Code = "013y6h6H1rP9P603Dg6H1xso6H1y6h6c";
            string geturl = string.Format(url, _options.AppId, _options.Secret, code);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var result = await client.GetAsync(geturl);
            if (result.IsSuccessStatusCode)
            {                           //{"errcode":40163,"errmsg":"code been used, hints: [ req_id: tWZH6a0160th19 ]"}
                string re = await result.Content.ReadAsStringAsync();//{"session_key":"eafmjK9FYzCVpqPSo\/FBsQ==","openid":"oUigJ47QGkNOOXUjHkii5LyJbukw"}
                var jo = JObject.Parse(re);
                if (jo.IsValid(schema))
                {
                    var m = JsonConvert.DeserializeObject<WeChatSession>(re);
                    return m;
                }
            }
            return null ;
        }
    }

    class WeChatSession
    {
        public string Openid { get; set; }
        public string Session_key { get; set; }
    }
}
