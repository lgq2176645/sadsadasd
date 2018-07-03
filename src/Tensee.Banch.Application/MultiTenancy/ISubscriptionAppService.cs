using System.Threading.Tasks;
using Abp.Application.Services;

namespace Tensee.Banch.MultiTenancy
{
    public interface ISubscriptionAppService : IApplicationService
    {
        Task UpgradeTenantToEquivalentEdition(int upgradeEditionId);
    }
}
