using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tensee.Banch.WorkFlows
{
    public  class WorkflowInstance: FullAuditedEntity
    {
        public string InstanceNo { get; set; }
        public ApprovalStatus Status { get; set; }
        public string Title { get; set; }
        public int Approver { get; set; }
        public int FlowId { get; set; }
        public string CurrentStep { get; set; }
        public ICollection<WorkflowFormData> FormData { get; set; }
        public string Json { get; set; }
    }
}
