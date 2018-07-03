using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.Mobile.Orders.Dto
{
    public class GetAllOrderDto
    {
        public int Id { get; set; }

        //public int GoodsId { get; set; }
        public string GoodsTitle { get; set; }
        //public int UserId { get; set; }
        public string OpenId { get; set; }
        public string NickName { get; set; }
       
        //public int? CouponId { get; set; }
        public string CouponTitle { get; set; }
        public decimal Price { get; set; }
        /// <summary>
        /// 方式（0上门/1到店/2邮寄）
        /// </summary>
        public int Mode { get; set; }
        //public int ShippingAddressId { get; set; }
        /// <summary>
        /// 收货人
        /// </summary>
        public string Consignee { get; set; }
        public string Address { get; set; }

        /// <summary>
        /// 服务时间
        /// </summary>
        public DateTime? ServiceTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
    }
}
