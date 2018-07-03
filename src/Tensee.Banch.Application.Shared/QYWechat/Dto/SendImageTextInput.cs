using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tensee.Banch.QYWechat.Dto
{
    public class SendImageTextInput
    {
        [DefaultValue("@all")]
        public string touser { get; set; }
        [DefaultValue("@all")]
        public string toparty { get; set; }
        [DefaultValue("@all")]
        public string totag { get; set; }
        [DefaultValue("textcard")]

        public string msgtype { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }

        [DefaultValue("点击进入相关页面")]

        public string btntxt { get; set; }

        public  string value { get; set; }
    }
}
