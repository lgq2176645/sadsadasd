using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.Mobile.Coupons.Dto
{
    public class UserCouponDto
    {
        public int? Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public int? Condition { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Status { get; set; }
        public string Remark { get; set; }
        public int IsUse { get; set; }
        //public string CouponType { get; set; }
        public string Title { get; set; }
    }
}
