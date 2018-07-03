using Abp;
using Abp.Auditing;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.MultiTenancy; 
using Abp.Timing;
using Abp.Zero.Configuration;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Tensee.Banch.Authorization.QYLogin
{
  public  class ExternalAbpLogInManager<TTenant, TRole, TUser> : ITransientDependency
        where TTenant : AbpTenant<TUser>
        where TRole : AbpRole<TUser>, new()
        where TUser : AbpUser<TUser>
    {
        public IClientInfoProvider ClientInfoProvider { get; set; }

        protected IMultiTenancyConfig MultiTenancyConfig { get; }
        protected IRepository<TTenant> TenantRepository { get; }
        protected IUnitOfWorkManager UnitOfWorkManager { get; }
        protected AbpUserManager<TRole, TUser> UserManager { get; }
        protected ISettingManager SettingManager { get; }
        protected IRepository<UserLoginAttempt, long> UserLoginAttemptRepository { get; }
        protected IUserManagementConfig UserManagementConfig { get; }
        protected IIocResolver IocResolver { get; }
        protected AbpRoleManager<TRole, TUser> RoleManager { get; }

        private readonly IPasswordHasher<TUser> _passwordHasher;

        private readonly AbpUserClaimsPrincipalFactory<TUser, TRole> _claimsPrincipalFactory;
        private readonly IRepository<UserLogin, long> _userLoginRepository;
        public IRepository<TUser, long> UserRepository { get; }
        public ExternalAbpLogInManager(
            AbpUserManager<TRole, TUser> userManager,
            IMultiTenancyConfig multiTenancyConfig,
            IRepository<TTenant> tenantRepository,
            IUnitOfWorkManager unitOfWorkManager,
            ISettingManager settingManager,
            IRepository<UserLoginAttempt, long> userLoginAttemptRepository,
            IUserManagementConfig userManagementConfig,
            IIocResolver iocResolver,
            IPasswordHasher<TUser> passwordHasher,
            AbpRoleManager<TRole, TUser> roleManager,
            AbpUserClaimsPrincipalFactory<TUser, TRole> claimsPrincipalFactory,
            IRepository<UserLogin, long> userLoginRepository,
            IRepository<TUser, long> userRepository)
        {
            _passwordHasher = passwordHasher;
            _claimsPrincipalFactory = claimsPrincipalFactory;
            MultiTenancyConfig = multiTenancyConfig;
            TenantRepository = tenantRepository;
            UnitOfWorkManager = unitOfWorkManager;
            SettingManager = settingManager;
            UserLoginAttemptRepository = userLoginAttemptRepository;
            UserManagementConfig = userManagementConfig;
            IocResolver = iocResolver;
            RoleManager = roleManager; 
            UserManager = userManager;
            _userLoginRepository = userLoginRepository;
            UserRepository = userRepository;

            ClientInfoProvider = NullClientInfoProvider.Instance;
        }


        [UnitOfWork]
        public virtual async Task<AbpLoginResult<TTenant, TUser>> LoginAsync(UserLoginInfo login, string tenancyName = null)
        {
            var result = await LoginAsyncInternal(login, tenancyName);
            await SaveLoginAttempt(result, tenancyName, login.ProviderKey + "@" + login.LoginProvider);
            return result;
        }

        protected virtual async Task SaveLoginAttempt(AbpLoginResult<TTenant, TUser> loginResult, string tenancyName, string userNameOrEmailAddress)
        {
            using (var uow = UnitOfWorkManager.Begin(TransactionScopeOption.Suppress))
            {
                var tenantId = loginResult.Tenant != null ? loginResult.Tenant.Id : (int?)null;
                using (UnitOfWorkManager.Current.SetTenantId(tenantId))
                {
                    var loginAttempt = new UserLoginAttempt
                    {
                        TenantId = tenantId,
                        TenancyName = tenancyName,

                        UserId = loginResult.User != null ? loginResult.User.Id : (long?)null,
                        UserNameOrEmailAddress = userNameOrEmailAddress,

                        Result = loginResult.Result,

                        BrowserInfo = ClientInfoProvider.BrowserInfo,
                        ClientIpAddress = ClientInfoProvider.ClientIpAddress,
                        ClientName = ClientInfoProvider.ComputerName,
                    };

                    await UserLoginAttemptRepository.InsertAsync(loginAttempt);
                    await UnitOfWorkManager.Current.SaveChangesAsync();

                    await uow.CompleteAsync();
                }
            }
        }

        protected virtual async Task<AbpLoginResult<TTenant, TUser>> LoginAsyncInternal(UserLoginInfo login, string tenancyName)
        {
            if (login == null || login.LoginProvider.IsNullOrEmpty() || login.ProviderKey.IsNullOrEmpty())
            {
                throw new ArgumentException("login");
            }

            //Get and check tenant
            TTenant tenant = null;
            if (!MultiTenancyConfig.IsEnabled)
            {
                tenant = await GetDefaultTenantAsync();
            }
            else if (!string.IsNullOrWhiteSpace(tenancyName))
            {
                tenant = await TenantRepository.FirstOrDefaultAsync(t => t.TenancyName == tenancyName);
                if (tenant == null)
                {
                    return new AbpLoginResult<TTenant, TUser>(AbpLoginResultType.InvalidTenancyName);
                }

                if (!tenant.IsActive)
                {
                    return new AbpLoginResult<TTenant, TUser>(AbpLoginResultType.TenantIsNotActive, tenant);
                }
            }

            int? tenantId = tenant == null ? (int?)null : tenant.Id;
            using (UnitOfWorkManager.Current.SetTenantId(tenantId))
            {
                var user = await FindAsync(tenantId, login);
                if (user == null)
                {
                    return new AbpLoginResult<TTenant, TUser>(AbpLoginResultType.UnknownExternalLogin, tenant);
                }

                return await CreateLoginResultAsync(user, tenant);
            }
        }

      
        public virtual Task<TUser> FindAsync(int? tenantId, UserLoginInfo login)
        {
            var userLogin =  _userLoginRepository.FirstOrDefaultAsync(
                ul => ul.LoginProvider == login.LoginProvider && ul.ProviderKey == login.ProviderKey
            );
            var user = new UserLogin();
            var userInfo = UserManager.Users.FirstOrDefault(r => r.UserName == login.ProviderKey);
            if (userLogin.Result == null)
            {

                user = new UserLogin
                {
                    LoginProvider = login.LoginProvider,
                    ProviderKey = login.ProviderKey,
                    TenantId = userInfo.TenantId,
                    UserId = userInfo.Id,

                };

                _userLoginRepository.Insert(user);

            }
            else
            {
                user.UserId = userInfo.Id;
            }

            return UserRepository.FirstOrDefaultAsync(u => u.Id == user.UserId);
        }




        public  async Task<AbpLoginResult<TTenant, TUser>> LoginAsyncInternal(string login, string tenancyName)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentException("login");
            }

            //Get and check tenant
            TTenant tenant = null;
            if (!MultiTenancyConfig.IsEnabled)
            {
                tenant = await GetDefaultTenantAsync();
            }
            else if (!string.IsNullOrWhiteSpace(tenancyName))
            {
                tenant = await TenantRepository.FirstOrDefaultAsync(t => t.TenancyName == tenancyName);
                if (tenant == null)
                {
                    return new AbpLoginResult<TTenant, TUser>(AbpLoginResultType.InvalidTenancyName);
                }

                if (!tenant.IsActive)
                {
                    return new AbpLoginResult<TTenant, TUser>(AbpLoginResultType.TenantIsNotActive, tenant);
                }
            }

            int? tenantId = tenant == null ? (int?)null : tenant.Id;
            using (UnitOfWorkManager.Current.SetTenantId(tenantId))
            {
                var user = await UserManager.FindByNameOrEmailAsync(login);
                if (user == null)
                {
                    return new AbpLoginResult<TTenant, TUser>(AbpLoginResultType.UnknownExternalLogin, tenant);
                }

                return await CreateLoginResultAsync(login, tenant);
            }
        }


        protected virtual async Task<TTenant> GetDefaultTenantAsync()
        {
            var tenant = await TenantRepository.FirstOrDefaultAsync(t => t.TenancyName == AbpTenant<TUser>.DefaultTenantName);
            if (tenant == null)
            {
                throw new AbpException("There should be a 'Default' tenant if multi-tenancy is disabled!");
            }

            return tenant;
        }

        protected virtual async Task<AbpLoginResult<TTenant, TUser>> CreateLoginResultAsync(string name, TTenant tenant = null)
        {
            var user = await UserManager.FindByNameOrEmailAsync(name);

            if (!user.IsActive)
            {
                return new AbpLoginResult<TTenant, TUser>(AbpLoginResultType.UserIsNotActive);
            }

            //if (await IsEmailConfirmationRequiredForLoginAsync(user.TenantId) && !user.IsEmailConfirmed)
            //{
            //    return new AbpLoginResult<TTenant, TUser>(AbpLoginResultType.UserEmailIsNotConfirmed);
            //}

            //if (await IsPhoneConfirmationRequiredForLoginAsync(user.TenantId) && !user.IsPhoneNumberConfirmed)
            //{
            //    return new AbpLoginResult<TTenant, TUser>(AbpLoginResultType.UserPhoneNumberIsNotConfirmed);
            //}

            user.LastLoginTime = Clock.Now;

            await UserManager.UpdateAsync(user);

            await UnitOfWorkManager.Current.SaveChangesAsync();

            var principal = await _claimsPrincipalFactory.CreateAsync(user);

            return new AbpLoginResult<TTenant, TUser>(
                tenant,
                user,
                principal.Identity as ClaimsIdentity
            );
        }

        protected virtual async Task<bool> IsEmailConfirmationRequiredForLoginAsync(int? tenantId)
        {
            if (tenantId.HasValue)
            {
                return await SettingManager.GetSettingValueForTenantAsync<bool>(AbpZeroSettingNames.UserManagement.IsEmailConfirmationRequiredForLogin, tenantId.Value);
            }

            return await SettingManager.GetSettingValueForApplicationAsync<bool>(AbpZeroSettingNames.UserManagement.IsEmailConfirmationRequiredForLogin);
        }


        protected virtual Task<bool> IsPhoneConfirmationRequiredForLoginAsync(int? tenantId)
        {
            return Task.FromResult(false);
        }

        protected virtual async Task<AbpLoginResult<TTenant, TUser>> CreateLoginResultAsync(TUser user, TTenant tenant = null)
        {
            if (!user.IsActive)
            {
                return new AbpLoginResult<TTenant, TUser>(AbpLoginResultType.UserIsNotActive);
            }

            if (await IsEmailConfirmationRequiredForLoginAsync(user.TenantId) && !user.IsEmailConfirmed)
            {
                return new AbpLoginResult<TTenant, TUser>(AbpLoginResultType.UserEmailIsNotConfirmed);
            }

            if (await IsPhoneConfirmationRequiredForLoginAsync(user.TenantId) && !user.IsPhoneNumberConfirmed)
            {
                return new AbpLoginResult<TTenant, TUser>(AbpLoginResultType.UserPhoneNumberIsNotConfirmed);
            }

            user.LastLoginTime = Clock.Now;

            await UserManager.UpdateAsync(user);

            await UnitOfWorkManager.Current.SaveChangesAsync();

            var principal = await _claimsPrincipalFactory.CreateAsync(user);

            return new AbpLoginResult<TTenant, TUser>(
                tenant,
                user,
                principal.Identity as ClaimsIdentity
            );
        }

    }
}
