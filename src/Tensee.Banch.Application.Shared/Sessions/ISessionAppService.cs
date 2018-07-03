using System.Threading.Tasks;
using Abp.Application.Services;
using Tensee.Banch.Sessions.Dto;

namespace Tensee.Banch.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
