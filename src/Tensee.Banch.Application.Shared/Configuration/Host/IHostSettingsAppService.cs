using System.Threading.Tasks;
using Abp.Application.Services;
using Tensee.Banch.Configuration.Host.Dto;

namespace Tensee.Banch.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
