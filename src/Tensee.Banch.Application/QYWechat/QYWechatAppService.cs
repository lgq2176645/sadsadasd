using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Runtime.Caching;
using Senparc.Weixin;
using Senparc.Weixin.Entities;
using Senparc.Weixin.Helpers;
using Senparc.Weixin.HttpUtility;
using Senparc.Weixin.Work;
using Senparc.Weixin.Work.AdvancedAPIs.MailList;
using Senparc.Weixin.Work.AdvancedAPIs.Mass;
using System.Collections.Generic;
using Tensee.Banch.Organizations.Dto;
using Tensee.Banch.QYWechat.Dto;
using System.Linq;
using System.Threading.Tasks;
using System;
using Senparc.Weixin.Work.AdvancedAPIs.OAuth2;
using Tensee.Banch.Url;
using Tensee.Banch.Authorization;
using Abp.Authorization.Users;
using Tensee.Banch.Authorization.Users;
using Tensee.Banch.Authorization.Impersonation;
using Tensee.Banch.Authorization.Accounts;
using Abp.UI;
using Abp.MultiTenancy;
using System.Text;
using Abp.Zero.Configuration;
using Tensee.Banch.Identity;
using Tensee.Banch.Authorization.Roles;
using Tensee.Banch.QYWechat.Dto.Agent;
using Senparc.Weixin.Work.AdvancedAPIs.Media;
using System.IO;
using Senparc.Weixin.Work.AdvancedAPIs;
using Microsoft.AspNetCore.Hosting;
using Abp.Organizations;
using Microsoft.EntityFrameworkCore;
using Senparc.Weixin.Work.AdvancedAPIs.Asynchronous;
using Senparc.Weixin.CommonAPIs;
using Senparc.Weixin.Work.AdvancedAPIs.OaDataOpen;
using Senparc.Weixin.MP.Entities;
using Senparc.CO2NET.Extensions;
using Senparc.CO2NET.Helpers.Serializers;

namespace Tensee.Banch.QYWechat
{

    //public class GetWechatLoginUserIdByCodeOutput
    //{
    //    public string Token { get; set; }
    //}
    public class QYWechatAppService : BanchAppServiceBase, IQYWechatAppService
    {

        private readonly ICacheManager _cacheManager;
        private readonly IRepository<WechatConfig> _wechatConfig;
        private readonly IWebUrlService _webUrlService;
        private readonly IImpersonationManager _impersonationManager;
        private readonly IAccountAppService _iAccountAppService;
        private readonly LogInManager _logInManager;
        private readonly AbpLoginResultTypeHelper _abpLoginResultTypeHelper;
        private readonly ITenantCache _tenantCache;
        private readonly IUserManagementConfig _iUserManagementConfig;
        private readonly UserManager _userManager;
        private readonly SignInManager _signInManager;
      //  private readonly IRepository<UserUnits, long> _userUnitsRepository;
        private readonly IRepository<UserOrganizationUnit, long> _userOrganizationUnitRepository;
        private readonly IRepository<UserRole, long> _userRoleRepository;
        private readonly IRepository<Role, int> _roleRepository;
        private readonly IHostingEnvironment _iHostingEnvironment;
        private readonly IRepository<OrganizationUnit, long> _organizationUnitRepository;
        private readonly RoleManager _roleManager;
        public QYWechatAppService(ICacheManager cacheManager,
                                  IRepository<WechatConfig> wechatConfig,
                                  IWebUrlService webUrlService,
                                  IImpersonationManager impersonationManager,
                                  IAccountAppService iAccountAppService,
                                  LogInManager logInManager,
                                  AbpLoginResultTypeHelper abpLoginResultTypeHelper,
                                  ITenantCache tenantCache,
                                  UserManager userManager,
                                  SignInManager signInManager,
                                //  IRepository<UserUnits, long> userUnitsRepository,
                                  IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository,
                                  IRepository<UserRole, long> userRoleRepository,
                                  IRepository<Role, int> roleRepository,
                                   IHostingEnvironment iHostingEnvironment,
                                   IRepository<OrganizationUnit, long> organizationUnitRepository,
                                   RoleManager roleManager
                                   
                                )
        {
            _cacheManager = cacheManager;
            _wechatConfig = wechatConfig;
            _webUrlService = webUrlService;
            _impersonationManager = impersonationManager;
            _iAccountAppService = iAccountAppService;
            _logInManager = logInManager;
            _abpLoginResultTypeHelper = abpLoginResultTypeHelper;
            _tenantCache = tenantCache;
            _userManager = userManager;
            _signInManager = signInManager;
          //  _userUnitsRepository = userUnitsRepository;
            _userOrganizationUnitRepository = userOrganizationUnitRepository;
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
            _iHostingEnvironment = iHostingEnvironment;
            _organizationUnitRepository = organizationUnitRepository;
            _roleManager = roleManager;
        }




        #region Mail   通讯录

        #region 员工


        /// <summary>
        /// 获取员工信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<GetMemberResult> GetMember(DeleteWeChatUserInput input)
        {
            string token = await _cacheManager.GetCache("CacheName").Get("Mail", () => GetToken("Mail"));
            //如果因为没配置好企业微信ID等获取不到token 直接返回FALSE
            if (string.IsNullOrWhiteSpace(token))
            {
                return new GetMemberResult {errcode=ReturnCode_Work.系统繁忙, errmsg="未获取到token" };
            }
            return ApiHandlerWapper.TryCommonApi(accessToken =>
              {
                  var url = string.Format(Config.ApiWorkHost + "/cgi-bin/user/get?access_token={0}&userid={1}", accessToken.AsUrlData(), input.userId.ToString());

                  return Get.GetJson<GetMemberResult>(url);
              }, token);

        }

      

        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<WorkJsonResult> DeleteMember(EntityDto<long> input)
        {
            //获取缓存里的token
            string token = await _cacheManager.GetCache("CacheName").Get("Mail", () => GetToken("Mail"));
            //如果因为没配置好企业微信ID等获取不到token 直接返回FALSE
            if (string.IsNullOrWhiteSpace(token))
            {
                return  new WorkJsonResult { errcode = ReturnCode_Work.系统繁忙, errmsg = "未获取到token" };
            }
            return await ApiHandlerWapper.TryCommonApiAsync(async accessToken =>
            {
                var url = string.Format(Config.ApiWorkHost + "/cgi-bin/user/delete?access_token={0}&userid={1}", accessToken.AsUrlData(), input.Id);
                return await Get.GetJsonAsync<WorkJsonResult>(url);
            }, token);
        }

