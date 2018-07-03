using Abp.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tensee.Banch
{
    public class Organization : OrganizationUnit
    {
        /// <summary>
        /// 菜单层次
        /// </summary>
        public virtual int Depth { get; set; }
        /// <summary>
        /// 所有父节点ID
        /// </summary>
        public virtual string Number { get; set; }
        /// <summary>
        /// 部门领导
        /// </summary>
        public virtual string Leader { get; set; }
        /// <summary>
        /// 是否店铺
        /// </summary>
        public virtual bool IsShop { get; set; }
        /// <summary>
        /// 组织机构状态  -1=歇业  0是开业  1是装修
        /// </summary>
        public virtual int Status { get; set; }
    }
}
