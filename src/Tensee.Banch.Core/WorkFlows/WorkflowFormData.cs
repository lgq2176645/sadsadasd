using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tensee.Banch.WorkFlows
{
    public class WorkflowFormData: FullAuditedEntity
    {
        public int InstanceId { get; set; }
        public string  Table { get; set; }
        public int LineId { get; set; }
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        [ForeignKey("InstanceId")]
        public virtual WorkflowInstance Instance { get; set; }

    }
}
