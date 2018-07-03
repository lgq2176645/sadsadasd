using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Tensee.Banch.Authorization.Permissions.Dto;

namespace Tensee.Banch.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
