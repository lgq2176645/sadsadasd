using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.QYWechat.Dto
{
   public  class GetUserCheckinInput
    {

        public string[] UserList { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Type {get; set; }

    }


}
