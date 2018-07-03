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
    /// 流程控件表
    /// </summary>
    public class WorkFlowField: FullAuditedEntity
    {
        /// <summary>
        ///  WorkFlowTable表ID
        /// </summary>
        public int TableId { get; set; }

        /// <summary>
        ///  WorkFlow表ID
        /// </summary>
        public int FlowId { get; set; }

        /// <summary>
        /// 控件ID
        /// </summary>
        public string ControlId { get; set; }

        /// <summary>
        /// 控件类型
        /// </summary>
        public string FieldType { get; set; }

        /// <summary>
        /// 控件文本
        /// </summary>
        public string FieldLable { get; set; }

        /// <summary>
        /// 控件提示文本
        /// </summary>
        public string FieldPlaceholder { get; set; }

        /// <summary>
        /// 控件其他样式
        /// </summary>
        public string OtherCss { get; set; }

        /// <summary>
        /// 校验数据的JS
        /// </summary>
        public string JsText { get; set; }

        [ForeignKey("TableId")]
        public virtual WorkFlowTable OwnerTable { get; set; }
    }
}
