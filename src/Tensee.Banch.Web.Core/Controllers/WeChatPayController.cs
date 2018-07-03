using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Tensee.Banch.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class WeChatPayController : BanchControllerBase
    {
        
        public WeChatPayController()
        {
           
        }
        /// <summary>
        /// 聊天小程序微信支付回调  更新订单状态，生成消费记录，增加余额或者积分
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> NotifyChatOrderComplete()
        {
            var s = Request.Body;
            StringBuilder builder = new StringBuilder();
            byte[] buffer = new byte[1024];
            while ((await s.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                builder.Append(Encoding.UTF8.GetString(buffer));
            }
            
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(builder.ToString());
            string returnCode = xmlDoc.SelectSingleNode("//return_code").InnerText;
            string openid = xmlDoc.SelectSingleNode("//openid").InnerText;
            string msg = "", result_code ="", out_trade_no ="", transaction_id ="", time_end ="", err_code="", err_code_des="";        
            if (returnCode == "SUCCESS")
            {
                result_code = xmlDoc.SelectSingleNode("//result_code").InnerText;
                out_trade_no = xmlDoc.SelectSingleNode("//out_trade_no").InnerText;
               
                if (result_code == "SUCCESS")
                {
                    transaction_id = xmlDoc.SelectSingleNode("//transaction_id").InnerText;
                    time_end = xmlDoc.SelectSingleNode("//time_end").InnerText;
                  
                    XmlNode attach = xmlDoc.SelectSingleNode("//attach");
                    if (attach == null || string.IsNullOrEmpty(attach.InnerText))
                    {
                       
                        
                       
                    }
                    else
                    {
                    }
                }
                else
                {
                    err_code = xmlDoc.SelectSingleNode("//err_code").InnerText;
                    err_code_des = xmlDoc.SelectSingleNode("//err_code_des").InnerText;

                   
                }
            }
            else
            {
                msg = xmlDoc.SelectSingleNode("//return_msg").InnerText;
            }

            string str = string.Format($@"<xml><return_code><![CDATA[{returnCode}]]></return_code></xml>");
            return Content(str, "text/xml");
        }
    }
}
