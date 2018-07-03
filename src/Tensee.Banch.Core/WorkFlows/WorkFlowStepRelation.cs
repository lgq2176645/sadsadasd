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
    /// 流程节点关系表
    /// </summary>
    public class WorkFlowStepRelation: CreationAuditedEntity
    {
        /// <summary>
        /// 流程ID
        /// </summary>
        public int FlowId { get; set; }

        /// <summary>
        /// 节点ID
        /// </summary>
        public int FromStep { get; set; }

        /// <summary>
        /// 下一节点ID
        /// </summary>
        public int ToStep { get; set; }

        /// <summary>
        /// 跳转条件
        /// </summary>
        public string Condtion { get; set; }


      
    }
}
