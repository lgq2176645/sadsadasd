using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.Organizations.Dto
{
   public class WeChatOrganization
    {
        /// <summary>
        /// 部门名称。长度限制为1~64个字节，字符不能包括\:?”<>｜
        /// 必须字段
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 父部门id，32位整型
        /// 必须字段
        /// </summary>
        public long? parentid { get; set; }

        /// <summary>
        /// 在父部门中的次序值。order值大的排序靠前。有效的值范围是[0, 2^32)
        /// 非必须字段
        /// </summary>
        public int order { get; set; }

        /// <summary>
        /// 部门id，32位整型。有效的值范围是[0, 2^31) 。指定时必须大于1，否则自动生成
        /// 必须字段
        /// 
        /// </summary>
        public long id { get; set; }

        public string value { get; set; }
    }
}
