using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.Organizations;
using Tensee.Banch.Authorization;
using Tensee.Banch.Organizations.Dto;
using System.Linq.Dynamic.Core;
using Abp.Extensions;
using Microsoft.EntityFrameworkCore;
using Tensee.Banch.Authorization.Roles;
using System.Collections.Generic;
using System;
using Tensee.Banch.QYWechat;
using Tensee.Banch.OrganizationUnits.Wechat;
using Tensee.Banch.Sessions;

namespace Tensee.Banch.Organizations
{
    [AbpAuthorize(AppPermissions.Pages_Administration_OrganizationUnits)]
    public class OrganizationUnitAppService : BanchAppServiceBase, IOrganizationUnitAppService
    {
        private readonly OrganizationUnitManager _organizationUnitManager;
        private readonly IRepository<OrganizationUnit, long> _organizationUnitRepository;
        private readonly IRepository<UserOrganizationUnit, long> _userOrganizationUnitRepository;
        private readonly IRepository<Organization, long> _organizationRepository;
        private readonly IRepository<UserRole, long> _userRoleRepository;
        private readonly IRepository<Role, int> _roleRepository;
        //  private readonly IRepository<UserUnits, long> _userUnitsRepository;
        private readonly IPoolAppService _poolService;
        private readonly IQYWechatAppService _iQYWechatAppService;
        private readonly IWechatAppService _iWechatAppService;
        private readonly ISessionAppService _sessionAppService;
        public OrganizationUnitAppService(
            OrganizationUnitManager organizationUnitManager,
            IRepository<OrganizationUnit, long> organizationUnitRepository,
            IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository,
            IRepository<Organization, long> organizationRepository,
            IRepository<UserRole, long> userRoleRepository,
            IRepository<Role, int> roleRepository,
            // IRepository<UserUnits, long> userUnitsRepository,
            IPoolAppService poolService,
            IQYWechatAppService iQYWechatAppService,
             IWechatAppService iWechatAppService,
             ISessionAppService sessionAppService
            )
        {
            _organizationUnitManager = organizationUnitManager;
            _organizationUnitRepository = organizationUnitRepository;
            _userOrganizationUnitRepository = userOrganizationUnitRepository;
            _organizationRepository = organizationRepository;
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
            //  _userUnitsRepository = userUnitsRepository;
            _poolService = poolService;
            _iQYWechatAppService = iQYWechatAppService;
            _iWechatAppService = iWechatAppService;
            _sessionAppService = sessionAppService;
        }

        /// <summary>
        /// 获取全部组织架构
        /// </summary>
        /// <returns></returns>
        public async Task<ListResultDto<OrganizationUnitDto>> GetOrganizationUnits()
        {

            var query =
                from ou in _organizationRepository.GetAll()
                join uou in _userOrganizationUnitRepository.GetAll() on ou.Id equals uou.OrganizationUnitId
                into g
                select new { ou, memberCount = g.Count() };

            var items = await query.ToListAsync();

            return new ListResultDto<OrganizationUnitDto>(
                items.Select(item =>
                {
                    var dto = ObjectMapper.Map<OrganizationUnitDto>(item.ou);
                    dto.MemberCount = item.memberCount;
                    return dto;
                }).ToList());
        }


