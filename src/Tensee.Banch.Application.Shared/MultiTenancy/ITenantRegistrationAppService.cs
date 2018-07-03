using System.Threading.Tasks;
using Abp.Application.Services;
using Tensee.Banch.Editions.Dto;
using Tensee.Banch.MultiTenancy.Dto;

namespace Tensee.Banch.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}