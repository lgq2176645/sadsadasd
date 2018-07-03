using System.Threading.Tasks;
using Abp.Application.Services;
using Tensee.Banch.MultiTenancy.Dto;
using Tensee.Banch.MultiTenancy.Payments.Dto;
using Abp.Application.Services.Dto;

namespace Tensee.Banch.MultiTenancy.Payments
{
    public interface IPaymentAppService : IApplicationService
    {
        Task<PaymentInfoDto> GetPaymentInfo(PaymentInfoInput input);

        Task<CreatePaymentResponse> CreatePayment(CreatePaymentDto input);

        Task<ExecutePaymentResponse> ExecutePayment(ExecutePaymentDto input);

        Task<PagedResultDto<SubscriptionPaymentListDto>> GetPaymentHistory(GetPaymentHistoryInput input);
    }
}
