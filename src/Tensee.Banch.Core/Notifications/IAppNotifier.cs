using System.Threading.Tasks;
using Abp;
using Abp.Notifications;
using Tensee.Banch.Authorization.Users;
using Tensee.Banch.MultiTenancy;

namespace Tensee.Banch.Notifications
{
    public interface IAppNotifier
    {
        Task WelcomeToTheApplicationAsync(User user);

        Task NewUserRegisteredAsync(User user);

        Task NewTenantRegisteredAsync(Tenant tenant);

        Task SendMessageAsync(UserIdentifier user, string message, NotificationSeverity severity = NotificationSeverity.Info);
    }
}
