using Abp.Domain.Entities.Auditing;

namespace Tensee.Banch
{
    /// <summary>
    /// 流程主表
    /// </summary>
    public class WorkFlow: FullAuditedEntity
    {
        /// <summary>
        /// 流程名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 流程类型
        /// </summary>
        public string FlowType { get; set; }

        /// <summary>
        /// 流程页面路径
        /// </summary>
        public string PageUrl { get; set; }
        /// <summary>
        /// 单号前缀
        /// </summary>
        public string FlowNoPrefix { get; set; }
        /// <summary>
        /// 流水码长度
        /// </summary>
        public int FlowNoLength { get; set; }
        /// <summary>
        /// 流程编号索引
        /// </summary>
        public int FlowNoIndex { get; set; }

        /// <summary>
        /// 流程状态  -1=不启用，1=启用
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 流程页面Html
        /// </summary>
        public string HtmlText { get; set; }
        public string FormJson { get; set; }
        public string StepJson { get; set; }

    }
}
