using Abp.AspNetZeroCore.Web.Authentication.External;
using Abp.Runtime.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json;
using Abp.UI;
using Abp;

namespace Tensee.Web.Authentication.External
{
    public class DingTalkAuthProviderApi : ExternalAuthProviderApiBase
    {

        public const string Name = "DingTalk";

        private readonly ICacheManager _cacheManager;
        private readonly IExternalAuthConfiguration _externalAuthConfiguration;
        JSchema schema = JSchema.Parse(JsonConvert.SerializeObject(new DingTalkTokenModel()));
        DingTalkConfig _options;
        public DingTalkAuthProviderApi(ICacheManager cacheManager,
            IExternalAuthConfiguration externalAuthConfiguration)
        {
            _cacheManager = cacheManager;
            _externalAuthConfiguration = externalAuthConfiguration;
            var r = externalAuthConfiguration.Providers.First(p => p.Name == Name);
            _options = new DingTalkConfig
            {
                CorpId = r.ClientId,
                CorpSecret = r.ClientSecret
            };
        }

        public override async Task<ExternalAuthUserInfo> GetUserInfo(string accessCode)
        {
            //获取code
            string accessToken =  _cacheManager.GetCache("CacheName").Get("DingTalkLogin", () => GetToken(_options.CorpId, _options.CorpSecret).Result);

            if (string.IsNullOrWhiteSpace(accessToken))
            {
                return new ExternalAuthUserInfo();
            }
            //获取用户ID
            string userid = await GetUserIdByCode(accessCode, accessToken);
            if (string.IsNullOrWhiteSpace(userid))
            {
                return new ExternalAuthUserInfo();
            }
            //获取用户信息
            var result = GetUserMsgByUserId(accessToken, userid);

            return result.Result;
        }


        /// <summary>
        /// 根据用户ID获取用户详细信息
        /// </summary>
        /// <param name="AccessToken"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        private async Task<ExternalAuthUserInfo> GetUserMsgByUserId(string AccessToken,string UserId)
        {

            string url = string.Format("https://oapi.dingtalk.com/user/get?access_token={0}&userid={1}", AccessToken, UserId);
            UserMeeage model = new UserMeeage();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var result = await client.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                string re = await result.Content.ReadAsStringAsync();
                var jo = JObject.Parse(re);
                if (jo.IsValid(schema))
                {
                    model = JsonConvert.DeserializeObject<UserMeeage>(re);

                }
            }


            return new ExternalAuthUserInfo
            {
                EmailAddress = model.email,
                Surname = model.name,
                ProviderKey = model.userid,
                Provider = Name,
                Name = model.userid
            };


            //string url = string.Format("https://oapi.dingtalk.com/user/get?access_token={0}&userid={1}", AccessToken, UserId);
            //UserMeeage model = new UserMeeage();
            //HttpClient client = new HttpClient();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var result = await client.GetAsync(url);
            //if (result.IsSuccessStatusCode)
            //{
            //    string re = await result.Content.ReadAsStringAsync();
            //    var jo = JObject.Parse(re);
            //    if (jo.IsValid(schema))
            //    {
            //        model = JsonConvert.DeserializeObject<UserMeeage>(re);

            //    }
            //}


            //return new ExternalAuthUserInfo
            //{
            //    ProviderKey = model.userid,
            //    Name = model.name,
            //    EmailAddress = model.mobile + "@tensee.com",
            //    Surname=model.name,
            //    Provider = "DingTalk"
            //};
        }

        /// <summary>
        /// 根据code获取用户ID
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="AccessToken"></param>
        /// <returns></returns>
        private async  Task<string> GetUserIdByCode(string Code ,string AccessToken)
        {
            string url = string.Format("https://oapi.dingtalk.com/user/getuserinfo?access_token={0}&code={1}", AccessToken, Code);
            GetUserIdModel model = new GetUserIdModel();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var result = await client.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                string re = await result.Content.ReadAsStringAsync();
                var jo = JObject.Parse(re);
                if (jo.IsValid(schema))
                {
                    var m = JsonConvert.DeserializeObject<GetUserIdModel>(re);
                    model.userid = m.userid;
                }
            }

            return model.userid;
        }


        /// <summary>
        /// 获取token
        /// </summary>
        /// <param name="CorpId"></param>
        /// <param name="CorpSecret"></param>
        /// <returns></returns>
        private async Task<string> GetToken(string CorpId,string CorpSecret)
        {
            string tokenUrl = string.Format("https://oapi.dingtalk.com/gettoken?corpid={0}&corpsecret={1}", CorpId, CorpSecret);
            DingTalkTokenModel model = new DingTalkTokenModel();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var result = await client.GetAsync(tokenUrl);
            if (result.IsSuccessStatusCode)
            {
                string re = await result.Content.ReadAsStringAsync();
                var jo = JObject.Parse(re);
                if (jo.IsValid(schema))
                {
                    var m = JsonConvert.DeserializeObject<DingTalkTokenModel>(re);
                    model.access_token = m.access_token;
                }
            }
            return model.access_token;
        }
    }

    public class DingTalkConfig
    {
        public string CorpId { get; set; }
        public string CorpSecret { get; set; }

    }


    public class GetUserIdModel
    {
        public int errcode { get; set; }
        public string errmsg { get; set; }

        public string userid { get; set; }

        public string deviceId { get; set; }

        public string is_sys { get; set; }

        public string sys_level { get; set; }
    }


    public  class UserMeeage
    {
        public string userid { get; set; }
        public string name { get; set; }
        public string mobile { get; set; }

        public string email { get; set; }
    }


}
