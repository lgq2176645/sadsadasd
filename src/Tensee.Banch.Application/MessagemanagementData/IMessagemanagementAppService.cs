using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tensee.Banch.MessagemanagementData.Dto;

namespace Tensee.Banch.MessagemanagementData
{
   public interface IMessagemanagementAppService :IApplicationService
    {
        /// <summary>
        /// 查询查询已推送消息
        /// </summary>
       List<Messagemanagement> GetPushmessage(GetPushmessageInput input);

        /// <summary>
        /// 删除未推送消息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleNonPushMessage(EntityDto input);

        /// <summary>
        /// 建推送消息接
        /// </summary>
        /// <returns></returns>
        string CreaNonPushessage(CreaNonPushessageInput input);

        /// <summary>
        /// 修改推送消息接
        /// </summary>
        /// <returns></returns>
        Task<string> UpdaNonPushessage(UpdateNonPushessageInput input);

    }
}
