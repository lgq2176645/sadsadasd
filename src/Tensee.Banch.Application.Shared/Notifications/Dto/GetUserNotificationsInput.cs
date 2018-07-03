using Abp.Notifications;
using Tensee.Banch.Dto;

namespace Tensee.Banch.Notifications.Dto
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }
    }
}