        /// <summary>
        /// 批量删除员工
        /// </summary>
        /// <returns></returns>
        public async Task<WorkJsonResult> BatchDeleteMember(BatchDeleteWeChatUserInput input)
        {
            //获取缓存里的token
            string token = await _cacheManager.GetCache("CacheName").Get("Mail", () => GetToken("Mail"));
            //如果因为没配置好企业微信ID等获取不到token 直接返回FALSE
            if (string.IsNullOrWhiteSpace(token))
            {
                return new WorkJsonResult { errcode = ReturnCode_Work.系统繁忙, errmsg = "未获取到token" };

            }
            return await ApiHandlerWapper.TryCommonApiAsync(async accessToken =>
            {
                var url = string.Format(Config.ApiWorkHost + "/cgi-bin/user/batchdelete?access_token={0}", accessToken.AsUrlData());

                var data = new
                {
                    useridlist = input.userIdList
                };

                return await CommonJsonSend.SendAsync<WorkJsonResult>(null, url, data, CommonJsonSendType.POST, Config.TIME_OUT);
            }, token);

        }

        /// <summary>
        /// <summary>
        /// 获取部门成员
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<GetDepartmentMemberResult> GetDepartmentMember(GetDepartmentWeChatUserInput input)
        {
            //获取缓存里的token
            string token = await _cacheManager.GetCache("CacheName").Get("Mail", () => GetToken("Mail"));
            //如果因为没配置好企业微信ID等获取不到token 直接返回FALSE
            if (string.IsNullOrWhiteSpace(token))
            {
                return new GetDepartmentMemberResult { errcode = ReturnCode_Work.系统繁忙, errmsg = "未获取到token" };
            }
            return await ApiHandlerWapper.TryCommonApiAsync(async accessToken =>
            {
                var url = string.Format(Config.ApiWorkHost + "/cgi-bin/user/simplelist?access_token={0}&department_id={1}&fetch_child={2}", accessToken.AsUrlData(), input.departmentId, input.fetchChild);

                return await Get.GetJsonAsync<GetDepartmentMemberResult>(url);
            }, token);

        }

        /* <param name="status">0获取全部员工，1获取已关注成员列表，2获取禁用成员列表，4获取未关注成员列表。status可叠加</param>*/
        /// <summary>
        /// 获取部门成员(详情)【QY移植修改】
        /// </summary>
        /// <param name="accessTokenOrAppKey">调用接口凭证（AccessToken）或AppKey（根据AccessTokenContainer.BuildingKey(corpId, corpSecret)方法获得）</param>
        /// <param name="departmentId">获取的部门id</param>
        /// <param name="fetchChild">（）1/0：是否递归获取子部门下面的成员</param>
        /// <param name="maxJsonLength">设置 JavaScriptSerializer 类接受的 JSON 字符串的最大长度</param>
        /// <remarks>
        /// 2016-05-03：Zeje添加参数maxJsonLength：企业号通讯录扩容后，存在Json长度不够的情况。
        /// </remarks>
        /// <returns></returns>
        public async Task<GetDepartmentMemberInfoResult> GetDepartmentMemberInfo(GetDepartmentWeChatUserInput input)
        {


            //获取缓存里的token
            string token = await _cacheManager.GetCache("CacheName").Get("Mail", () => GetToken("Mail"));
            //如果因为没配置好企业微信ID等获取不到token 直接返回FALSE
            if (string.IsNullOrWhiteSpace(token))
            {
                return new GetDepartmentMemberInfoResult { errcode = ReturnCode_Work.系统繁忙, errmsg = "未获取到token" };
            }

            return await ApiHandlerWapper.TryCommonApiAsync(async accessToken =>
            {
                //var url = string.Format(Config.ApiWorkHost + "/cgi-bin/user/list?access_token={0}&department_id={1}&fetch_child={2}&status={3}", accessToken.AsUrlData(), departmentId, fetchChild, status);

                var url = string.Format(Config.ApiWorkHost + "/cgi-bin/user/list?access_token={0}&department_id={1}&fetch_child={2}", accessToken.AsUrlData(), input.departmentId, input.fetchChild);

                return await Get.GetJsonAsync<GetDepartmentMemberInfoResult>(url);
            }, token);
        }


        #endregion

        #region 部门

        /// <summary>
        /// 新增微信组织架构
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async  Task<CreateDepartmentResult> CreateDepartment(WeChatOrganization data)
        {
            //获取缓存里的token
            string token = await _cacheManager.GetCache("CacheName").Get(data.value, () => GetToken(data.value));

            //如果因为没配置好企业微信ID等获取不到token 直接返回FALSE
            if (string.IsNullOrWhiteSpace(token))
            {
                return new CreateDepartmentResult { errcode=ReturnCode_Work.系统繁忙, errmsg="未获取到token"};
            }
            return await ApiHandlerWapper.TryCommonApiAsync(async accessToken =>
            {
                var url = string.Format(Config.ApiWorkHost + "/cgi-bin/department/create?access_token={0}", accessToken.AsUrlData());
                JsonSetting jsonSetting = new JsonSetting(true);
                var redata = new
                {
                    data.name,
                    parentid = data.parentid == null ? 1 : data.parentid,
                    data.order,
                    data.id
                };
                return await CommonJsonSend.SendAsync<CreateDepartmentResult>(accessToken, url, redata, CommonJsonSendType.POST, Config.TIME_OUT, jsonSetting: jsonSetting);
            }, token);

        }

