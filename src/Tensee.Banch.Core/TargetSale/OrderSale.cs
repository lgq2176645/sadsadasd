using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tensee.Banch
{
    /// <summary>
    /// 订单销售表
    /// </summary>
    public class OrderSale : FullAuditedEntity
    {
        /// <summary>
        /// 订单编号        
        /// </summary>
        public string OrderCode { get; set; }

        /// <summary>
        /// 订单日期
        /// </summary>
        public DateTime OrderDate { get; set; }


        /// <summary>
        /// 销售 日期
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// 销售件数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 实际销售金额
        /// </summary>
        public double ActualSale { get; set; }

        /// <summary>
        /// 总价
        /// </summary>
        public double TargetSale { get; set; }

        /// <summary>
        /// 组织架构编号
        /// </summary>
        public string OrganizationCode { get; set; }

        /// <summary>
        /// 人员账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 积分卡编号等
        /// </summary>
        public string CardCode { get; set; }
    }
}
