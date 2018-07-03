using System;
using System.Collections.Generic;
using System.Text;
using Tensee.Banch.Dto;

namespace Tensee.Banch.Mobile.Coupons.Dto
{
    public class GetCouponDto : PagedAndSortedInputDto
    {
        public int? Id { get; set; }
    }
}