        /// <summary>
        /// 修改部门信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<WorkJsonResult> UpdateDepartment(WeChatOrganization data)
        {
            //获取缓存里的token
            string token = await _cacheManager.GetCache("CacheName").Get(data.value, () => GetToken(data.value));
            //如果因为没配置好企业微信ID等获取不到token 直接返回FALSE
            if (string.IsNullOrWhiteSpace(token))
            {
                return new WorkJsonResult { errcode = ReturnCode_Work.系统繁忙, errmsg = "未获取到token" };
            }
            return ApiHandlerWapper.TryCommonApi(accessToken =>
            {
                var url = string.Format(Config.ApiWorkHost + "/cgi-bin/department/update?access_token={0}", accessToken.AsUrlData());
                JsonSetting jsonSetting = new JsonSetting(true);
                var redata = new
                {
                    data.name,
                    parentid = data.parentid == null ? 1 : data.parentid,
                    data.order,
                    data.id

                };
                return CommonJsonSend.Send<WorkJsonResult>(null, url, redata, CommonJsonSendType.POST, Config.TIME_OUT, jsonSetting: jsonSetting);
            }, token);

        }

        /// <summary>
        /// 删除部门（注：不能删除根部门；不能删除含有子部门、成员的部门）
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<WorkJsonResult> DeleteDepartment(DeleteWeChatOrganizationInput input)
        {
            //获取缓存里的token
            string token = await _cacheManager.GetCache("CacheName").Get("Mail", () => GetToken("Mail"));
            //如果因为没配置好企业微信ID等获取不到token 直接返回FALSE
            if (string.IsNullOrWhiteSpace(token))
            {
                return new WorkJsonResult { errcode = ReturnCode_Work.系统繁忙, errmsg = "未获取到token" };

            }
            return await ApiHandlerWapper.TryCommonApiAsync(async accessToken =>
            {
                var url = string.Format(Config.ApiWorkHost + "/cgi-bin/department/delete?access_token={0}&id={1}", accessToken.AsUrlData(), input.Id.ToString());

                return await Get.GetJsonAsync<WorkJsonResult>(url);
            }, token);

        }


        /// <summary>
        /// 获取部门列表 部门id。获取指定部门及其下的子部门。 如果不填，默认获取全量组织架构
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<GetDepartmentListResult> GetDepartmentList(GetWeChatOrganizationListInput input)
        {
            //获取缓存里的token
            string token = await _cacheManager.GetCache("CacheName").Get(input.value, () => GetToken(input.value));
            //如果因为没配置好企业微信ID等获取不到token 直接返回FALSE
            if (string.IsNullOrWhiteSpace(token))
            {
                return new GetDepartmentListResult { errcode = ReturnCode_Work.系统繁忙, errmsg = "未获取到token" };
            }
            return await ApiHandlerWapper.TryCommonApiAsync(async accessToken =>
            {
                var url = string.Format(Config.ApiWorkHost + "/cgi-bin/department/list?access_token={0}", accessToken.AsUrlData());

                if (input.id.HasValue)
                {
                    url += string.Format("&id={0}", input.id.Value);
                }

                return await Get.GetJsonAsync<GetDepartmentListResult>(url);
            }, token);
        }




        #endregion


        #region 标签管理   角色

        /// <summary>
        /// 创建标签
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CreateTagResult> CreateTag(CreateTagInput input)
        {
            string token = await _cacheManager.GetCache("CacheName").Get("Mail", () => GetToken("Mail"));
            //如果因为没配置好企业微信ID等获取不到token 直接返回FALSE
            if (string.IsNullOrWhiteSpace(token))
            {
                return new CreateTagResult { errcode = ReturnCode_Work.系统繁忙, errmsg = "未获取到token" };
            }
           return await ApiHandlerWapper.TryCommonApiAsync(async accessToken =>
            {
                var url = Config.ApiWorkHost + "/cgi-bin/tag/create?access_token={0}";
                JsonSetting jsonSetting = new JsonSetting(true);
                var datare = input;
                return await CommonJsonSend.SendAsync<CreateTagResult>(accessToken, url, datare, CommonJsonSendType.POST, Config.TIME_OUT, jsonSetting: jsonSetting);
            }, token);
          ;
        }

        /// <summary>
        /// 修改标签
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<WorkJsonResult> UpdateTag(CreateTagInput input)
        {
            string token = await _cacheManager.GetCache("CacheName").Get("Mail", () => GetToken("Mail"));
            //如果因为没配置好企业微信ID等获取不到token 直接返回FALSE
            if (string.IsNullOrWhiteSpace(token))
            {
                return new WorkJsonResult { errcode = ReturnCode_Work.系统繁忙, errmsg = "未获取到token" };
            }
            return await ApiHandlerWapper.TryCommonApiAsync(async accessToken =>
            {
                var url = Config.ApiWorkHost + "/cgi-bin/tag/update?access_token={0}";
                JsonSetting jsonSetting = new JsonSetting(true);
                var datare = input;
                return await CommonJsonSend.SendAsync<WorkJsonResult>(accessToken, url, datare, CommonJsonSendType.POST, Config.TIME_OUT, jsonSetting: jsonSetting);
            }, token);
            
        }

        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<WorkJsonResult> DeleteTag(EntityDto<string> input)
        {
            string token = await _cacheManager.GetCache("CacheName").Get("Mail", () => GetToken("Mail"));
            //如果因为没配置好企业微信ID等获取不到token 直接返回FALSE
            if (string.IsNullOrWhiteSpace(token))
            {
                return new WorkJsonResult { errcode = ReturnCode_Work.系统繁忙, errmsg = "未获取到token" };

            }

            return await ApiHandlerWapper.TryCommonApiAsync(async accessToken =>
            {
                var url = string.Format(Config.ApiWorkHost + "/cgi-bin/tag/delete?access_token={0}&tagid={1}", accessToken.AsUrlData(), input.Id.ToString());

                return await Get.GetJsonAsync<WorkJsonResult>(url);
            }, token);
          
        }

        /// <summary>
        /// 获取标签成员
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public  async Task<GetTagMemberResult> GetTagMember(EntityDto<string> input)
        {
            string token = await _cacheManager.GetCache("CacheName").Get("Mail", () => GetToken("Mail"));
            //如果因为没配置好企业微信ID等获取不到token 直接返回FALSE
            if (string.IsNullOrWhiteSpace(token))
            {
                return new GetTagMemberResult { errcode = ReturnCode_Work.系统繁忙, errmsg = "未获取到token" };
            }

            return await ApiHandlerWapper.TryCommonApiAsync(async accessToken =>
            {
                var url = string.Format(Config.ApiWorkHost + "/cgi-bin/tag/get?access_token={0}&tagid={1}", accessToken.AsUrlData(), input.Id.ToString());

                return await Get.GetJsonAsync<GetTagMemberResult>(url);
            }, token);

        }

