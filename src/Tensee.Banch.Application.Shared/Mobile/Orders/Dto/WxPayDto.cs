using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.Mobile.Orders.Dto
{
    public class WxPayDto
    {
        /// <summary>
        /// 预支付
        /// </summary>
        public string prepay_id { get; set; }
        //签名
        public string Sign { get; set; }
        public string AppId { get; set; }
        public string PartnerId { get; set; }
        /// <summary>
        /// 随机数
        /// </summary>
        public string NonceStr { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        public string TimeStamp { get; set; }

    }
}