        public async Task<ListResultDto<OrganizationUnitDto>> GetUserOrganizationUnits()
        {
            var user = await _sessionAppService.GetCurrentLoginInformations();
           // var userOrganizationUnitsData = await _userOrganizationUnitRepository.GetAll().AsNoTracking().Where(r => r.UserId == user.User.Id).ToListAsync();
            List<OrganizationUnitDto> result = new List<OrganizationUnitDto>();
            Logger.Info("登录的用户名: " + user.User.UserName+"    名字："+user.User.Name);

            //foreach (var item in userOrganizationUnitsData)
            //{
            //    var OrganizationData = await _organizationUnitRepository.GetAll().AsNoTracking()
            //        .Where(r => r.Id == item.OrganizationUnitId).FirstOrDefaultAsync();
            //    if (OrganizationData != null)
            //    {
            //        var data = _organizationUnitRepository.GetAll().AsNoTracking()
            //            .Where(r => r.Code == OrganizationData.Code || r.Code.Contains(OrganizationData.Code + ","));
            //        foreach (var dataItem in data)
            //        {
            //            OrganizationUnitDto dto = new OrganizationUnitDto
            //            {
            //                Id = dataItem.Id,
            //                DisplayName = dataItem.DisplayName,
            //                Code = dataItem.Code
            //            };
            //            result.Add(dto);
            //        }
            //    }
            //}


            var data = from a in _userOrganizationUnitRepository.GetAll().AsNoTracking()
                       join b in _organizationRepository.GetAll().AsNoTracking()
                       on a.OrganizationUnitId equals b.Id
                       where a.UserId == user.User.Id
                       select b;

            foreach (var item in data)
            {
                var itData = _organizationRepository.GetAll().AsNoTracking().Where(r => r.Code == item.Code || r.Code.Contains(item.Code + ","));
                foreach (var itemc in itData)
                {
                    OrganizationUnitDto dto = new OrganizationUnitDto
                    {
                        Id = itemc.Id,
                        DisplayName = itemc.DisplayName,
                        Code = itemc.Code
                    };
                    result.Add(dto);
                }
            }
            return new ListResultDto<OrganizationUnitDto>(result);
        }


        /// <summary>
        /// 获取组织架构人员
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<OrganizationUnitUserListDto>> GetOrganizationUnitUsers(GetOrganizationUnitUsersInput input)
        {
            var query = from uou in _userOrganizationUnitRepository.GetAll()
                        join ou in _organizationUnitRepository.GetAll() on uou.OrganizationUnitId equals ou.Id
                        join user in UserManager.Users on uou.UserId equals user.Id
                        join userrole in _userRoleRepository.GetAll() on user.Id equals userrole.UserId
                        join role in _roleRepository.GetAll() on userrole.RoleId equals role.Id
                        where uou.OrganizationUnitId == input.Id
                        select new { uou, user, role, ou };

            var totalCount = await query.CountAsync();
            var items = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();

            return new PagedResultDto<OrganizationUnitUserListDto>(
                totalCount,
                items.Select(item =>
                {
                    var dto = ObjectMapper.Map<OrganizationUnitUserListDto>(item.user);
                    dto.AddedTime = item.uou.CreationTime;
                    dto.DisplayName = item.role.DisplayName;
                    dto.OrganizationDisplayName = item.ou.DisplayName;
                    return dto;
                }).ToList());
        }

        /// <summary>
        /// 修改组织架构人员信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task UpdateOrganizationUnitUsers(UpdateOrganizationUnitUsersInput input)
        {
            //  var user = await _userUnitsRepository.GetAsync(input.UserId.Value);
            //  var user = UserManager.Users.Where(r => r.Id == input.UserId.Value);
            var role = await _userRoleRepository.GetAll().Where(u => u.UserId == input.UserId.Value).FirstOrDefaultAsync();
            var organization = await _userOrganizationUnitRepository.GetAll().Where(u => u.UserId == input.UserId.Value).FirstOrDefaultAsync();
            //user.Name = input.Name;
            //user.Sex = input.Sex;
            //user.LevelDesc = input.LevelDesc;
            //user.Address = input.Address;
            //user.PhoneNumber = input.PhoneNumber;
            role.RoleId = input.RoleId;
            organization.OrganizationUnitId = input.OrganizationUnitId;


            // await _userUnitsRepository.UpdateAsync(user);
            await _userRoleRepository.UpdateAsync(role);
            await _userOrganizationUnitRepository.UpdateAsync(organization);

            //BackgroundJob.Schedule<IQYWechatAppService>(x => x.UpdateWeChatUser(new EntityDto<long> { Id= user.Id}), TimeSpan.FromMinutes(5));

        }



