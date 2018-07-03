using System;
using System.Text;

namespace Tensee.Banch.Dto
{
    /// <summary>
    /// 微信验证签名请求
    /// </summary>
    public class WxCheckSignatureDto
    {
        /// <summary>
        /// 微信加密签名 
        /// </summary>
        public string signature { get; set; }
        /// <summary>
        /// 时间戳 
        /// </summary>
        public string timestamp { get; set; }
        /// <summary>
        /// 随机数
        /// </summary>
        public string nonce { get; set; }
        /// <summary>
        /// 随机字符串
        /// </summary>
        public string echostr { get; set; }

        public  string GetSHA1(string token)
        {
            //if (string.IsNullOrEmpty(timestamp))
            //    throw new ArgumentNullException(nameof(timestamp));
            //if (string.IsNullOrEmpty(nonce))
            //    throw new ArgumentNullException(nameof(nonce));

            string[] ArrTmp = { token, timestamp, nonce };
            Array.Sort(ArrTmp);
            string tmpStr = string.Join("", ArrTmp);

            var sha1 = System.Security.Cryptography.SHA1.Create();
            byte[] re = sha1.ComputeHash(Encoding.UTF8.GetBytes(tmpStr));
            StringBuilder sbuilder = new StringBuilder();
            foreach (var by in re)
            {
                sbuilder.Append(by.ToString("X2"));
            }
            return sbuilder.ToString();
        }


    }
}