        /// <summary>
        /// 增加标签成员
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<AddTagMemberResult> AddTagMember(CreateTagUsersInput input)
        {
            string token = await _cacheManager.GetCache("CacheName").Get("Mail", () => GetToken("Mail"));
            //如果因为没配置好企业微信ID等获取不到token 直接返回FALSE
            if (string.IsNullOrWhiteSpace(token))
            {
                return new AddTagMemberResult { errcode = ReturnCode_Work.系统繁忙, errmsg = "未获取到token" };
            }
            return await ApiHandlerWapper.TryCommonApiAsync(async accessToken =>
            {
                var url = Config.ApiWorkHost + "/cgi-bin/tag/addtagusers?access_token={0}";
                JsonSetting jsonSetting = new JsonSetting(true);
                var datare = input;
                return await CommonJsonSend.SendAsync<AddTagMemberResult>(accessToken, url, datare, CommonJsonSendType.POST, Config.TIME_OUT, jsonSetting: jsonSetting);
            }, token);
          
        }

        /// <summary>
        /// 删除标签成员
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<DelTagMemberResult> DelTagMember(CreateTagUsersInput input)
        {
            string token = await _cacheManager.GetCache("CacheName").Get("Mail", () => GetToken("Mail"));
            //如果因为没配置好企业微信ID等获取不到token 直接返回FALSE
            if (string.IsNullOrWhiteSpace(token))
            {
                return new DelTagMemberResult { errcode = ReturnCode_Work.系统繁忙, errmsg = "未获取到token" };
            }
            return await ApiHandlerWapper.TryCommonApiAsync(async accessToken =>
            {
                var url = Config.ApiWorkHost + "/cgi-bin/tag/deltagusers?access_token={0}";
                JsonSetting jsonSetting = new JsonSetting(true);
                var datare = input;
                return await CommonJsonSend.SendAsync<DelTagMemberResult>(accessToken, url, datare, CommonJsonSendType.POST, Config.TIME_OUT, jsonSetting: jsonSetting);
            }, token);
           
        }


        /// <summary>
        /// 获取标签列表
        /// </summary>
        /// <returns></returns>
        public async Task<GetTagListResult> GetTagList()
        {
            string token = await _cacheManager.GetCache("CacheName").Get("Mail", () => GetToken("Mail"));
            //如果因为没配置好企业微信ID等获取不到token 直接返回FALSE
            if (string.IsNullOrWhiteSpace(token))
            {
                return new GetTagListResult { errcode = ReturnCode_Work.系统繁忙, errmsg = "未获取到token" };
            }

            return await ApiHandlerWapper.TryCommonApiAsync(async accessToken =>
            {
                var url = string.Format(Config.ApiWorkHost + "/cgi-bin/tag/list?access_token={0}", accessToken.AsUrlData());

                return await Get.GetJsonAsync<GetTagListResult>(url);
            }, token);
        }


   
        #endregion


        #endregion

        #region  Msg 发送消息

        /// <summary>
        /// 发送文本信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async  Task<MassResult> SendText(SendTextInput input)
        {
            string token = await _cacheManager.GetCache("CacheName").Get(input.value, () => GetToken(input.value));

            //string token = "wHNPkCAccZAFYmV7Vt1AH_XM-Lon3wyE2pBpHGYLqx7hzhceOlETxDu7hq5Yvg1cVWZK2UMOzLnNXUFth1IOn6EqWfEjAyOZeEwqH5l0FRcWfgS4xxN7EXhYtinTASNHTJCIa0Iz-Jr2QelHDjDgGecpwjE7KVF0jQ1OZ2DSkTkZxZm8_NTRjYR71DSxH6eGQxlefMfxEen69lksw7XkiA";
            //如果因为没配置好企业微信ID等获取不到token 直接返回FALSE
            if (string.IsNullOrWhiteSpace(token))
            {
                return new MassResult { errcode = ReturnCode_Work.系统繁忙, errmsg = "未获取到token" };
            }

            string url = Config.ApiWorkHost + "/cgi-bin/message/send?access_token={0}";
            return await ApiHandlerWapper.TryCommonApiAsync(async accessToken =>
            {
                var data = new
                {
                    touser = input.toUser,
                    toparty = input.toParty,
                    totag = input.toTag,
                    msgtype = "text",
                    agentid = GetWechatConfigByValue(input.value).AgentId,
                    text = new
                    {
                        input.content
                    },
                    input.safe
                };

                JsonSetting jsonSetting = new JsonSetting(true);

                return await CommonJsonSend.SendAsync<MassResult>(accessToken, url, data, CommonJsonSendType.POST, Config.TIME_OUT, jsonSetting: jsonSetting);
            }, token);

        }

        /// <summary>
        /// 发送图片信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<MassResult> SendImage(SendImageInput input)
        {
            /// string token = _cacheManager.GetCache("CacheName").Get("Msg", () => GetToken("Msg"));
            string token = await _cacheManager.GetCache("CacheName").Get(input.value, () => GetToken(input.value));

            //string token = "wHNPkCAccZAFYmV7Vt1AH_XM-Lon3wyE2pBpHGYLqx7hzhceOlETxDu7hq5Yvg1cVWZK2UMOzLnNXUFth1IOn6EqWfEjAyOZeEwqH5l0FRcWfgS4xxN7EXhYtinTASNHTJCIa0Iz-Jr2QelHDjDgGecpwjE7KVF0jQ1OZ2DSkTkZxZm8_NTRjYR71DSxH6eGQxlefMfxEen69lksw7XkiA";
            //如果因为没配置好企业微信ID等获取不到token 直接返回FALSE
            if (string.IsNullOrWhiteSpace(token))
            {
                return new MassResult { errcode = ReturnCode_Work.系统繁忙, errmsg = "未获取到token" };

            }
            string url = Config.ApiWorkHost + "/cgi-bin/message/send?access_token={0}";
            return await ApiHandlerWapper.TryCommonApiAsync(async accessToken =>
            {
                var data = new
                {
                    touser = input.toUser,
                    toparty = input.toParty,
                    totag = input.toTag,
                    msgtype = "image",
                    agentid = GetWechatConfigByValue(input.value).AgentId,
                    image = new
                    {
                        media_id = input.mediaId
                    },
                    input.safe
                };

                JsonSetting jsonSetting = new JsonSetting(true);

                return await CommonJsonSend.SendAsync<MassResult>(accessToken, url, data, CommonJsonSendType.POST, Config.TIME_OUT, jsonSetting: jsonSetting);
            }, token);

        }

