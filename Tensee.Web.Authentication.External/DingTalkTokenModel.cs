using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Web.Authentication.External
{
    public class DingTalkTokenModel
    {
        public string access_token { get; set; }

        public int errcode { get; set; }

        public string errmsg { get; set; }
    }
}
