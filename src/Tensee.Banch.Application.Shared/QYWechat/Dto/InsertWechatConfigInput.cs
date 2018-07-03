using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.QYWechat.Dto
{
   public  class InsertWechatConfigInput
    {
        /// <summary>
        /// 应用名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 应用的简称
        /// </summary>
        public string Value { get; set; }


        /// <summary>
        /// 应用的AgentId   
        /// </summary>
        public string AgentId { get; set; }

        /// <summary>
        /// 应用的 Secret
        /// </summary>
        public string Secret { get; set; }
    }
}
