using System;
using System.Collections.Generic;
using System.Text;
using Tensee.Banch.Dto;

namespace Tensee.Banch.Mobile.Orders.Dto
{
    public class GetOrderInput : PagedAndSortedInputDto
    {
        //public int? UserId { get; set; }
        public string SessionId { get; set; }
        public int? Stratus { get; set; }
        public int? Mode { get; set; }
    }
}