        /// <summary>
        /// 发送视频消息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<MassResult> SendVideo(SendVideoInput input)
        {
            //  string token = _cacheManager.GetCache("CacheName").Get("Msg", () => GetToken("Msg"));
            string token = await _cacheManager.GetCache("CacheName").Get(input.value, () => GetToken(input.value));

            //string token = "wHNPkCAccZAFYmV7Vt1AH_XM-Lon3wyE2pBpHGYLqx7hzhceOlETxDu7hq5Yvg1cVWZK2UMOzLnNXUFth1IOn6EqWfEjAyOZeEwqH5l0FRcWfgS4xxN7EXhYtinTASNHTJCIa0Iz-Jr2QelHDjDgGecpwjE7KVF0jQ1OZ2DSkTkZxZm8_NTRjYR71DSxH6eGQxlefMfxEen69lksw7XkiA";
            //如果因为没配置好企业微信ID等获取不到token 直接返回FALSE
            if (string.IsNullOrWhiteSpace(token))
            {
                return new MassResult { errcode = ReturnCode_Work.系统繁忙, errmsg = "未获取到token" };
               
            }
            string url = Config.ApiWorkHost + "/cgi-bin/message/send?access_token={0}";
            return await  ApiHandlerWapper.TryCommonApiAsync(async accessToken =>
            {
                var data = new
                {
                    touser = input.toUser,
                    toparty = input.toParty,
                    totag = input.toTag,
                    msgtype = "video",
                    agentid = GetWechatConfigByValue(input.value).AgentId,
                    video = new
                    {
                        media_id = input.mediaId,
                        input.title,
                        input.description,
                    },
                    input.safe
                };

                JsonSetting jsonSetting = new JsonSetting(true);

                return await CommonJsonSend.SendAsync<MassResult>(accessToken, url, data, CommonJsonSendType.POST, Config.TIME_OUT, jsonSetting: jsonSetting);
            }, token);
        }


        /// <summary>
        /// 发送文件消息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async  Task<MassResult> SendFile(SendImageInput input)
        {
            //  string token = _cacheManager.GetCache("CacheName").Get("Msg", () => GetToken("Msg"));
            string token = await _cacheManager.GetCache("CacheName").Get(input.value, () => GetToken(input.value));

            //string token = "wHNPkCAccZAFYmV7Vt1AH_XM-Lon3wyE2pBpHGYLqx7hzhceOlETxDu7hq5Yvg1cVWZK2UMOzLnNXUFth1IOn6EqWfEjAyOZeEwqH5l0FRcWfgS4xxN7EXhYtinTASNHTJCIa0Iz-Jr2QelHDjDgGecpwjE7KVF0jQ1OZ2DSkTkZxZm8_NTRjYR71DSxH6eGQxlefMfxEen69lksw7XkiA";
            //如果因为没配置好企业微信ID等获取不到token 直接返回FALSE
            if (string.IsNullOrWhiteSpace(token))
            {
                return new MassResult { errcode = ReturnCode_Work.系统繁忙, errmsg = "未获取到token" };

            }
            string url = Config.ApiWorkHost + "/cgi-bin/message/send?access_token={0}";

            return await ApiHandlerWapper.TryCommonApiAsync(async accessToken =>
            {
                var data = new
                {
                    touser = input.toUser,
                    toparty = input.toParty,
                    totag = input.toTag,
                    msgtype = "file",
                    agentid = GetWechatConfigByValue(input.value).AgentId,
                    file = new
                    {
                        media_id = input.mediaId
                    },
                    input.safe
                };

                JsonSetting jsonSetting = new JsonSetting(true);

                return await CommonJsonSend.SendAsync<MassResult>(accessToken, url, data, CommonJsonSendType.POST, Config.TIME_OUT, jsonSetting: jsonSetting);
            }, token);

        }

        /// <summary>
        /// 文本卡片类
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async  Task<MassResult> SendImageText(SendImageTextInput input)
        {


            //  string token = _cacheManager.GetCache("CacheName").Get("Msg", () => GetToken("Msg"));
            string token = await _cacheManager.GetCache("CacheName").Get(input.value, () => GetToken(input.value));

            //string token = "wHNPkCAccZAFYmV7Vt1AH_XM-Lon3wyE2pBpHGYLqx7hzhceOlETxDu7hq5Yvg1cVWZK2UMOzLnNXUFth1IOn6EqWfEjAyOZeEwqH5l0FRcWfgS4xxN7EXhYtinTASNHTJCIa0Iz-Jr2QelHDjDgGecpwjE7KVF0jQ1OZ2DSkTkZxZm8_NTRjYR71DSxH6eGQxlefMfxEen69lksw7XkiA";
            //如果因为没配置好企业微信ID等获取不到token 直接返回FALSE
            if (string.IsNullOrWhiteSpace(token))
            {
                return new MassResult { errcode=ReturnCode_Work.系统繁忙, errmsg="未获取到token"};
            }
            string url = Config.ApiWorkHost + "/cgi-bin/message/send?access_token={0}";

            return await ApiHandlerWapper.TryCommonApiAsync(async accessToken =>
            {
                var data = new
                {
                    input.touser,
                    input.toparty,
                    input.totag,
                    input.msgtype,
                    agentid = GetWechatConfigByValue(input.value).AgentId,
                    textcard = new
                    {
                        input.title,
                        input.description,
                        input.url,
                        input.btntxt
                    }
                };

                JsonSetting jsonSetting = new JsonSetting(true);

                return await CommonJsonSend.SendAsync<MassResult>(accessToken, url, data, CommonJsonSendType.POST, Config.TIME_OUT, jsonSetting: jsonSetting);
            }, token);
        }

