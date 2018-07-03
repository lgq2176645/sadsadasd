using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.Mobile.Orders.Dto
{
    public class ExpressInfoDto
    {
        public int? Id { get; set; }
        public int OrderItemId { get; set; }
        public string Express { get; set; }
        public string ExpressCode { get; set; }
        public string NikeName { get; set; }
        public string GoodsTitle { get; set; }
    }
}
