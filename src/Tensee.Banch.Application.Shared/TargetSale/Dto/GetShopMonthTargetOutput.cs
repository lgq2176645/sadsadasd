using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.TargetSale.Dto
{
   public  class GetShopMonthTargetOutput
    {

        public ShopMonthTargetDto ShopMonthTarget { get; set; }

        public  List<ShopDayTargetDto> ShopDayTargets { get; set; }


    }
}
