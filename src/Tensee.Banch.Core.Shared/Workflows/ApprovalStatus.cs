using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tensee.Banch.WorkFlows
{
    public enum ApprovalStatus
    {
        Processing = 0,//处理中
        Agree = 1,//已同意
        Cancled = 101,//已撤销
        Rejected = 102,//已拒绝
        Complete=100//已办结
    }
}