        public async Task<OrganizationUnitOutput> GetOrganizationUnitById(EntityDto input)
        {
            var organData =// _organizationRepository.GetAll().Where(r=>r.Id == input.Id).FirstOrDefault();
               (from a in _organizationRepository.GetAll().AsNoTracking()
                where a.Id == input.Id
                select new OrganizationUnitDto
                {
                    ParentId = a.ParentId,
                    Code = a.Code,
                    DisplayName = a.DisplayName,
                    // MemberCount = a.MemberCount,
                    Depth = a.Depth,
                    Number = a.Number,
                    Leader = a.Leader,
                    IsShop = a.IsShop,
                    Status = a.Status

                }).FirstOrDefault();

           ;

            //var wechatData = _iWechatAppService.GetWechatConfigAll();
            return new OrganizationUnitOutput
            {

            };
        }


        /// <summary>
        /// 创建组织架构
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Administration_OrganizationUnits_ManageOrganizationTree)]
        //   public async Task<OrganizationUnitDto> CreateOrganizationUnit(CreateOrganizationUnitInput input)
        public async Task<OrganizationUnitDto> CreateOrganizationUnit(OrganizationUnitOutput input)
        {
            #region 111
            //var organizationUnit = new OrganizationUnit(AbpSession.TenantId, input.DisplayName, input.ParentId);

            //await _organizationUnitManager.CreateAsync(organizationUnit);
            //await CurrentUnitOfWork.SaveChangesAsync();
            ///============================================================
            //return ObjectMapper.Map<OrganizationUnitDto>(organizationUnit);
            //var parent = _organizationRepository.GetAll().Where(o => o.Id == input.ParentId).FirstOrDefault();
            //var organization = new Organization()
            //{
            //    TenantId = AbpSession.TenantId,
            //    DisplayName = input.DisplayName,
            //    ParentId = input.ParentId,
            //    Leader = input.Leader,
            //    IsShop = input.IsShop,
            //    Status = input.Status
            //};
            //if (parent != null)
            //{
            //    var temp = parent.Number + "," + parent.Id.ToString();
            //    organization.Number = temp;
            //}
            //else
            //{
            //    organization.Number = "0";
            //}
            //await _organizationUnitManager.CreateAsync(organization);
            //await CurrentUnitOfWork.SaveChangesAsync();
            // return ObjectMapper.Map<OrganizationUnitDto>(organization);
            //=============================== 

            #endregion

            var OrganizationUnit = input.OrganizationUnit;
            var parent = _organizationRepository.GetAll().Where(o => o.Id == OrganizationUnit.ParentId).FirstOrDefault();
            var organization = new Organization()
            {
                TenantId = AbpSession.TenantId,
                DisplayName = OrganizationUnit.DisplayName,
                ParentId = OrganizationUnit.ParentId,
                Leader = OrganizationUnit.Leader,
                IsShop = OrganizationUnit.IsShop,
                Status = OrganizationUnit.Status
            };
            if (parent != null)
            {
                var temp = parent.Number + "," + parent.Id.ToString();
                organization.Number = temp;
            }
            else
            {
                organization.Number = "0";
            }
            //    var  data =   _organizationUnitManager.CreateAsync(organization);
            await _organizationUnitManager.CreateAsync(organization);
            await CurrentUnitOfWork.SaveChangesAsync();
            var data = _organizationUnitRepository.GetAll().Where(t => (t.DisplayName == input.OrganizationUnit.DisplayName)).FirstOrDefault();
            int id = Convert.ToInt32(data.Id);
       
            return OrganizationUnit;

        }

        /// <summary>
        /// 修改组织架构
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Administration_OrganizationUnits_ManageOrganizationTree)]
        public async Task<OrganizationUnitDto> UpdateOrganizationUnit(OrganizationUnitOutput input)
        {
            var organizationUnits = input.OrganizationUnit;
            var organizationUnit = await _organizationRepository.GetAsync(organizationUnits.Id);
            var parent = _organizationRepository.GetAll().Where(o => o.Id == organizationUnits.ParentId).FirstOrDefault();
            if (parent != null)
            {
                var temp = parent.Number + "," + parent.Id.ToString();
                organizationUnit.Number = temp;
            }
            else
            {
                organizationUnit.Number = "0";
            }
            organizationUnit.DisplayName = organizationUnits.DisplayName;
            organizationUnit.Leader = organizationUnits.Leader;
            organizationUnit.IsShop = organizationUnits.IsShop;
            organizationUnit.Status = organizationUnits.Status;
            await _organizationUnitManager.UpdateAsync(organizationUnit);

       

            return await CreateOrganizationUnitDto(organizationUnit);
        }

        /// <summary>
        /// 移动组织架构
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Administration_OrganizationUnits_ManageOrganizationTree)]
        public async Task<OrganizationUnitDto> MoveOrganizationUnit(MoveOrganizationUnitInput input)
        {
            var parent = _organizationRepository.GetAll().Where(o => o.Id == input.NewParentId).FirstOrDefault();
            var organizationUnit = await _organizationRepository.GetAsync(input.Id);

            if (parent != null)
            {
                var temp = parent.Number + "," + parent.Id.ToString();
                organizationUnit.Number = temp;
            }
            else
            {
                organizationUnit.Number = "0";
            }
            await _organizationUnitManager.MoveAsync(input.Id, input.NewParentId);


            //WeChatOrganization wechat = new WeChatOrganization
            //{
            //    name = organizationUnit.DisplayName,
            //    parentid = organizationUnit.ParentId,
            //    order = 1,
            //    id = organizationUnit.Id,
            //    value = "Mail"
            //};
            //BackgroundJob.Schedule<IQYWechatAppService>(x => x.UpdateWeChatOrganization(wechat), TimeSpan.FromMinutes(5));
            return await CreateOrganizationUnitDto(
                await _organizationRepository.GetAsync(input.Id)
                );
        }

        /// <summary>
        /// 删除组织架构
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Administration_OrganizationUnits_ManageOrganizationTree)]
        public async Task DeleteOrganizationUnit(EntityDto<long> input)
        {
            //DeleteWeChatOrganizationInput wechat = new DeleteWeChatOrganizationInput
            //{
            //    Id = input.Id,
            //    value = "Mail"
            //};
            //BackgroundJob.Schedule<IQYWechatAppService>(x => x.DeleteWeChatOrganization(wechat), TimeSpan.FromMinutes(5));
            await _organizationUnitManager.DeleteAsync(input.Id);

        }

        /// <summary>
        /// 组织架构删除用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Administration_OrganizationUnits_ManageMembers)]
        public async Task RemoveUserFromOrganizationUnit(UserToOrganizationUnitInput input)
        {
            await UserManager.RemoveFromOrganizationUnitAsync(input.UserId, input.OrganizationUnitId);

            //BackgroundJob.Schedule<IQYWechatAppService>(x => x.UpdateWeChatUser(new EntityDto<long> { Id= input.UserId }), TimeSpan.FromMinutes(5));

        }

        /// <summary>
        /// 组织架构添加用户  批量
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Administration_OrganizationUnits_ManageMembers)]
        public async Task AddUsersToOrganizationUnit(UsersToOrganizationUnitInput input)
        {

            foreach (var userId in input.UserIds)
            {
                await UserManager.AddToOrganizationUnitAsync(userId, input.OrganizationUnitId);


                //BackgroundJob.Schedule<IQYWechatAppService>(x => x.UpdateWeChatUser(new EntityDto<long> { Id= userId }), TimeSpan.FromMinutes(5));

            }
        }


        /// <summary>
        /// 查找用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(AppPermissions.Pages_Administration_OrganizationUnits_ManageMembers)]
        public async Task<PagedResultDto<NameValueDto>> FindUsers(FindOrganizationUnitUsersInput input)
        {

            var query = CreateFindUsersQuery(input);

            var userCount = await query.CountAsync();
            var users = await query
                .OrderBy(u => u.Name)
                .ThenBy(u => u.Surname)
                .PageBy(input)
                .ToListAsync();

            return new PagedResultDto<NameValueDto>(
                userCount,
                users.Select(u =>
                    new NameValueDto(
                        u.FullName + " (" + u.EmailAddress + ")",
                        u.Id.ToString()
                    )
                ).ToList()
            );
        }
        private IQueryable<Authorization.Users.User> CreateFindUsersQuery(FindOrganizationUnitUsersInput input)
        {
            var userIdsInOrganizationUnit = _userOrganizationUnitRepository.GetAll()
                .Where(uou => uou.OrganizationUnitId == input.OrganizationUnitId)
                .Select(uou => uou.UserId);

            var query = UserManager.Users
                .Where(u => !userIdsInOrganizationUnit.Contains(u.Id))
                .WhereIf(
                    !input.Filter.IsNullOrWhiteSpace(),
                    u =>
                        u.Name.Contains(input.Filter) ||
                        u.Surname.Contains(input.Filter) ||
                        u.UserName.Contains(input.Filter) ||
                        u.EmailAddress.Contains(input.Filter)
                );
            return query;
        }

        public async Task<PagedResultDto<OrganizationUnitUserListDto>> FindUsersNew(FindOrganizationUnitUsersInput input)
        {
            var query = CreateFindUsersQuery(input);

            var userCount = await query.CountAsync();
            var users = await query
                .OrderBy(u => u.Name)
                .ThenBy(u => u.Surname)
                .PageBy(input)
                .ToListAsync();

            return new PagedResultDto<OrganizationUnitUserListDto>(

                userCount,
                users.Select(u =>
                ObjectMapper.Map<OrganizationUnitUserListDto>(u)).ToList()
            );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="organizationUnit"></param>
        /// <returns></returns>
        private async Task<OrganizationUnitDto> CreateOrganizationUnitDto(Organization organizationUnit)
        {
            var dto = ObjectMapper.Map<OrganizationUnitDto>(organizationUnit);
            dto.MemberCount = await _userOrganizationUnitRepository.CountAsync(uou => uou.OrganizationUnitId == organizationUnit.Id);
            return dto;
        }

        public async Task<GetOrganizationUnitsAndUsersOutput[]> GetOrganizationUnitsAndUsers()
        {
            List<GetOrganizationUnitsAndUsersOutput> output = new List<GetOrganizationUnitsAndUsersOutput>();
            var data = _organizationUnitRepository.GetAll().Where(r => r.ParentId == null);
            foreach (var item in data)
            {
               
               //获取组织架构下的人员
               var userData = (from a in UserManager.Users
                                join b in _userOrganizationUnitRepository.GetAll().AsNoTracking() on a.Id equals b.UserId
                                where b.OrganizationUnitId == item.Id
                                select new OrganizationUsers
                                {
                                    UserId = int.Parse(a.Id.ToString()),
                                    UserName = a.UserName,
                                    Name = a.Name
                                }).ToList();

                var da = new GetOrganizationUnitsAndUsersOutput
                {
                    OrganizationUsers = userData,
                    OrganizationId = int.Parse(item.Id.ToString()),
                    OrganizationName = item.DisplayName
                };
                da.Children = GetOrganizationUnitsAndUsersChildren(da, new List<GetOrganizationUnitsAndUsersOutput>()).ToArray();
                output.Add(da);
                
            }

            return output.ToArray();
        }


        private List<GetOrganizationUnitsAndUsersOutput> GetOrganizationUnitsAndUsersChildren(GetOrganizationUnitsAndUsersOutput item, List<GetOrganizationUnitsAndUsersOutput> output)
        {
          

            var data = _organizationUnitRepository.GetAll().Where(r => r.ParentId == item.OrganizationId);
          
         
            foreach (var itemc in data)
            {
                GetOrganizationUnitsAndUsersOutput list = new GetOrganizationUnitsAndUsersOutput();

                var userData = (from a in UserManager.Users
                                join b in _userOrganizationUnitRepository.GetAll().AsNoTracking() on a.Id equals b.UserId
                                where b.OrganizationUnitId == itemc.Id
                                select new OrganizationUsers
                                {
                                    UserId = int.Parse(a.Id.ToString()),
                                    UserName = a.UserName,
                                    Name = a.Name
                                }).ToList();
                list.OrganizationId = int.Parse(itemc.Id.ToString());
                list.OrganizationName = itemc.DisplayName;
                list.OrganizationUsers = userData;
                list.Children = GetOrganizationUnitsAndUsersChildren(list, output).ToArray();
                output.Add(list);

            }


            return output;
        }


    }
}