using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.Authorization.Users.Dto
{
    public  class GetOtherMsgByIdentityCodeInput
    {
        public string PhoneNumber { get; set; }

        public string IdentityCode { get; set; }
    }
}
