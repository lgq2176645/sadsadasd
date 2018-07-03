using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tensee.Banch
{
    /// <summary>
    /// 流程节点表
    /// </summary>
    public class WorkFlowStep : FullAuditedEntity
    {
        /// <summary>
        /// 流程ID
        /// </summary>
        public int FlowId { get; set; }

        /// <summary>
        /// 节点名称
        /// </summary>
        public string StepName { get; set; }

        /// <summary>
        /// 审批人员选择类型
        /// </summary>
        public string HandlerType { get; set; }


        /// <summary>
        /// 审批人员选择范围
        /// </summary>
        public string ApproverList { get; set; }

        /// <summary>
        /// 抄送人
        /// </summary>
        public string CopyerList { get; set; }

        /// <summary>
        /// 节点按钮
        /// </summary>
        public string StepButton { get; set; }

     
    }
}
