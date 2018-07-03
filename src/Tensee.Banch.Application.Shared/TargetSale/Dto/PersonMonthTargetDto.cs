using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.TargetSale.Dto
{
  public   class PersonMonthTargetDto
    {
        public long OrganizationId { get; set; }
        public int ZYear { get; set; }
        public int ZMonth { get; set; }

        public int UserId { get; set; }
        public string UserName { get; set; }


        public double TargetSale { get; set; }

        public double JointRate { get; set; }

        public int NewVip { get; set; }
        public double VipSaleTarget { get; set; }
    }
}
