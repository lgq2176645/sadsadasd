using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tensee.Banch.DingTalk.Dto;

namespace Tensee.Banch.DingTalk
{
    public interface IDingTalkAppService: IApplicationService
    {
        Task SendImageText(DingTalkSenderInfo input);
    }
}
