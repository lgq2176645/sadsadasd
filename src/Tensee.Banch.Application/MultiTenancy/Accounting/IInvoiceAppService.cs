using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Tensee.Banch.MultiTenancy.Accounting.Dto;

namespace Tensee.Banch.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
