using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.QYWechat.Dto
{
   public class CreateTagUsersInput
    {
        /// <summary>
        /// 标签ID
        /// </summary>
        public string tagid { get; set; }

        /// <summary>
        /// 企业成员ID列表，注意：userlist、partylist不能同时为空，单次请求长度不超过1000
        /// </summary>
        public string[] useridlist { get; set; }
        /// <summary>
        /// 企业部门ID列表，注意：userlist、partylist不能同时为空，单次请求长度不超过1000
        /// </summary>
        public string[] partylist { get; set; }

    }
}