        #endregion

        #region 获取打卡数据

        /// <summary>
        /// 获取用户打卡数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<GetCheckinDataJsonResult_Result[]> GetUserCheckin(GetUserCheckinInput input)
        {
            //获取缓存里的token
            string token = await _cacheManager.GetCache("CacheName").Get("Check", () => GetToken("Check"));

            //如果因为没配置好企业微信ID等获取不到token 直接返回FALSE
            if (string.IsNullOrWhiteSpace(token))
            {
                //return new WorkJsonResult { errcode = ReturnCode_Work.系统繁忙, errmsg = "未获取到token" };
            }

            var inputData = new CheckinData
            {
                opencheckindatatype = input.Type,
                starttime= DateTimeToLinuxTime(input.StartDate),
                endtime = DateTimeToLinuxTime(input.EndDate),
                useridlist=input.UserList
            };
            var  result = await ApiHandlerWapper.TryCommonApiAsync(async accessToken =>
            {
                var url = Config.ApiWorkHost + "/cgi-bin/checkin/getcheckindata?access_token={0}";

                var data = inputData;

                return await CommonJsonSend.SendAsync<GetCheckinDataJsonResult>(accessToken, url, data, CommonJsonSendType.POST, Config.TIME_OUT);
            }, token);
            return result.checkindata;
        }


        /// <summary>
        /// 获取打卡应用Token
        /// </summary>
        /// <returns></returns>


        //public async Task GetCheckIn()
        //{
        //    var data = UserManager.Users.Where(r => r.UserName != "admin");
        //    List<string> list = new List<string>();
        //    foreach (var item in data)
        //    {
        //        list.Add(item.UserName);
        //    }

        //    var input = new GetUserCheckinInput
        //    {
        //        Type = 3,
        //        UserList = list.ToArray(),
        //        StartDate = DateTime.Parse("2018-04-02"),
        //        EndDate = DateTime.Parse("2018-07-02")
        //    };

        //    await GetUserCheckin(input);
        //}



        /// <summary>
        /// DateTime 转linux时间戳
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private static  string DateTimeToLinuxTime(DateTime dt)
        {
            string timeStamp = (TimeZoneInfo.ConvertTimeToUtc(dt, TimeZoneInfo.Local) - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
            //timeStamp = timeStamp.Substring(0, timeStamp.Length - 7);
            return timeStamp;
        }


        /// <summary>
        /// linux时间戳 转DateTime
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private static DateTime LinuxTimeToDateTime(string timeStamp)
        {
            DateTime dtStart = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Local);
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            DateTime dtResult = dtStart.Add(toNow);
            return dtResult;
        }

        #endregion


        #region 素材管理
        /// <summary>
        /// 上传素材  type=图片（image）、语音（voice）、视频（video），普通文件(file)  filenPath=上传到服务器后的文件绝对路径
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<UploadTemporaryResultJson> UploadMedia(UploadMedia input)
        {       

            string token = await _cacheManager.GetCache("CacheName").Get("Mail", () => GetToken("Mail"));
            if (string.IsNullOrWhiteSpace(token))
            {
                return new UploadTemporaryResultJson { errcode=ReturnCode_Work.系统繁忙,errmsg="未能获取到token"};
            }
            UploadMediaFileType fileType = new UploadMediaFileType();
            try
            {
                 fileType = (UploadMediaFileType)Enum.Parse(typeof(UploadMediaFileType), input.type);
            }
            catch
            {
                fileType = UploadMediaFileType.file;
            }
           
            return await MediaApi.UploadAsync(token, fileType, input.filenPath);
        }


        #endregion


        #region 一键同步



        ///// <summary>
        ///// 同步企业微信组织架构，标签  人员
        ///// </summary>
        ///// <returns></returns>
        //public async Task ExportAll()
        //{
        //    ExportDepartment();
        //    ExportTag();
        //    ExportUsers();
        //}


        /// <summary>
        /// 一键同步标签及标签成员
        /// </summary>
        public  async  Task   ExportTag(EntityDto<int?> input)
        {
            int tenantId = AbpSession.TenantId.Value;
            if (input.Id.HasValue)
            {
                tenantId = input.Id.Value;
    
            }
            using (CurrentUnitOfWork.SetTenantId(input.Id))
            {
                //获取所有标签
                var taglist = GetTagList().Result.taglist;

                foreach (var item in taglist)
                {
                    var tagusers = GetTagMember(new EntityDto<string> { Id = item.tagid }).Result.userlist;
                    CreateTagUsersInput getTagMemberInput = new CreateTagUsersInput();
                    getTagMemberInput.tagid = item.tagid;
                    List<string> userlist = new List<string>();
                    foreach (var itemUsers in tagusers)
                    {
                        userlist.Add(itemUsers.userid);
                    }
                    getTagMemberInput.useridlist = userlist.ToArray();
                    if (userlist.Count <= 0)//如果标签无成员  不执行删除
                    {
                        //删除标签
                        await DeleteTag(new EntityDto<string> { Id = item.tagid });
                    }
                    else
                    {
                        //删除标签成员
                        if (DelTagMember(getTagMemberInput).Result.errcode.ToString() == "0")
                        {
                            //删除标签
                            await DeleteTag(new EntityDto<string> { Id = item.tagid });
                        }
                    }

                }

                var roles = _roleManager.Roles;
                foreach (var item in roles)
                {
                    CreateTagInput createTagInput = new CreateTagInput
                    {
                        tagid = item.Id.ToString(),
                        tagname = item.DisplayName
                    };
                    //创建标签
                    if (CreateTag(createTagInput).Result.errcode == 0)
                    {
                        var userrole = _userRoleRepository.GetAll().Where(r => r.RoleId == item.Id);
                        CreateTagUsersInput createTagUsersInput = new CreateTagUsersInput();
                        createTagUsersInput.tagid = item.Id.ToString();
                        List<string> rolelist = new List<string>();
                        foreach (var itemRoles in userrole)
                        {
                            rolelist.Add(itemRoles.Id.ToString());
                        }
                        if (rolelist.Count > 0)//如果标签有成员  添加
                        {
                            //创建标签成员
                            createTagUsersInput.useridlist = rolelist.ToArray();
                            await AddTagMember(createTagUsersInput);
                        }

                    }
                }
            }
        }

