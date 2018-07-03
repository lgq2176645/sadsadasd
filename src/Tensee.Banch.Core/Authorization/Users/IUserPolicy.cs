using System.Threading.Tasks;
using Abp.Domain.Policies;

namespace Tensee.Banch.Authorization.Users
{
    public interface IUserPolicy : IPolicy
    {
        Task CheckMaxUserCountAsync(int tenantId);
    }
}
