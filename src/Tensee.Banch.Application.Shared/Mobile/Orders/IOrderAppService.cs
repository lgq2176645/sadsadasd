using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tensee.Banch.Mobile.Orders.Dto;

namespace Tensee.Banch.Mobile.Orders
{
    public interface IOrderAppService : IApplicationService
    {
        Task<ReustModel> CreateOrder(CreateOrderInput input);
        Task UpdateOrderStatus(UpdateOrderInput input);

        Task<ListResultDto<OrderDto>> GetUserOrderList(GetUserOrderInput input);
        Task<PagedResultDto<GetAllOrderDto>> GetAllOrderList(GetOrderInput input);

        Task<OrderDto> GetOrderInfo(EntityDto input);
        WxPayDto GetWxPay(WxPayInput input);

    }
}