        #region 组织架构 批量

        /// <summary>
        ///   一键同步组织架构
        /// </summary>
        public async Task<AsynchronousJobId> ExportDepartment(EntityDto<int?> input)
        {
            int tenantId = AbpSession.TenantId.Value;
            if (input.Id.HasValue)
            {
                tenantId = input.Id.Value;
            
            }
            using (CurrentUnitOfWork.SetTenantId(input.Id))
            {
                string txtname = "组织架构同步" + DateTime.Now.ToString("yyyy-MM-ddmmss");
                string str = _iHostingEnvironment.WebRootPath;
                int index = str.LastIndexOf("\\");
                str = str.Substring(0, index);
                string path = str + "\\wwwroot\\WechatWorkUpload\\" + txtname + ".csv";
                bool flag = !Directory.Exists(str + "\\wwwroot\\WechatWorkUpload");
                if (flag)
                {
                    Directory.CreateDirectory(str + "\\wwwroot\\WechatWorkUpload");
                }
                bool flag2 = !File.Exists(path);
                FileStream fileStream;
                StreamWriter writer;
                if (flag2)
                {
                    fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
                    writer = new StreamWriter(fileStream, Encoding.UTF8);

                }
                else
                {
                    fileStream = new FileStream(path, FileMode.Append, FileAccess.Write);
                    writer = new StreamWriter(fileStream, Encoding.UTF8);

                }
                writer.WriteLine("部门名称,部门ID,父部门ID,排序");//输出标题，逗号分割（注意最后一列不加逗号）
                var dataDepartment = _organizationUnitRepository.GetAll().AsNoTracking();
                foreach (var item in dataDepartment)
                {
                    writer.Write(item.DisplayName + ",");
                    writer.Write(item.Id + ",");
                    writer.Write(item.ParentId == null ? "1," : item.ParentId + ",");
                    writer.Write("1,");
                    writer.WriteLine();
                }
                writer.Close();
                fileStream.Close();

                UploadMedia media = new UploadMedia
                {
                    type = "file",
                    filenPath = path
                };
                var updata = await UploadMedia(media);
                if (updata.errcode != ReturnCode_Work.请求成功)
                {
                    return new AsynchronousJobId { errcode = ReturnCode_Work.系统繁忙, errmsg = "上传文件失败" };
                }
                var mediaId = updata.media_id;
                Asynchronous_CallBack callBack = new Asynchronous_CallBack
                {
                    url = "",
                    token = await GetToken("Mail")
                };
                return BatchReplaceParty(await GetToken("Mail"), mediaId, callBack);

            }
        }


        /// <summary>
        /// 【异步方法】全量覆盖部门
        /// CSV模板下载地址：http://qydev.weixin.qq.com/batch_party_sample.csv
        /// 注意事项：
        /// 1.文件中存在、通讯录中也存在的部门，执行修改操作
        /// 2.文件中存在、通讯录中不存在的部门，执行添加操作
        /// 3.文件中不存在、通讯录中存在的部门，当部门为空时，执行删除操作
        /// 4.CSV文件中，部门名称、部门ID、父部门ID为必填字段，部门ID必须为数字；排序为可选字段，置空或填0不修改排序
        /// </summary>
        /// <param name="accessTokenOrAppKey">调用接口凭证（AccessToken）或AppKey（根据AccessTokenContainer.BuildingKey(corpId, corpSecret)方法获得）</param>
        /// <param name="mediaId">上传的csv文件的media_id</param>
        /// <param name="callBack">回调信息。任务完成后，通过callback推送事件给企业。具体请参考应用回调模式中的相应选项</param>
        /// <param name="timeOut"></param>
        /// post数据格式：
        /// {
        ///    "media_id":"xxxxxx",
        ///    "callback":
        ///    {
        ///        "url": "xxx",
        ///        "token": "xxx",
        ///        "encodingaeskey": "xxx"
        ///    }
        /// }
        /// <returns></returns>
        private static AsynchronousJobId BatchReplaceParty(string accessTokenOrAppKey, string mediaId, Asynchronous_CallBack callBack, int timeOut = Config.TIME_OUT)
        {
            return ApiHandlerWapper.TryCommonApi(accessToken =>
            {
                var url = Config.ApiWorkHost + "/cgi-bin/batch/replaceparty?access_token={0}";

                var data = new
                {
                    media_id = mediaId,
                    callback = callBack
                };

                return CommonJsonSend.Send<AsynchronousJobId>(accessToken, url, data, CommonJsonSendType.POST, timeOut);
            }, accessTokenOrAppKey);


        }

        #endregion


        #region 人员 批量


     


        

        /// <summary>
        /// 【异步方法】全量覆盖成员
        /// CSV模板下载地址：http://qydev.weixin.qq.com/batch_user_sample.csv
        /// 注意事项：
        /// 1.模板中的部门需填写部门ID，多个部门用分号分隔，部门ID必须为数字
        /// 2.文件中存在、通讯录中也存在的成员，完全以文件为准
        /// 3.文件中存在、通讯录中不存在的成员，执行添加操作
        /// 4.通讯录中存在、文件中不存在的成员，执行删除操作。出于安全考虑，如果需要删除的成员多于50人，且多于现有人数的20%以上，系统将中止导入并返回相应的错误码
        /// </summary>
        /// <param name="accessTokenOrAppKey">调用接口凭证（AccessToken）或AppKey（根据AccessTokenContainer.BuildingKey(corpId, corpSecret)方法获得）</param>
        /// <param name="mediaId">上传的csv文件的media_id</param>
        /// <param name="callBack">回调信息。任务完成后，通过callback推送事件给企业。具体请参考应用回调模式中的相应选项</param>
        /// <param name="timeOut"></param>
        /// post数据格式：
        /// {
        ///    "media_id":"xxxxxx",
        ///    "callback":
        ///    {
        ///        "url": "xxx",
        ///        "token": "xxx",
        ///        "encodingaeskey": "xxx"
        ///    }
        /// }
        /// <returns></returns>
        private static async Task<AsynchronousJobId> BatchReplaceUserAsync(string accessTokenOrAppKey, string mediaId, Asynchronous_CallBack callBack, int timeOut = Config.TIME_OUT)
        {
            return await ApiHandlerWapper.TryCommonApiAsync(async accessToken =>
            {
                var url = Config.ApiWorkHost + "/cgi-bin/batch/replaceuser?access_token={0}";

                var data = new
                {
                    media_id = mediaId,
                    callback = callBack
                };

                return await Senparc.Weixin.CommonAPIs.CommonJsonSend.SendAsync<AsynchronousJobId>(accessToken, url, data, CommonJsonSendType.POST, timeOut);
            }, accessTokenOrAppKey);


        }


