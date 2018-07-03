using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tensee.Banch
{
    /// <summary>
    /// 店铺日销售
    /// </summary>
   public class ShopDayTarget: FullAuditedEntity
    {
        /// <summary>
        /// 组织架构ID
        /// </summary>
        public int OrganizationId { get; set; }
        /// <summary>
        /// 年
        /// </summary>
        public int ZYear { get; set; }
        /// <summary>
        /// 月
        /// </summary>
        public int ZMonth { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 保底目标
        /// </summary>
        public double DayTarget { get; set; }

        /// <summary>
        /// 冲刺目标
        /// </summary>
        public double SprintDayTarget { get; set; }

    }
}
