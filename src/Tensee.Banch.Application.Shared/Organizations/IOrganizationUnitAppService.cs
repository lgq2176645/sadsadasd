using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Tensee.Banch.Organizations.Dto;

namespace Tensee.Banch.Organizations
{
    public interface IOrganizationUnitAppService : IApplicationService
    {
        Task<ListResultDto<OrganizationUnitDto>> GetOrganizationUnits();

        Task<PagedResultDto<OrganizationUnitUserListDto>> GetOrganizationUnitUsers(GetOrganizationUnitUsersInput input);

        Task<OrganizationUnitDto> CreateOrganizationUnit(OrganizationUnitOutput input);

        Task<OrganizationUnitDto> UpdateOrganizationUnit(OrganizationUnitOutput input);

        Task<OrganizationUnitDto> MoveOrganizationUnit(MoveOrganizationUnitInput input);

        Task DeleteOrganizationUnit(EntityDto<long> input);

        Task RemoveUserFromOrganizationUnit(UserToOrganizationUnitInput input);

        Task AddUsersToOrganizationUnit(UsersToOrganizationUnitInput input);

        Task UpdateOrganizationUnitUsers(UpdateOrganizationUnitUsersInput input);

        Task<PagedResultDto<NameValueDto>> FindUsers(FindOrganizationUnitUsersInput input);

        //Task SynchronizeOrganizationUnitUsers(EntityDto<long> input);

        //Task SynchronizeOrganizationUnits(EntityDto<long> input);
        Task<OrganizationUnitOutput> GetOrganizationUnitById(EntityDto input);

        Task<ListResultDto<OrganizationUnitDto>> GetUserOrganizationUnits();
    }
}
