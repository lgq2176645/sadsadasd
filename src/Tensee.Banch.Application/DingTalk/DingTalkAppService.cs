using Abp.Runtime.Caching;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Tensee.Banch.DingTalk.Dto;

namespace Tensee.Banch.DingTalk
{
   public  class DingTalkAppService: BanchAppServiceBase, IDingTalkAppService
    {
        private readonly ICacheManager _cacheManager;
        JSchema schema = JSchema.Parse(JsonConvert.SerializeObject(new DingTalkTokenModel()));
        // private readonly IExternalAuthConfiguration _externalAuthConfiguration;
        public DingTalkAppService(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }

        public async Task SendImageText(DingTalkSenderInfo input)
        {

            //string filePath = Directory.GetCurrentDirectory() + "/appsettings.json";
            //FileInfo config = new FileInfo(filePath);

            //Dictionary<string, string> dto = new Dictionary<string, string>();
            //StreamReader sr = new StreamReader(filePath, Encoding.Default);
            //JObject config_object = JObject.Parse(sr.ReadToEnd());
            //sr.Close();
            //foreach (JProperty prop in config_object["DingTalk"])
            //{
            //    dto.Add(prop.Name, prop.Value.ToString());
            //}
            //var AppId = dto.Where(r => r.Key == "CorpId").FirstOrDefault().Value;
            //var Secret = dto.Where(r => r.Key == "CorpSecret").FirstOrDefault().Value;

            //string accessToken = _cacheManager.GetCache("CacheName").Get("DingTalkSender", () => GetToken(AppId.Trim(), Secret.Trim()).Result);
            string accessToken = _cacheManager.GetCache("CacheName").Get("DingTalkSender", () => GetToken("dinga1b70f98f0f7a7eb35c2f4657eb6378f", "YcXEn3AilPm0H35gaoyl_u9UaOAQCMDNHjp3Or6Z8q6MK7dOvmaUTqyU1ROGnuq8").Result);
            string url = string.Format("https://oapi.dingtalk.com/message/send?access_token={0}", accessToken);

            string obj = JsonConvert.SerializeObject(input);
            HttpContent content = new StringContent(obj);

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await client.PostAsync(url, content);
            if (result.IsSuccessStatusCode)
            {
                string re = await result.Content.ReadAsStringAsync();
                var jo = JObject.Parse(re);
                if (jo.IsValid(schema))
                {
                    //var m = JsonConvert.DeserializeObject<DingTalkSenderResult>(re);
                    //return m;
                }
            }
        }


        /// <summary>
        /// 获取token
        /// </summary>
        /// <param name="CorpId"></param>
        /// <param name="CorpSecret"></param>
        /// <returns></returns>
        private async Task<string> GetToken(string CorpId, string CorpSecret)
        {
            string tokenUrl = string.Format("https://oapi.dingtalk.com/gettoken?corpid={0}&corpsecret={1}", CorpId, CorpSecret);
            DingTalkTokenModel model = new DingTalkTokenModel();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var result = await client.GetAsync(tokenUrl);
            if (result.IsSuccessStatusCode)
            {
                string re = await result.Content.ReadAsStringAsync();
                var jo = Newtonsoft.Json.Linq.JObject.Parse(re);
                if (jo.IsValid(schema))
                {
                    var m = JsonConvert.DeserializeObject<DingTalkTokenModel>(re);
                    model.access_token = m.access_token;
                }
            }
            return model.access_token;
        }

    }
}
