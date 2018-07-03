using System;
namespace Tensee.Banch.Wechat
{
    public class WeChatPayReturnModel
    {
        /// <summary>
        /// 统一下单接口返回的 prepay_id 参数值，提交格式如：prepay_id=*
        /// </summary>
        public string Package { get; set; }
        /// <summary>
        /// 小程序ID
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 随机字符串，长度为32个字符以下。
        /// </summary>
        public string NonceStr { get; set; }
        /// <summary>
        /// 时间戳 从1970年1月1日00:00:00至今的秒数,即当前的时间
        /// </summary>
        public string TimeStamp { get;private set; }
        /// <summary>
        /// 签名方式 默认为MD5，支持HMAC-SHA256和MD5。注意此处需与统一下单的签名类型一致
        /// </summary>
        public string SignType { get; set; }
        /// <summary>
        /// 签名 
        /// </summary>
        public string PaySign { get; set; }

        public WeChatPayReturnModel()
        {
            TimeStamp = ((long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds).ToString();
            SignType = "MD5";
        }
    }
}
