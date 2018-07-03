using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tensee.Banch.Mobile.Orders.Dto;

namespace Tensee.Banch.Mobile.Orders
{
    public interface IExpressInfoAppService : IApplicationService
    {
        Task<ExpressInfoDto> CreateExpressInfo(CreateExpressInfoInput input);
        Task<PagedResultDto<ExpressInfoDto>> GetAllExpressInfoList();
        //Task UpdateExpressInfo(ExpressInfoDto input);
      

    }
}
