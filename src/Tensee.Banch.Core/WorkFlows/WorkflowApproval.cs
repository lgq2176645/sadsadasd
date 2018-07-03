using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tensee.Banch.WorkFlows
{
    public class WorkflowApproval: CreationAuditedEntity
    {
        public int InstanceId { get; set; }
        public int? PreStepId { get; set; }
        public int StepId { get; set; }
        public long? Approver { get; set; }
        public DateTime? ApprovalTime { get; set; }
        public bool IsCurrentStep { get; set; }
        public ApprovalStatus Status { get; set; }
    }
}
