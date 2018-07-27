using Abp.AspNetZeroCore.Web.Authentication.External;
using Abp.Runtime.Caching;
using Castle.Core.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Senparc.Weixin;
using Senparc.Weixin.HttpUtility;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Tensee.Web.Authentication.External
{
    public class WechatAuthProviderApi : ExternalAuthProviderApiBase
    {
        public const string Name = "Wechat";
        private readonly ICacheManager _cacheManager;
        private readonly IExternalAuthConfiguration _externalAuthConfiguration;
        WeChatMiniProgramOptions _options;
        readonly JSchema schema = JSchema.Parse(JsonConvert.SerializeObject(new UsersWechat()));
        private readonly ILogger logger;
        private const string getTokenUrl = @"https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={0}&corpsecret={1}";
        public WechatAuthProviderApi(ICacheManager cacheManager, IExternalAuthConfiguration externalAuthConfiguration, ILogger logger)
        {
            _cacheManager = cacheManager;
            _externalAuthConfiguration = externalAuthConfiguration;
            var r = externalAuthConfiguration.Providers.First(p => p.Name == Name);
            _options = new WeChatMiniProgramOptions
            {
                AppId = r.ClientId,
                Secret = r.ClientSecret
            };
            this.logger = logger;
        }
        public override async Task<ExternalAuthUserInfo> GetUserInfo(string accessCode)
        {
            UsersWechat wechat = new UsersWechat();
            var accessToken = await _cacheManager.GetCache("WechatAccessTokenCache").Get("AccessToken",
                async () => await GetToken(_options.AppId, _options.Secret));
            //logger.Debug("获取token:"+accessToken.access_token);
            if (accessToken != null && !string.IsNullOrWhiteSpace(accessToken.access_token))
            {
                var url = string.Format(Config.ApiWorkHost + "/cgi-bin/user/getuserinfo?access_token={0}&code={1}", accessToken.access_token, accessCode);
                var redata = Get.GetJson<GetUserResult>(url);
                if (!string.IsNullOrWhiteSpace(redata.user_ticket))
                {
                    UserTicket tiket = new UserTicket
                    {
                        user_ticket = redata.user_ticket
                    };
                    url = string.Format(Config.ApiWorkHost + "/cgi-bin/user/getuserdetail?access_token={0}", accessToken.access_token);
                    //   wechat = Post.GetResult<UsersWechat>(JsonConvert.SerializeObject(tiket));
                    wechat = await GetUserMsg(url, tiket);
                }
            }

            var t = wechat == null ? new ExternalAuthUserInfo() : new ExternalAuthUserInfo
            {
                EmailAddress = wechat.email,
                Surname = wechat.name,
                ProviderKey = wechat.userid,
                Provider = Name,
                Name = wechat.userid
            };
            return t;
        }



        private async Task<UsersWechat> GetUserMsg(string url, UserTicket tiket)
        {
            //序列化将要传输的对象
            string obj = JsonConvert.SerializeObject(tiket);
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var result = await client.PostAsync(url, new StringContent(obj));
                if (result.IsSuccessStatusCode)
                {
                    string re = await result.Content.ReadAsStringAsync();
                    var jo = JObject.Parse(re);
                    if (jo.IsValid(schema))
                    {
                        var m = JsonConvert.DeserializeObject<UsersWechat>(re);
                        return m;
                    }
                }
            }
            return null;
        }


        private async Task<AccessToken> GetToken(string AppId, string Secret)
        {
            if (string.IsNullOrWhiteSpace(AppId) || string.IsNullOrWhiteSpace(Secret))
            {
                return null;
            }
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var result = await client.GetAsync(string.Format(getTokenUrl, AppId, Secret));
                if (result.IsSuccessStatusCode)
                {
                    string retu = await result.Content.ReadAsStringAsync();
                    //logger.Debug($"appid:{AppId}  secret:{Secret}  token: {retu}");
                    return JsonConvert.DeserializeObject<AccessToken>(retu);
                }
            }
            return null;
        }

        public class UsersWechat
        {
            public string userid { get; set; }
            public string name { get; set; }

            public string mobile { get; set; }

            public string gender { get; set; }

            public string email { get; set; }

            public string avatar { get; set; }

            public string qr_code { get; set; }

        }

        public class GetUserResult
        {
            public string errcode { get; set; }
            public string errmsg { get; set; }
            public string CorpId { get; set; }
            public string UserId { get; set; }
            public string DeviceId { get; set; }

            public string user_ticket { get; set; }

            public string expires_in { get; set; }

        }

        public class UserTicket
        {
            public string user_ticket { get; set; }
        }

        public class AccessToken
        {
            /// <summary>
            /// 访问令牌
            /// </summary>
            public string access_token { get; set; }
            /// <summary>
            /// 过期时间 单位  s
            /// </summary>
            public int expires_in { get; set; }
            /// <summary>
            /// 创建时间
            /// </summary>
            public DateTime CreationTime { get; }
            public AccessToken()
            {
                CreationTime = DateTime.Now;
            }
        }

    }
}
