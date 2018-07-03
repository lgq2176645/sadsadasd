using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tensee.Banch
{
    /// <summary>
    /// 人员月目标
    /// </summary>
   public class PersonMonthTarget: FullAuditedEntity
    {
        /// <summary>
        /// 组织架构ID
        /// </summary>
        public long OrganizationId { get; set; }
        /// <summary>
        /// 年
        /// </summary>
        public int ZYear { get; set; }
        /// <summary>
        /// 月
        /// </summary>
        public int ZMonth { get; set; }

        /// <summary>
        /// 人员ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 保底目标
        /// </summary>
        public double TargetSale { get; set; }

        /// <summary>
        /// 冲刺目标
        /// </summary>
        public double SprintTargetSale { get; set; }

        /// <summary>
        /// 连带率
        /// </summary>
        public double JointRate { get; set; }

        /// <summary>
        /// 新增vip
        /// </summary>
        public int NewVip { get; set; }

        /// <summary>
        /// vip销售
        /// </summary>
        public double VipSaleTarget { get; set; }

        /// <summary>
        /// 连带率
        /// </summary>
        public double SprintJointRate { get; set; }

        /// <summary>
        /// 新增vip
        /// </summary>
        public int SprintNewVip { get; set; }

        /// <summary>
        /// vip销售
        /// </summary>
        public double SprintVipSaleTarget { get; set; }

    }
}
