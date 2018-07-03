using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tensee.Banch
{
   public class MessagePool: FullAuditedEntity
    {
        /// <summary>
        /// 平台
        /// </summary>
        public string PlatForm { get; set; }

        ///// <summary>
        ///// 公司ID
        ///// </summary>
        //public string CompanyID { get; set; }

        ///// <summary>
        ///// 业务模块ID
        ///// </summary>
        //public string ModelID { get; set; }

        /// <summary>
        /// 业务模块名称
        /// </summary>
        public string ModelName { get; set; }

        /// <summary>
        /// 其他信息 拓展字段
        /// </summary>
        public string OrtherMsg { get; set; }

        /// <summary>
        /// 操作   添加 删除 修改 发送
        /// </summary>
        public string Operation { get; set; }
        /// <summary>
        /// Json文本
        /// </summary>
        public string JsonText { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        public string ResultText { get; set; }

        /// <summary>
        /// 发送状态 -1=异常 0=未发送 1=发送中 2=已发送   
        /// </summary>
        public int Status { get; set; }

    }
}
