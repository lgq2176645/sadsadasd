using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.QYWechat.Dto
{
    public class BatchDeleteWeChatUserInput
    {
        public string[] userIdList { get; set; }

        public string value { get; set; }
    }
}
