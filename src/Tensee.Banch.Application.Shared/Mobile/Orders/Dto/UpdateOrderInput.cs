using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.Mobile.Orders.Dto
{
    public class UpdateOrderInput
    {
        public int OrderId { get; set; }
        public int Status { get; set; }
    }
}
