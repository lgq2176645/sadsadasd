using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Abp.AspNetCore.Mvc.Controllers;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Tensee.Banch.Web.Mvc.Controllers
{
    public class WxPayController : AbpController
    {
        private SortedDictionary<string, object> m_values = new SortedDictionary<string, object>();

        private readonly IRepository<Order> _order;
       


        public WxPayController(IRepository<Order> _order)
        {
            this._order = _order;
      
        }

        //public ActionResult Index()
        //{

        //    return View();
        //}

        public ActionResult Index()
        {

            try
            {
                var s = Request.Body;
             
                int count;
                var buffer = new byte[1024];
                var builder = new StringBuilder();
                while ((count = s.Read(buffer, 0, 1024)) > 0)
                {
                   
                    builder.Append(Encoding.UTF8.GetString(buffer, 0, count));

                }
                //s.Flush();
                //s.Dispose();

                
                //var notifyData = new WxPayData();
                //notifyData.FromXml(builder.ToString());
                FromXml(builder.ToString());
                //var issussess = notifyData.GetValue("result_code");
                //var msg = notifyData.GetValue("return_msg");
                var issussess = GetValue("result_code");
                var msg = GetValue("return_msg");

                if (issussess.ToString() == "SUCCESS")
                {
                    var orderId = GetValue("attach");
                    var obj = _order.Get(Convert.ToInt32(orderId.ToString()));
                    string t1 = builder.ToString();//写到txt的内容
                    string f1 = @"E:/88.txt";   //t.txt是文件名，可以带路径。
                    System.IO.StreamWriter sw1 = new System.IO.StreamWriter(f1);
                    sw1.Write(t1);
                    sw1.Close();
                    obj.Status = 1;
                    _order.Update(obj);
                }

                string str = string.Format(@"<xml><return_code><![CDATA[{0}]]></return_code><return_msg><![CDATA[{1}]]></return_msg></xml>", issussess, msg);
                string txt = str;//写到txt的内容
                string filename = @"E:/test.txt";   //t.txt是文件名，可以带路径。
                System.IO.StreamWriter sw = new System.IO.StreamWriter(filename);
                sw.Write(txt);
                sw.Close();
                return Content(str, "text/xml");
            }
            catch (Exception e)
            {
                string txt = e.ToString();//写到txt的内容
                string filename = @"E:/test.txt";   //t.txt是文件名，可以带路径。
                System.IO.StreamWriter sw = new System.IO.StreamWriter(filename);
                sw.Write(txt);
                sw.Close();
            }

            return View();
        }


        public SortedDictionary<string, object> FromXml(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                throw new Exception("将空的xml串转换为WxPayData不合法!");
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            XmlNode xmlNode = xmlDoc.FirstChild;//获取到根节点<xml>
            XmlNodeList nodes = xmlNode.ChildNodes;
            foreach (XmlNode xn in nodes)
            {
                XmlElement xe = (XmlElement)xn;
                m_values[xe.Name] = xe.InnerText;//获取xml的键值对到WxPayData内部的数据中
            }

            try
            {
                //2015-06-29 错误是没有签名
                if (m_values["return_code"].ToString() != "SUCCESS")
                {
                    return m_values;
                }
                //CheckSign();//验证签名,不通过会抛异常
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return m_values;
        }

        public object GetValue(string key)
        {
            m_values.TryGetValue(key, out object o);
            return o;
        }

    }
}