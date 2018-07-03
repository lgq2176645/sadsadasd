using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Zero.Configuration;
using Microsoft.AspNetCore.Identity;
using Tensee.Banch.Authorization.Roles;
using Tensee.Banch.Authorization.Users;
using Tensee.Banch.MultiTenancy;

namespace Tensee.Banch.Authorization.QYLogin
{
    public class ExternalLoginManager : ExternalAbpLogInManager<Tenant, Role, User>
    {
        public ExternalLoginManager(
                  UserManager userManager,
                  IMultiTenancyConfig multiTenancyConfig,
                  IRepository<Tenant> tenantRepository,
                  IUnitOfWorkManager unitOfWorkManager,
                  ISettingManager settingManager,
                  IRepository<UserLoginAttempt, long> userLoginAttemptRepository,
                  IUserManagementConfig userManagementConfig,
                  IIocResolver iocResolver,
                  RoleManager roleManager,
                  IPasswordHasher<User> passwordHasher,
                  UserClaimsPrincipalFactory claimsPrincipalFactory,
                   IRepository<UserLogin, long> userLoginRepository,
                    IRepository<User, long> userRepository)
            : base(
                  userManager, 
                  multiTenancyConfig, 
                  tenantRepository, 
                  unitOfWorkManager, 
                  settingManager, 
                  userLoginAttemptRepository, 
                  userManagementConfig, 
                  iocResolver, 
                  passwordHasher,
                  roleManager, 
                  claimsPrincipalFactory,
                  userLoginRepository,
                  userRepository)
        {

        }
    }
}