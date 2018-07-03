using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Configuration;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.Notifications;
using Abp.Organizations;
using Abp.Runtime.Session;
using Abp.UI;
using Abp.Zero.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tensee.Banch.Authorization.Permissions;
using Tensee.Banch.Authorization.Permissions.Dto;
using Tensee.Banch.Authorization.Roles;
using Tensee.Banch.Authorization.Users.Dto;
using Tensee.Banch.Authorization.Users.Exporting;
using Tensee.Banch.Dto;
using Tensee.Banch.Notifications;
using Tensee.Banch.Url;
using Tensee.Banch.Organizations.Dto;
using System;
using Tensee.Banch.QYWechat;

using Abp.Runtime.Caching;
using Tensee.Banch.Wechat;

namespace Tensee.Banch.Authorization.Users
{
    [AbpAuthorize(AppPermissions.Pages_Administration_Users)]
    public class UserAppService : BanchAppServiceBase, IUserAppService
    {
        public IAppUrlService AppUrlService { get; set; }
  
        private readonly RoleManager _roleManager;
        private readonly IUserEmailer _userEmailer;
        private readonly IUserListExcelExporter _userListExcelExporter;
        private readonly INotificationSubscriptionManager _notificationSubscriptionManager;
        private readonly IAppNotifier _appNotifier;
        private readonly IRepository<RolePermissionSetting, long> _rolePermissionRepository;
        private readonly IRepository<UserPermissionSetting, long> _userPermissionRepository;
        private readonly IRepository<UserRole, long> _userRoleRepository;
        private readonly IUserPolicy _userPolicy;
        private readonly IEnumerable<IPasswordValidator<User>> _passwordValidators;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IRepository<OrganizationUnit, long> _organizationUnitRepository;
     //   private readonly IRepository<UserUnits, long> _userUnitsRepository;
        private readonly IRepository<UserOrganizationUnit, long> _userOrganizationUnitRepository;
        private readonly IRepository<Role, int> _roleRepository;
        private readonly IQYWechatAppService _iQYWechatAppService;
        private readonly ICacheManager _cacheManager;
        private readonly IRepository<WechatConfig> _wechatConfig;
        private readonly IRepository<UserLogin,long> _userLogin;
        private readonly IRepository<WeChatUnionInfo> _unionInfos;

        public UserAppService(
            RoleManager roleManager,
            IUserEmailer userEmailer,
            IUserListExcelExporter userListExcelExporter,
            INotificationSubscriptionManager notificationSubscriptionManager,
            IAppNotifier appNotifier,
            IRepository<RolePermissionSetting, long> rolePermissionRepository,
            IRepository<UserPermissionSetting, long> userPermissionRepository,
            IRepository<UserRole, long> userRoleRepository,
            IUserPolicy userPolicy,
            IEnumerable<IPasswordValidator<User>> passwordValidators,
            IPasswordHasher<User> passwordHasher,
            IRepository<OrganizationUnit, long> organizationUnitRepository,
         //   IRepository<UserUnits, long> userUnitsRepository,
            IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository,
            IRepository<Role, int> roleRepository,
            IQYWechatAppService iQYWechatAppService,
             ICacheManager cacheManager,
             IRepository<WechatConfig> wechatConfig,
             IRepository<UserLogin, long> userLogin,
             IRepository<WeChatUnionInfo> unionInfos)
        {
            _roleManager = roleManager;
            _userEmailer = userEmailer;
            _userListExcelExporter = userListExcelExporter;
            _notificationSubscriptionManager = notificationSubscriptionManager;
            _appNotifier = appNotifier;
            _rolePermissionRepository = rolePermissionRepository;
            _userPermissionRepository = userPermissionRepository;
            _userRoleRepository = userRoleRepository;
            _userPolicy = userPolicy;
            _passwordValidators = passwordValidators;
            _passwordHasher = passwordHasher;
            _organizationUnitRepository = organizationUnitRepository;
          //  _userUnitsRepository = userUnitsRepository;
            _userOrganizationUnitRepository = userOrganizationUnitRepository;
            _roleRepository = roleRepository;
            _iQYWechatAppService = iQYWechatAppService;
            AppUrlService = NullAppUrlService.Instance;
            _cacheManager = cacheManager;
            _wechatConfig = wechatConfig;
            _userLogin = userLogin;
            _unionInfos = unionInfos;
        }

