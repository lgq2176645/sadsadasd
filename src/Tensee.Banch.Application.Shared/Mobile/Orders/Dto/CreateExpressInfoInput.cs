using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.Mobile.Orders.Dto
{
    public class CreateExpressInfoInput
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public int OrderItemId { get; set; }
        /// <summary>
        /// 快递公司
        /// </summary>
        public string Express { get; set; }
        /// <summary>
        /// 快递号
        /// </summary>
        public string ExpressCode { get; set; }
    }
}
