using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tensee.Banch.MessagemanagementData.Dto
{
   public class GetPushmessageInput
    {
        /// <summary>
        /// 传过来的4个值 SenderID，SenderName，ReceiverID，ReceiverName
        /// </summary>
        public string  value { get; set; }

        /// <summary>
        /// 是否发送状态
        /// </summary>
        public bool IsSend { get; set; }
         /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }
    }
}