        public async Task<PagedResultDto<UserListDto>> GetUsers(GetUsersInput input)
        {
            var query = UserManager.Users
                .WhereIf(input.Role.HasValue, u => u.Roles.Any(r => r.RoleId == input.Role.Value))
                .WhereIf(
                    !input.Filter.IsNullOrWhiteSpace(),
                    u =>
                        u.Name.Contains(input.Filter) ||
                        u.Surname.Contains(input.Filter) ||
                        u.UserName.Contains(input.Filter) ||
                        u.EmailAddress.Contains(input.Filter)
                );

            if (!input.Permission.IsNullOrWhiteSpace())
            {
                query = (from user in query
                         join ur in _userRoleRepository.GetAll() on user.Id equals ur.UserId into urJoined
                         from ur in urJoined.DefaultIfEmpty()
                         join up in _userPermissionRepository.GetAll() on new { UserId = user.Id, Name = input.Permission } equals new { up.UserId, up.Name } into upJoined
                         from up in upJoined.DefaultIfEmpty()
                         join rp in _rolePermissionRepository.GetAll() on new { RoleId = ur.RoleId, Name = input.Permission } equals new { rp.RoleId, rp.Name } into rpJoined
                         from rp in rpJoined.DefaultIfEmpty()
                         where (up != null && up.IsGranted) || (up == null && rp != null)
                         group user by user into userGrouped
                         select userGrouped.Key);
            }

            var userCount = await query.CountAsync();

            var users = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
            await FillRoleNames(userListDtos);

            return new PagedResultDto<UserListDto>(
                userCount,
                userListDtos
                );
        }

        public async Task<FileDto> GetUsersToExcel()
        {
            var users = await UserManager.Users.ToListAsync();
            var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
            await FillRoleNames(userListDtos);

            return _userListExcelExporter.ExportToFile(userListDtos);
        }

        [AbpAuthorize(AppPermissions.Pages_Administration_Users_Create, AppPermissions.Pages_Administration_Users_Edit)]
        public async Task<GetUserForEditOutput> GetUserForEdit(NullableIdDto<long> input)
        {
            //Getting all available roles
            var userRoleDtos = await _roleManager.Roles
                .OrderBy(r => r.DisplayName)
                .Select(r => new UserRoleDto
                {
                    RoleId = r.Id,
                    RoleName = r.Name,
                    RoleDisplayName = r.DisplayName
                })
                .ToArrayAsync();

            var allOrganizationUnits = await _organizationUnitRepository.GetAllListAsync();
           
            var output = new GetUserForEditOutput
            {
                Roles = userRoleDtos,
                AllOrganizationUnits = ObjectMapper.Map<List<OrganizationUnitDto>>(allOrganizationUnits),
                MemberedOrganizationUnits = new List<string>(),

            };

            if (!input.Id.HasValue)
            {
                //Creating a new user
                output.User = new UserEditDto
                {
                    IsActive = true,
                    ShouldChangePasswordOnNextLogin = true,
                    IsTwoFactorEnabled = await SettingManager.GetSettingValueAsync<bool>(AbpZeroSettingNames.UserManagement.TwoFactorLogin.IsEnabled),
                    IsLockoutEnabled = await SettingManager.GetSettingValueAsync<bool>(AbpZeroSettingNames.UserManagement.UserLockOut.IsEnabled)
                };

                foreach (var defaultRole in await _roleManager.Roles.Where(r => r.IsDefault).ToListAsync())
                {
                    var defaultUserRole = userRoleDtos.FirstOrDefault(ur => ur.RoleName == defaultRole.Name);
                    if (defaultUserRole != null)
                    {
                        defaultUserRole.IsAssigned = true;
                    }
                }
              

            }
            else
            {
                //Editing an existing user
                var user = await UserManager.GetUserByIdAsync(input.Id.Value);

                output.User = ObjectMapper.Map<UserEditDto>(user);
                output.ProfilePictureId = user.ProfilePictureId;

                foreach (var userRoleDto in userRoleDtos)
                {
                    userRoleDto.IsAssigned = await UserManager.IsInRoleAsync(user, userRoleDto.RoleName);
                }

                var organizationUnits = await UserManager.GetOrganizationUnitsAsync(user);
                output.MemberedOrganizationUnits = organizationUnits.Select(ou => ou.Code).ToList();
                EntityDto<long> otherinput = new EntityDto<long>
                {
                    Id = long.Parse(input.Id.ToString())
                };

            }


          
            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_Administration_Users_ChangePermissions)]
        public async Task<GetUserPermissionsForEditOutput> GetUserPermissionsForEdit(EntityDto<long> input)
        {
            var user = await UserManager.GetUserByIdAsync(input.Id);
            var permissions = PermissionManager.GetAllPermissions();
            var grantedPermissions = await UserManager.GetGrantedPermissionsAsync(user);

            return new GetUserPermissionsForEditOutput
            {
                Permissions = ObjectMapper.Map<List<FlatPermissionDto>>(permissions).OrderBy(p => p.DisplayName).ToList(),
                GrantedPermissionNames = grantedPermissions.Select(p => p.Name).ToList()
            };
        }

