using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.QYWechat.Dto
{
    public   class LoginViewModel
    {
        public string UsernameOrEmailAddress { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
