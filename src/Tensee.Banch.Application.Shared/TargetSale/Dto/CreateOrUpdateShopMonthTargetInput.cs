using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.TargetSale.Dto
{
    public class CreateOrUpdateShopMonthTargetInput
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
        /// 保底目标
        /// </summary>
        public double TargetSale { get; set; }



        /// <summary>
        /// 保底连带率
        /// </summary>
        public double BasicsJointRate { get; set; }

        /// <summary>
        /// 保底新增vip
        /// </summary>
        public int BasicsNewVip { get; set; }

        /// <summary>
        /// 保底vip销售
        /// </summary>
        public double BasicsVipSaleTarget { get; set; }

        /// <summary>
        /// 冲刺目标
        /// </summary>
        public double SprintTargetSale { get; set; }
        /// <summary>
        /// 冲刺连带率
        /// </summary>
        public double SprintJointRate { get; set; }

        /// <summary>
        /// 冲刺新增vip
        /// </summary>
        public int SprintNewVip { get; set; }

        /// <summary>
        /// 冲刺vip销售
        /// </summary>
        public double SprintVipSaleTarget { get; set; }

    }
}
