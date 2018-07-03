using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.Mobile.Orders.Dto
{
    public class GetUserOrderInput
    {
        public string SessionId { get; set; }
        public int? Stratus { get; set; }
    }
}
