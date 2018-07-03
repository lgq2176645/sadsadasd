using System;
using System.Collections.Generic;
using System.Text;


namespace Tensee.Banch.Mobile.Orders.Dto
{
    public class OrderDto 
    {
        public int Id { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public int GoodsId { get; set; }
        public int UserId { get; set; }
        /// <summary>
        /// 地址ID
        /// </summary>
        public int ShippingAddressId { get; set; }
        /// <summary>
        /// 优惠卷ID
        /// </summary>
        public int? CouponId { get; set; }
        public decimal Price { get; set; }
        /// <summary>
        /// 方式（0上门/1到店/2邮寄）
        /// </summary>
        public int Mode { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public int? ShopId { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 服务时间
        /// </summary>
        public DateTime? ServiceTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        public string GoodsTitle { get; set; }
        public string CouponTitle { get; set; }

        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
