using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tensee.Banch
{
    /// <summary>
    /// 流程表格表
    /// </summary>
    public class WorkFlowTable: FullAuditedEntity 
    {
        /// <summary>
        /// 流程ID
        /// </summary>
        public int FlowId { get; set; }

        /// <summary>
        /// 流程表
        /// </summary>
        public string Table { get; set; }

        /// <summary>
        /// 是否是主表
        /// </summary>
        public bool IsMain { get; set; }
        public virtual ICollection<WorkFlowField> Fields { get; set; }



    }
}
