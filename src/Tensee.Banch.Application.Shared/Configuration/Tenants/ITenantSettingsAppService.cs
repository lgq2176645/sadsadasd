using System.Threading.Tasks;
using Abp.Application.Services;
using Tensee.Banch.Configuration.Tenants.Dto;

namespace Tensee.Banch.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
