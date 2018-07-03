using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.Mobile.Coupons.Dto
{
    public class CouponDto
    {
        public int? Id { get; set; }
        /// <summary>
        /// 优惠卷编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 价值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 满减价钱
        /// </summary>
        public int? Condition { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 状态（0有效/1有效）
        /// </summary>
        public bool Status { get; set; }
        public string Remark { get; set; }
        
        public int CouponTypeId { get; set; }
        public string CouponType { get; set; }
    }
}
