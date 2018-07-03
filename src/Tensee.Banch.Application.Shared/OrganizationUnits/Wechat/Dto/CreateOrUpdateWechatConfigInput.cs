using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.OrganizationUnits.Wechat.Dto
{
   public class CreateOrUpdateWechatConfigInput
    {
        /// <summary>
        /// ID
        /// </summary>
        public int? Id { get; set; }
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

        /// <summary>
        /// 登陆页面
        /// </summary>
        public string PageName { get; set; }

        /// <summary>
        /// 返回页面
        /// </summary>
        public string PageRuslt { get; set; }
    }
}