        [AbpAuthorize(AppPermissions.Pages_Administration_Users_ChangePermissions)]
        public async Task ResetUserSpecificPermissions(EntityDto<long> input)
        {
            var user = await UserManager.GetUserByIdAsync(input.Id);
            await UserManager.ResetAllPermissionsAsync(user);
        }

        /// <summary>
        /// 修改用户权限
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Administration_Users_ChangePermissions)]
        public async Task UpdateUserPermissions(UpdateUserPermissionsInput input)
        {
            var user = await UserManager.GetUserByIdAsync(input.Id);
            var grantedPermissions = PermissionManager.GetPermissionsFromNamesByValidating(input.GrantedPermissionNames);
            await UserManager.SetGrantedPermissionsAsync(user, grantedPermissions);  
            
            //BackgroundJob.Schedule<IQYWechatAppService>(x => x.UpdateWeChatUser(new EntityDto<long> { Id= user.Id }), TimeSpan.FromMinutes(5));
        }

        public async Task CreateOrUpdateUser(CreateOrUpdateUserInput input)
        {
            if (input.User.Id.HasValue)
            {
                var inputDto = new EntityDto
                {
                    Id = Int32.Parse(input.User.Id.ToString())
                };
                await UpdateUserAsync(input);
            }
            else
            {
                await CreateUserAsync(input);
               
            }

            //企业微信新增修改用户第三方登录的验证表 
            var data = _userLogin.GetAll().AsNoTracking().Where(r => r.ProviderKey.Trim() == input.User.UserName.Trim() 
            && r.TenantId == AbpSession.TenantId).FirstOrDefault();
            data = data == null ? new UserLogin() : data;
            data.ProviderKey = input.User.UserName;
            data.TenantId = AbpSession.TenantId;
            data.UserId = UserManager.Users.Where(r => r.UserName == input.User.UserName.Trim() && r.TenantId == AbpSession.TenantId).FirstOrDefault().Id;
            data.LoginProvider = "Wechat";
            await _userLogin.InsertOrUpdateAsync(data);
            //钉钉
            data.LoginProvider = "DingTalk";
            await _userLogin.InsertOrUpdateAsync(data);

        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Administration_Users_Delete)]
        public async Task DeleteUser(EntityDto<long> input)
        {
            if (input.Id == AbpSession.GetUserId())
            {
                throw new UserFriendlyException(L("YouCanNotDeleteOwnAccount"));
            }

            var user = await UserManager.GetUserByIdAsync(input.Id);
            CheckErrors(await UserManager.DeleteAsync(user));

            //BackgroundJob.Schedule<IQYWechatAppService>(x => x.DeleteWeChatUser(new EntityDto<long> { Id= input.Id }), TimeSpan.FromMinutes(5));
        }

        public async Task UnlockUser(EntityDto<long> input)
        {
            var user = await UserManager.GetUserByIdAsync(input.Id);
            user.Unlock();
    
            //BackgroundJob.Schedule<IQYWechatAppService>(x => x.UpdateWeChatUser(new EntityDto<long> { Id= user.Id }), TimeSpan.FromMinutes(5));
         
        }

        /// <summary>
        /// 异步修改用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Administration_Users_Edit)]
        protected virtual async Task UpdateUserAsync(CreateOrUpdateUserInput input)
        {
            Debug.Assert(input.User.Id != null, "input.User.Id should be set.");

            var user = await UserManager.FindByIdAsync(input.User.Id.Value.ToString());

            //Update user properties
            ObjectMapper.Map(input.User, user); //Passwords is not mapped (see mapping configuration)

            if (input.SetRandomPassword)
            {
                input.User.Password = User.CreateRandomPassword();
            }

            if (!input.User.Password.IsNullOrEmpty())
            {
                await UserManager.InitializeOptionsAsync(AbpSession.TenantId);
                CheckErrors(await UserManager.ChangePasswordAsync(user, input.User.Password));
            }

            CheckErrors(await UserManager.UpdateAsync(user));

            //Update roles
            CheckErrors(await UserManager.SetRoles(user, input.AssignedRoleNames));

            //update organization units
            await UserManager.SetOrganizationUnitsAsync(user, input.OrganizationUnits.ToArray());

            if (input.SendActivationEmail)
            {
                user.SetNewEmailConfirmationCode();
                await _userEmailer.SendEmailActivationLinkAsync(
                    user,
                    AppUrlService.CreateEmailActivationUrlFormat(AbpSession.TenantId),
                    input.User.Password
                );
            }

          


            //BackgroundJob.Schedule<IQYWechatAppService>(x => x.UpdateWeChatUser(new EntityDto<long> { Id= user.Id }), TimeSpan.FromMinutes(5));
         
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Administration_Users_Create)]
        protected virtual async Task CreateUserAsync(CreateOrUpdateUserInput input)
        {
            if (AbpSession.TenantId.HasValue)
            {
                await _userPolicy.CheckMaxUserCountAsync(AbpSession.GetTenantId());
            }

            var user = ObjectMapper.Map<User>(input.User); //Passwords is not mapped (see mapping configuration)
            user.TenantId = AbpSession.TenantId;

            //Set password
            if (input.SetRandomPassword|| input.User.Password.IsNullOrEmpty())
            {
                input.User.Password = User.CreateRandomPassword();
            }
            else
            {
                await UserManager.InitializeOptionsAsync(AbpSession.TenantId);
                foreach (var validator in _passwordValidators)
                {
                    CheckErrors(await validator.ValidateAsync(UserManager, user, input.User.Password));
                }
            }

            user.Password = _passwordHasher.HashPassword(user, input.User.Password);
            user.ShouldChangePasswordOnNextLogin = input.User.ShouldChangePasswordOnNextLogin;

            //Assign roles
            user.Roles = new Collection<UserRole>();
            foreach (var roleName in input.AssignedRoleNames)
            {
                var role = await _roleManager.GetRoleByNameAsync(roleName);
                user.Roles.Add(new UserRole(AbpSession.TenantId, user.Id, role.Id));
            }

            CheckErrors(await UserManager.CreateAsync(user));
            await CurrentUnitOfWork.SaveChangesAsync(); //To get new user's Id.

            //Notifications
            await _notificationSubscriptionManager.SubscribeToAllAvailableNotificationsAsync(user.ToUserIdentifier());
            await _appNotifier.WelcomeToTheApplicationAsync(user);

            //Organization Units
            await UserManager.SetOrganizationUnitsAsync(user, input.OrganizationUnits.ToArray());
           
            //Send activation email
            if (input.SendActivationEmail)
            {
                user.SetNewEmailConfirmationCode();
                await _userEmailer.SendEmailActivationLinkAsync(
                    user,
                    AppUrlService.CreateEmailActivationUrlFormat(AbpSession.TenantId),
                    input.User.Password
                );
            }
        }

      
        
        private async Task FillRoleNames(List<UserListDto> userListDtos)
        {
            /* This method is optimized to fill role names to given list. */

            var userRoles = await _userRoleRepository.GetAll()
                .Where(userRole => userListDtos.Any(user => user.Id == userRole.UserId))
                .Select(userRole => userRole).ToListAsync();

            var distinctRoleIds = userRoles.Select(userRole => userRole.RoleId).Distinct();

            foreach (var user in userListDtos)
            {
                var rolesOfUser = userRoles.Where(userRole => userRole.UserId == user.Id).ToList();
                user.Roles = ObjectMapper.Map<List<UserListRoleDto>>(rolesOfUser);
            }

            var roleNames = new Dictionary<int, string>();
            foreach (var roleId in distinctRoleIds)
            {
                roleNames[roleId] = (await _roleManager.GetRoleByIdAsync(roleId)).DisplayName;
            }

            foreach (var userListDto in userListDtos)
            {
                foreach (var userListRoleDto in userListDto.Roles)
                {
                    userListRoleDto.RoleName = roleNames[userListRoleDto.RoleId];
                }

                userListDto.Roles = userListDto.Roles.OrderBy(r => r.RoleName).ToList();
            }
        }

        /// <summary>
        /// 绑定微信用户Id
        /// </summary>
        /// <param name="input">微信用户Id</param>
        public void BindOpenId(BindOpenIdInfo input)
        {
            if (_unionInfos.GetAll().Any(u => u.UnionId == input.UnionId))
            {
                WeChatUnionInfo info = _unionInfos.GetAll().Where(u => u.UnionId == input.UnionId).First();
                info.MiniProgramOpenId = input.MiniProgramOpenId.IsNullOrEmpty() ? info.MiniProgramOpenId : input.MiniProgramOpenId;
                info.PublicAccoutOpenId = input.PublicAccoutOpenId.IsNullOrEmpty() ? info.PublicAccoutOpenId : input.PublicAccoutOpenId;
                info.MiniGameOpenId = input.MiniGameOpenId.IsNullOrEmpty() ? info.MiniGameOpenId : input.MiniGameOpenId;
                info.UserId = AbpSession.UserId.HasValue ? AbpSession.UserId : info .UserId;
            }
            else
            {
                _unionInfos.Insert(new WeChatUnionInfo
                {
                    UnionId = input.UnionId,
                    MiniProgramOpenId = input.MiniGameOpenId,
                    MiniGameOpenId = input.MiniGameOpenId,
                    PublicAccoutOpenId = input.PublicAccoutOpenId,
                    UserId = AbpSession.UserId,
                });
            }
        }
    
    }
}
