using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.QYWechat.Dto
{
    public class GetWechatLoginUserIdByCodeOutput
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public long Id { get; set; }
        public string Token { get; set; }

    }
}