        ///// <summary>
        ///// 【异步方法】获取异步更新或全面覆盖成员结果
        ///// </summary>
        ///// <param name="accessTokenOrAppKey">调用接口凭证（AccessToken）或AppKey（根据AccessTokenContainer.BuildingKey(corpId, corpSecret)方法获得）</param>
        ///// <param name="jobId"></param>
        ///// <returns></returns>
        //public  async Task<AsynchronousReplaceUserResult> GetReplaceUserResult( EntityDto<string> jobId)
        //{
        //    return await ApiHandlerWapper.TryCommonApiAsync(async accessToken =>
        //    {
        //        var url = string.Format(Config.ApiWorkHost + "/cgi-bin/batch/getresult?access_token={0}&jobid={1}",
        //                            accessToken.AsUrlData(), jobId.Id.AsUrlData());

        //        return await Get.GetJsonAsync<AsynchronousReplaceUserResult>(url);
        //    }, GetToken("Mail"));


        //}

        #endregion





        #endregion
        /// <summary>
        /// 企业微信网页登陆授权获取url
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<GetWechatLoginUserIdByCodeOutput> GetUrlByPageResult(EntityDto<string> input)
        {
            string corpID = await GetWechatConfig("CorpID");
            string url = string.Format("https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type={2}&scope={3}&state={4}#wechat_redirect", corpID.AsUrlData(), input.Id.AsUrlData(), "code".AsUrlData(), "snsapi_base".AsUrlData(), "".AsUrlData());
            GetWechatLoginUserIdByCodeOutput output = new GetWechatLoginUserIdByCodeOutput
            {
                Token = url
            };
            return output;
        }

        /// <summary>
        /// 根据Code获取用户ID
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<GetWechatLoginUserIdByCodeOutput> GetWechatLoginUserIdByCode(GetWechatLoginInput input)
        {
            var con = _wechatConfig.GetAll().Where(r => r.PageRuslt.Trim() == input.PageResult.Trim()).FirstOrDefault();

            string accessToken = await _cacheManager.GetCache("CacheName").Get(con.Value.Trim(), () => GetToken(con.Value.Trim()));
            var url = string.Format(Config.ApiWorkHost + "/cgi-bin/user/getuserinfo?access_token={0}&code={1}", accessToken.AsUrlData(), input.Code.AsUrlData(), con.AgentId.AsUrlData());

            var data = Get.GetJson<GetUserInfoResult>(url);
            if (data.errcode.ToString() == "40029")
            {
                throw new UserFriendlyException(L("重复验证，请退出重进！"));
            }
            if (string.IsNullOrWhiteSpace(data.UserId))
            {
               throw  new UserFriendlyException(L("不是企业员工，不能登陆！"));
            }
            else
            {
                var result = await UserManager.Users.Where(r => r.UserName == data.UserId).FirstOrDefaultAsync();
                if (result == null)
                {
                     throw new UserFriendlyException(L("找不到员工！"));
                }
                else
                {
                    GetWechatLoginUserIdByCodeOutput output = new GetWechatLoginUserIdByCodeOutput
                    {
                        Id = long.Parse(data.UserId),
                        Name = result.UserName,
                        Email = result.EmailAddress
                    };
                    return output;
                }


            }


        }


     


        /// <summary>
        /// 获取微信配置
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private async Task<string> GetWechatConfig(string value)
        {
            var data = await _wechatConfig.GetAll().Where(r => r.Value == value.Trim()).FirstOrDefaultAsync();
            return data == null ? "" : data.Secret;
         }

        /// <summary>
        /// 企业微信网页授权登陆  获取返回的url
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public WechatConfig GetWechatConfigByPageName(string value)
        {
            var data = _wechatConfig.GetAll().Where(r => r.PageName == value.Trim()).FirstOrDefault();
            return data;
        }

        private WechatConfig GetWechatConfigByPageResult(string value)
        {
            var data = _wechatConfig.GetAll().Where(r => r.PageRuslt.Trim() == value.Trim()).FirstOrDefault();
            return data;
        }

        public object GetWechatConfigByPageResult1(string value)
        {

            return _wechatConfig.GetAll().ToList();
        }


        public WechatConfig GetWechatConfigByValue(string value)
        {
            var data = _wechatConfig.GetAll().Where(r => r.Value == value.Trim()).FirstOrDefault();
            return data;
        }

        /// <summary>
        /// 获取token
        /// </summary>
        /// <param name="tokenType"></param>
        /// <returns></returns>
        private async Task<string> GetToken(string tokenType)
        {
            //公司ID
            string corpID = await GetWechatConfig("CorpID");
            //应用的Secret
            string value = await GetWechatConfig(tokenType.Trim());
            if (string.IsNullOrWhiteSpace(corpID) || string.IsNullOrWhiteSpace(value))
            {
                return "";
            }

            string url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={0}&corpsecret={1}", corpID.Trim(), value.Trim());

            var re =  Get.GetJsonAsync<AccessTokenResult>(url);

            return re.Result.access_token;
           // return Senparc.Weixin.Work.Containers.AccessTokenContainer.TryGetTokenAsync(corpID.Trim(), value.Trim()).Result;
        }




    }


  
}
