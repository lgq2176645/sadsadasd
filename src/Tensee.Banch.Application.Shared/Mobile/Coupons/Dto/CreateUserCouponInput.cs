using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.Mobile.Coupons.Dto
{
    public class CreateUserCouponInput
    {
        //public int UserId { get; set; }
        public List<int> UserIdList { get; set; }
        public int CouponId { get; set; }
        /// <summary>
        /// 是否使用
        /// </summary>
        public int IsUse { get; set; }
    }
}
