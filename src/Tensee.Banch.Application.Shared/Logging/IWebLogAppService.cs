using Abp.Application.Services;
using Tensee.Banch.Dto;
using Tensee.Banch.Logging.Dto;

namespace Tensee.Banch.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
