using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.TargetSale.Dto
{
   public  class CreateOrUpdatePersonMonthTargetOutput
    {
        public ShopMonthTargetDto ShopMonthTarget { get; set; }
        public List<CreateOrUpdatePersonMonthTargetInput> PersonMonthTargets { get; set; }
    }
}
