using Abp.Authorization;
using Tensee.Banch.Authorization.Roles;
using Tensee.Banch.Authorization.Users;

namespace Tensee.Banch.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
