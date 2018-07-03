using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Tensee.Banch.Wechat;

namespace Tensee.Banch
{
    public class WxPayOrderData
    {
        public readonly Random random = new Random();
        private const string UnifiedPayUrl = "https://api.mch.weixin.qq.com/pay/unifiedorder";
        private const string RefundUrl = "https://api.mch.weixin.qq.com/secapi/pay/refund";
        /// <summary>
        /// 公共号ID(微信分配的公众账号 ID)
        /// </summary>
        public string appid { get; set; }
        /// <summary>
        /// 商户号(微信支付分配的商户号)
        /// </summary>
        public string mch_id { get; set; }
        /// <summary>
        /// 微信支付分配的终端设备号
        /// </summary>
        public string device_info { get; set; }
        /// <summary>
        /// 随机字符串，不长于 32 位(此处返回20位的小写随机字符串)
        /// </summary>
        public string nonce_str { get; }
        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }
        /// <summary>
        /// 商品描述
        /// </summary>
        public string body { get; set; }
        /// <summary>
        /// 附加数据，原样返回
        /// </summary>
        public string attach { get; set; }
        /// <summary>
        /// 商户系统内部的订单号,32个字符内、可包含字母,确保在商户系统唯一,详细说明
        /// </summary>
        public string out_trade_no { get; set; }
        /// <summary>
        /// 订单总金额，单位为分，不能带小数点
        /// </summary>
        public int total_fee { get; set; }
        /// <summary>
        /// 终端IP
        /// </summary>
        public string spbill_create_ip { get; set; }
        /// <summary>
        /// 订 单 生 成 时 间 ， 格 式 为yyyyMMddHHmmss，如 2009 年12 月 25 日 9 点 10 分 10 秒表示为 20091225091010。时区为 GMT+8 beijing。该时间取自商户服务器
        /// </summary>
        public string time_start { get; set; }
        /// <summary>
        /// 交易结束时间
        /// </summary>
        public string time_expire { get; set; }
        /// <summary>
        /// 商品标记 商品标记，该字段不能随便填，不使用请填空，使用说明详见第 5 节
        /// </summary>
        public string goods_tag { get; set; }
        /// <summary>
        /// 接收微信支付成功通知
        /// </summary>
        public string notify_url { get; set; }
        /// <summary>
        /// JSAPI、NATIVE、APP
        /// </summary>
        public string trade_type { get; set; }
        /// <summary>
        /// 用户标识 trade_type 为 JSAPI时，此参数必传
        /// </summary>
        public string openid { get; set; }
        /// <summary>
        /// 只在 trade_type 为 NATIVE时需要填写。
        /// </summary>
        public string product_id { get; set; }
        /// <summary>
        /// 订单生成时间戳
        /// </summary>
        public long timeStamp { get; private set; }
        /// <summary>
        /// 商户退款单号
        /// </summary>
        public string out_refund_no { get; set; }
        /// <summary>
        /// 退款金额
        /// </summary>
        public decimal? refund_fee { get; set; }
        /// <summary>
        /// 退款原因
        /// </summary>
        public string refund_desc { get; set; }
        public WxPayOrderData()
        {
            nonce_str = random.NextString(20, true);
            timeStamp = ((long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds);
        }
        /// <summary>
        /// 退款
        /// </summary>
        /// <param name="key">商户API key</param>
        /// <returns></returns>
        public async Task<bool> GetRefund(string key)
        {
            var dicProperties = ToDicHelper.GetPropertiesFromObj(this);
            dicProperties.Remove(nameof(timeStamp));
            //拼接成XML请求数据
            StringBuilder sbPay = new StringBuilder();
            foreach (KeyValuePair<string, string> k in dicProperties)
            {
                sbPay.Append($"<{ k.Key }><![CDATA[{ k.Value }]]></{ k.Key }>");
            }
            sbPay.Append($"<sign>{GetSign(dicProperties, key)}</sign>");
            string post_string = string.Format($"<xml>{sbPay.ToString()}</xml>");
            var handler = new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                SslProtocols = SslProtocols.Tls12
            };
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            foreach (var cert in store.Certificates)
            {
                if (cert.SubjectName.Name == "SN=100757442, CN=永德县迅捷家电维修部, OU=MMPay, O=Tencent, L=Shenzhen, S=Guangdong, C=CN")
                {
                    handler.ClientCertificates.Add(cert);
                }
            }
            using (HttpClient client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/xml"));
                var response = await client.PostAsync(RefundUrl, new StringContent(post_string, Encoding.UTF8));
                if (response.IsSuccessStatusCode)
                {
                    var res = GetInfoFromXml(await response.Content.ReadAsStringAsync());
                    if (res["return_code"] == "SUCCESS" )
                    {
                        if (res["result_code"] == "SUCCESS")
                        {
                            return true;
                        }
                        else
                        {
                            throw new Exception($"{res["err_code"]} : {res["err_code_des"]}");
                        }
                        //prepay_id = res["prepay_id"];
                    }
                    else
                    {
                        throw new Exception(res["return_msg"]);
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// 获取微信返回的预付单信息
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public async Task<WeChatPayReturnModel> GetWeChatPay(string key)
        {
            var dicProperties = ToDicHelper.GetPropertiesFromObj(this);
            dicProperties.Remove(nameof(timeStamp));
            //拼接成XML请求数据
            StringBuilder sbPay = new StringBuilder();
            //sbPay.Append(@"<?xml version=""1.0"" encoding=""utf - 8""?>");
            foreach (KeyValuePair<string, string> k in dicProperties)
            {
                //if (k.Key == "attach" || k.Key == "body" || k.Key == "sign")
                //{
                //    sbPay.Append($"<{ k.Key }><![CDATA[{ k.Value }]]></{ k.Key }>");
                //}
                //else
                //{
                //    sbPay.Append($"<{ k.Key }>{ k.Value }</{ k.Key }>");
                //}
                sbPay.Append($"<{ k.Key }><![CDATA[{ k.Value }]]></{ k.Key }>");
            }
            sbPay.Append($"<sign>{GetSign(dicProperties, key)}</sign>");
            string post_string = string.Format($"<xml>{sbPay.ToString()}</xml>");
            //发起请求,获取预付订单
            string prepay_id = "";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/xml"));
                var response = await client.PostAsync(UnifiedPayUrl, new StringContent(post_string, Encoding.UTF8));
                if (response.IsSuccessStatusCode)
                {
                    var res = GetInfoFromXml(await response.Content.ReadAsStringAsync());
                    if (res["return_code"] == "SUCCESS")
                    {
                        prepay_id = res["prepay_id"];
                    }
                    else
                    {
                        throw new Exception(res["return_msg"]);
                    }
                    
                }
            }

            WeChatPayReturnModel result = new WeChatPayReturnModel()
            {
                NonceStr = nonce_str,
                AppId = appid,
                Package = "prepay_id=" + prepay_id,
            };
            //timeStamp = int.Parse(result.TimeStamp);

            //计算签名
            SortedDictionary<string, string> paysign = new SortedDictionary<string, string>
            {
                { "appId", appid },
                { "nonceStr", result.NonceStr },
                { "package" , result.Package },
                { "signType", result.SignType },
                { "timeStamp", result.TimeStamp },
            };
            result.PaySign = GetSign(paysign, key);
            return result;
        }

        private string GetSign(SortedDictionary<string, string> dicProperties, string key)
        {
            string sign = string.Empty;
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, string> temp in dicProperties)
            {
                if (string.IsNullOrEmpty(temp.Key) || temp.Key.ToLower() == "sign")
                {
                    continue;
                }
                sb.Append($"{temp.Key.Trim()}={temp.Value.Trim()}&");
            }
            sb.Append($"key={key.Trim()}");
            string signkey = sb.ToString();
            //获取MD5
            var md5 = System.Security.Cryptography.MD5.Create();
            byte[] md5s = md5.ComputeHash(Encoding.UTF8.GetBytes(signkey));
            string retStr = BitConverter.ToString(md5s);
            retStr = retStr.Replace("-", "").ToUpper();
            return retStr;
        }

        protected SortedDictionary<string, string> GetInfoFromXml(string xmlstring)
        {
            SortedDictionary<string, string> sParams = new SortedDictionary<string, string>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlstring);
            XmlElement root = doc.DocumentElement;
            foreach (XmlNode node in root.ChildNodes)
            {
                if (!sParams.ContainsKey(node.Name))
                {
                    sParams.Add(node.Name.Trim(), node.InnerText.Trim());
                }
            }
            return sParams;
        }
    }
}
