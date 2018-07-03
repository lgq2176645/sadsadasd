using System.Threading.Tasks;
using Abp.Application.Services;
using Tensee.Banch.Install.Dto;

namespace Tensee.Banch.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}