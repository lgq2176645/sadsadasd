using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.QYWechat.Dto
{
    public class GetWechatLoginInput
    {
        public string Code { get; set; }

        //public string from { get; set; }

        //public string vit { get; set; }
        public string PageResult { get; set; }
    }
}
