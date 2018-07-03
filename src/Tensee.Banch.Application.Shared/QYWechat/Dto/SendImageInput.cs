using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tensee.Banch.QYWechat.Dto
{
    public class SendImageInput
    {
      

        /// <summary>
        /// 媒体资源文件ID
        /// </summary>
        public string mediaId { get; set; }

        /// <summary>
        /// UserID列表（消息接收者，多个接收者用‘|’分隔）。特殊情况：指定为@all，则向关注该企业应用的全部成员发送
        /// </summary>
        [DefaultValue("@all")]
        public string toUser { get; set; }

        /// <summary>
        /// PartyID列表，多个接受者用‘|’分隔。当touser为@all时忽略本参数
        /// </summary>
        [DefaultValue("@all")]
        public string toParty { get; set; }

        /// <summary>
        /// TagID列表，多个接受者用‘|’分隔。当touser为@all时忽略本参数
        /// </summary>
        [DefaultValue(null)]
        public string toTag { get; set; }

        /// <summary>
        /// 表示是否是保密消息，0表示否，1表示是，默认0
        /// </summary>
        [DefaultValue(0)]
        public int safe { get; set; }


        /// <summary>
        /// 应用的value
        /// </summary>
        public string value { get; set; }
    }
}
