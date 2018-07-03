using Abp.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Tensee.Banch.Authorization.Roles;

namespace Tensee.Banch.Authorization.Users
{
    public class UserClaimsPrincipalFactory : AbpUserClaimsPrincipalFactory<User, Role>
    {
        public UserClaimsPrincipalFactory(
            UserManager userManager,
            RoleManager roleManager,
            IOptions<IdentityOptions> optionsAccessor)
            : base(
                  userManager,
                  roleManager,
                  optionsAccessor)
        {
        }
    }
}
