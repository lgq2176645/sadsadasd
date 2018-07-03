using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Tensee.Banch
{
    public class WxPayData
    {
        public WxPayData()
        {

        }

        //采用排序的Dictionary的好处是方便对数据包进行签名，不用再签名之前再做一次排序
        private SortedDictionary<string, object> m_values = new SortedDictionary<string, object>();


        /// <summary>
        /// 设置某个字段的值
        /// </summary>
        /// <param name="key">字段名</param>
        /// <returns>字段值</returns>
        public void SetValue(string key, object value)
        {
            m_values[key] = value;
        }


        /// <summary>
        /// 根据字段名获取某个字段的值
        /// </summary>
        /// <param name="key">字段名</param>
        /// <returns>key对应的字段值</returns>
        public object GetValue(string key)
        {
            m_values.TryGetValue(key, out object o);
            return o;
        }


        /// <summary>
        /// 判断某个字段是否已设置
        /// </summary>
        /// <param name="key">字段名</param>
        /// <returns>若字段key已被设置，则返回true，否则返回false</returns>
        public bool IsSet(string key)
        {
            m_values.TryGetValue(key, out object o);
            if (null != o)
                return true;
            else
                return false;
        }


        /// <summary>
        /// 将Dictionary转成xml
        /// </summary>
        /// <returns>经转换得到的xml串</returns>
        public string ToXml()
        {
            //数据为空时不能转化为xml格式
            if (0 == m_values.Count)
            {
                throw new Exception("WxPayData数据为空!");
            }

            string xml = "<xml>";
            foreach (KeyValuePair<string, object> pair in m_values)
            {
                //字段值不能为null，会影响后续流程
                if (pair.Value == null)
                {
                    throw new Exception("WxPayData内部含有值为null的字段!");
                }

                if (pair.Value.GetType() == typeof(int))
                {
                    xml += "<" + pair.Key + ">" + pair.Value + "</" + pair.Key + ">";
                }
                else if (pair.Value.GetType() == typeof(string))
                {
                    xml += "<" + pair.Key + ">" + "<![CDATA[" + pair.Value + "]]></" + pair.Key + ">";
                }
                else//除了string和int类型不能含有其他数据类型
                {

                    throw new Exception("WxPayData字段数据类型错误!");
                }
            }
            xml += "</xml>";
            return xml;
        }

        /// <summary>
        /// 将xml转为WxPayData对象并返回对象内部的数据
        /// </summary>
        /// <param name="xml">待转换的xml串</param>
        /// <returns>经转换得到的Dictionary</returns>
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


        /// <summary>
        /// Dictionary格式转化成url参数格式
        /// </summary>
        /// <returns>url格式串, 该串不包含sign字段值</returns>
        public string ToUrl()
        {
            string buff = "";
            foreach (KeyValuePair<string, object> pair in m_values)
            {
                if (pair.Value == null)
                {
                    throw new Exception("WxPayData内部含有值为null的字段!");
                }

                if (pair.Key != "sign" && pair.Value.ToString() != "")
                {
                    buff += pair.Key + "=" + pair.Value + "&";
                }
            }
            buff = buff.Trim('&');
            return buff;
        }


        /// <summary>
        /// Dictionary格式化成Json
        /// </summary>
        /// <returns>json串数据</returns>
        public string ToJson()
        {
            string jsonStr = JsonConvert.SerializeObject(m_values);
            return jsonStr;
        }

        /// <summary>
        /// values格式化成能在Web页面上显示的结果（因为web页面上不能直接输出xml格式的字符串）
        /// </summary>
        /// <returns></returns>
        public string ToPrintStr()
        {
            string str = "";
            foreach (KeyValuePair<string, object> pair in m_values)
            {
                if (pair.Value == null)
                {

                    throw new Exception("WxPayData内部含有值为null的字段!");
                }

                str += string.Format("{0}={1}<br>", pair.Key, pair.Value.ToString());
            }

            return str;
        }

        /**
        * @生成签名，详见签名生成算法
        * @return 签名, sign字段不参加签名
        */
        //public string MakeSign()
        //{
        //    //转url格式
        //    string str = ToUrl();
        //    //在string后加入API KEY
        //    str += "&key=" + WxPayConfig.KEY;
        //    //MD5加密
        //    var md5 = MD5.Create();
        //    var bs = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
        //    var sb = new StringBuilder();
        //    foreach (byte b in bs)
        //    {
        //        sb.Append(b.ToString("x2"));
        //    }
        //    //所有字符转为大写
        //    return sb.ToString().ToUpper();
        //}

        /**
        * 
        * 检测签名是否正确
        * 正确返回true，错误抛异常
        */
        //public bool CheckSign()
        //{
        //    //如果没有设置签名，则跳过检测
        //    if (!IsSet("sign"))
        //    {

        //        throw new Exception("WxPayData签名存在但不合法!");
        //    }
        //    //如果设置了签名但是签名为空，则抛异常
        //    else if (GetValue("sign") == null || GetValue("sign").ToString() == "")
        //    {

        //        throw new Exception("WxPayData签名存在但不合法!");
        //    }

        //    //获取接收到的签名
        //    string return_sign = GetValue("sign").ToString();

        //    //在本地计算新的签名
        //    string cal_sign = MakeSign();

        //    if (cal_sign == return_sign)
        //    {
        //        return true;
        //    }


        //    throw new Exception("WxPayData签名验证错误!");
        //}


        /// <summary>
        ///获取Dictionary
        /// </summary>
        /// <returns></returns>
        public SortedDictionary<string, object> GetValues()
        {
            return m_values;
        }
    }
}
