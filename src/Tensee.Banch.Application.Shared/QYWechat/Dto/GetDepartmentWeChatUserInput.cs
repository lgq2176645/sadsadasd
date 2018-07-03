using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.QYWechat.Dto
{
   public  class GetDepartmentWeChatUserInput
    {
        /// <summary>
        /// 获取的部门id
        /// </summary>
        public long departmentId { get; set; }

        /// <summary>
        /// 1/0：是否递归获取子部门下面的成员
        /// </summary>
        public int fetchChild { get; set; }

        public string  value { get; set; }
    }
}
