using Abp.Dependency;
using Castle.Core.Logging;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Globalization;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Tensee.Banch.Configuration;
using Microsoft.AspNetCore.Hosting;

namespace Tensee.Banch.Identity
{
    public class AliyunSmsSender : ISmsSender, ITransientDependency
    {
        public ILogger Logger { get; set; }
        string appkey ;
        string secret;
        string serverUrl = "dysmsapi.aliyuncs.com";
        string signName;
        string TemplateCode;
        string KnockSuccessTemplateCode;
        private Dictionary<string, string> smsDict = new Dictionary<string, string>
        {
            { "RegionId", "cn-hangzhou" },
            { "Action", "SendSms" },
            { "Version", "2017-05-25" },
        };
        private readonly IConfigurationRoot configuration;

        public AliyunSmsSender(ILogger Logger, IHostingEnvironment env)
        {
            configuration = env.GetAppConfiguration();
            //Logger.Info(configuration["SmsConfiguration:AliSms:SignName"]);
            appkey = configuration["SmsConfiguration:AliSms:appkey"];
            secret = configuration["SmsConfiguration:AliSms:secret"];
            signName = configuration["SmsConfiguration:AliSms:SignName"];
            TemplateCode = configuration["SmsConfiguration:AliSms:TemplateCode"];
            KnockSuccessTemplateCode= configuration["SmsConfiguration:AliSms:KnockSuccessTemplateCode"];

            smsDict.Add("SignName", signName);//签名
            smsDict.Add("TemplateCode", TemplateCode);//模板
            smsDict.Add("TemplateParam", "");//参数内容
            smsDict.Add("PhoneNumbers", "");//发送到的手机号
            
        }
        public Task SendAsync(string number, string message)
        {
            return Task.Run(() => Send(number, message));
        }

        private string Send(string number, string message)
        {
            try
            {
                smsDict["PhoneNumbers"] = number;
                smsDict["TemplateParam"] = JsonConvert.SerializeObject(new { code = message });
                var signatiure = new SignatureHelper(); Logger.Debug("Sign:" + signName); 
                string res = signatiure.Request(appkey, secret, serverUrl, smsDict, logger:Logger);
                Logger.Info("验证短信发送返回：" + res);
                return res;
            }
            catch(Exception e)
            {
                Logger.Error(e.Message);
                throw;
            }
        }

        





        /// <summary>
        /// 签名助手
        /// https://help.aliyun.com/document_detail/30079.html?spm=5176.7739992.2.3.HM7WTG
        /// 
        /// </summary>
        public class SignatureHelper
        {
            private const string ISO8601_DATE_FORMAT = "yyyy-MM-dd'T'HH:mm:ss'Z'";
            private const string ENCODING_UTF8 = "UTF-8";
            public static string PercentEncode(String value)
            {
                StringBuilder stringBuilder = new StringBuilder();
                string text = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";
                byte[] bytes = Encoding.GetEncoding(ENCODING_UTF8).GetBytes(value);
                foreach (char c in bytes)
                {
                    if (text.IndexOf(c) >= 0)
                    {
                        stringBuilder.Append(c);
                    }
                    else
                    {
                        stringBuilder.Append("%").Append(
                            string.Format(CultureInfo.InvariantCulture, "{0:X2}", (int)c));
                    }
                }
                return stringBuilder.ToString();
            }
            public static string FormatIso8601Date(DateTime date)
            {
                return date.ToUniversalTime().ToString(ISO8601_DATE_FORMAT, CultureInfo.CreateSpecificCulture("en-US"));
            }

            private static IDictionary<string, string> SortDictionary(Dictionary<string, string> dic)
            {
                IDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>(dic, StringComparer.Ordinal);
                return sortedDictionary;
            }

            public static string SignString(string source, string accessSecret)
            {
                using (var algorithm = new HMACSHA1())
                {
                    algorithm.Key = Encoding.UTF8.GetBytes(accessSecret.ToCharArray());
                    return Convert.ToBase64String(algorithm.ComputeHash(Encoding.UTF8.GetBytes(source.ToCharArray())));
                }
            }


            public async Task<string> HttpGet(string url, ILogger logger)
            {
                string responseBody = string.Empty;
                using (var http = new HttpClient())
                {
                    try
                    {
                        http.DefaultRequestHeaders.Add("x-sdk-client", "Net/2.0.0");
                        logger.Debug("url:" + url);
                        var response = await http.GetAsync(url);
                        response.EnsureSuccessStatusCode();
                        responseBody = await response.Content.ReadAsStringAsync();
                    }
                    catch (HttpRequestException e)
                    {
                        Console.WriteLine("\nException !");
                        Console.WriteLine("Message :{0} ", e.Message);
                        throw;
                    }
                }
                return responseBody;

            }

            public string Request(string accessKeyId, string accessKeySecret, string domain, Dictionary<string, string> paramsDict, ILogger logger, bool security = false)
            {

                string result = string.Empty;
                var apiParams = new Dictionary<string, string>
                {
                    { "SignatureMethod", "HMAC-SHA1" },
                    { "SignatureNonce", Guid.NewGuid().ToString() },
                    { "SignatureVersion", "1.0" },
                    { "AccessKeyId", accessKeyId },
                    { "Timestamp", FormatIso8601Date(DateTime.Now) },
                    { "Format", "JSON" },
                };

                foreach (var param in paramsDict)
                {
                    if (!apiParams.ContainsKey(param.Key))
                    {
                        apiParams.Add(param.Key, param.Value);
                    }
                }
                var sortedDictionary = SortDictionary(apiParams);
                string sortedQueryStringTmp = "";
                foreach (var param in sortedDictionary)
                {
                    sortedQueryStringTmp += "&" + PercentEncode(param.Key) + "=" + PercentEncode(param.Value);
                }

                string stringToSign = "GET&%2F&" + PercentEncode(sortedQueryStringTmp.Substring(1));
                string sign = SignString(stringToSign, accessKeySecret + "&");
                string signature = PercentEncode(sign);
                string url = (security ? "https" : "http") + $"://{domain}/?Signature={signature}{sortedQueryStringTmp}";
                try
                {
                    result = HttpGet(url, logger).Result;
                }
                catch (Exception)
                {

                    throw;
                }        
                return result;

            }
        }
    }
}







