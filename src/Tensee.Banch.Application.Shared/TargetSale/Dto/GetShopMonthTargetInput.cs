using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.TargetSale.Dto
{
   public class GetShopMonthTargetInput
    {
        public long OrganizationId { get; set; }
        public int ZYear { get; set; }
        public int ZMonth { get; set; }
    }
}
