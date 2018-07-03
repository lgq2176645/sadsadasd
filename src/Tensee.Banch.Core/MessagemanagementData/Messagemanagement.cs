using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tensee.Banch
{
   public class Messagemanagement : FullAuditedEntity
    {
        /// <summary>
        /// 发送人ID
        /// </summary>
        public int SenderID { get; set; }

        /// <summary>
        /// 发送人姓名
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        /// 发送推送消息类容的标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 推送消息的类型
        /// </summary>
        public string MessageType { get; set; }

        /// <summary>
        /// 发送推送时间
        /// </summary>
        public DateTime SendTime { get; set; }

        /// <summary>
        /// 推送的内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 接收人ID
        /// </summary>
        public int ReceiverID { get; set; }

        /// <summary>
        /// 接收人
        /// </summary>
        public string ReceiverName { get; set; }

        /// <summary>
        /// 是否发送
        /// </summary>
        public bool IsSend { get; set; }

        /// <summary>
        /// 是否打开
        /// </summary>
        public bool IsOpen { get; set; }

        /// <summary>
        /// 打开时间
        /// </summary>
       public DateTime OpenTime { get; set; }


    }
}
