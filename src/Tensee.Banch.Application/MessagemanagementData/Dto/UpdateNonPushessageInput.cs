using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tensee.Banch.MessagemanagementData.Dto
{

    public class UpdateNonPushessageInput
    {

        public int? id { get; set; }
        /// <summary>
        /// 发送推送消息类容的标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 推送消息的类型
        /// </summary>
        public string MessageType { get; set; }

      

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

       


    }
}
