using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Senparc.Weixin.Entities;
using Senparc.Weixin.Work.AdvancedAPIs.Asynchronous;
using Senparc.Weixin.Work.AdvancedAPIs.MailList;
using Senparc.Weixin.Work.AdvancedAPIs.Mass;
using Senparc.Weixin.Work.AdvancedAPIs.Media;
using Senparc.Weixin.Work.AdvancedAPIs.OaDataOpen;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tensee.Banch.Organizations.Dto;
using Tensee.Banch.QYWechat.Dto;
using Tensee.Banch.QYWechat.Dto.Agent;

namespace Tensee.Banch.QYWechat
{
    /// <summary>
    /// 
    /// </summary>
    public interface IQYWechatAppService: IApplicationService
    {
        #region 员工
        /// <summary>
        /// 获取员工信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetMemberResult> GetMember(DeleteWeChatUserInput input);


        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<WorkJsonResult> DeleteMember(EntityDto<long> input);


        /// <summary>
        /// 批量删除员工
        /// </summary>
        /// <returns></returns>
        Task<WorkJsonResult> BatchDeleteMember(BatchDeleteWeChatUserInput input);

        /// <summary>
        /// <summary>
        /// 获取部门成员
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetDepartmentMemberResult> GetDepartmentMember(GetDepartmentWeChatUserInput input);

       /// <summary>
       /// 获取组织架构成员
       /// </summary>
       /// <param name="input"></param>
       /// <returns></returns>
        Task<GetDepartmentMemberInfoResult> GetDepartmentMemberInfo(GetDepartmentWeChatUserInput input);
        #endregion

        #region 组织架构


        /// <summary>
        /// 新增微信组织架构
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<CreateDepartmentResult> CreateDepartment(WeChatOrganization data);

        /// <summary>
        /// 修改部门信息
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<WorkJsonResult> UpdateDepartment(WeChatOrganization data);

        /// <summary>
        /// 删除部门（注：不能删除根部门；不能删除含有子部门、成员的部门）
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<WorkJsonResult> DeleteDepartment(DeleteWeChatOrganizationInput input);


        /// <summary>
        /// 获取部门列表 部门id。获取指定部门及其下的子部门。 如果不填，默认获取全量组织架构
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetDepartmentListResult> GetDepartmentList(GetWeChatOrganizationListInput input);

        #endregion

        #region 发送消息
        /// <summary>
        /// 发送文本信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
         Task<MassResult> SendText(SendTextInput input);

        /// <summary>
        /// 发送图片信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<MassResult> SendImage(SendImageInput input);

        /// <summary>
        /// 发送视频消息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<MassResult> SendVideo(SendVideoInput input);

        /// <summary>
        /// 发送文件消息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<MassResult> SendFile(SendImageInput input);

        /// <summary>
        /// 发送文本卡片消息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<MassResult> SendImageText(SendImageTextInput input);




        #endregion

        #region 微信配置


        /// <summary>
        /// 企业微信网页登陆授权获取url
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetWechatLoginUserIdByCodeOutput> GetUrlByPageResult(EntityDto<string> input);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        object GetWechatConfigByPageResult1(string value);

        //  object GetWechatLoginUserIdByCode(GetWechatLoginInput input);
        // string GetWechatConfig(string value); 
        #endregion
        #region 标签管理 角色

        /// <summary>
        /// 创建标签
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CreateTagResult> CreateTag(CreateTagInput input);

        /// <summary>
        /// 修改标签
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<WorkJsonResult> UpdateTag(CreateTagInput input);

        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<WorkJsonResult> DeleteTag(EntityDto<string> input);

        /// <summary>
        /// 获取标签成员
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetTagMemberResult> GetTagMember(EntityDto<string> input);

        /// <summary>
        /// 增加标签成员
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<AddTagMemberResult> AddTagMember(CreateTagUsersInput input);


        /// <summary>
        /// 删除标签成员
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<DelTagMemberResult> DelTagMember(CreateTagUsersInput input);

        /// <summary>
        /// 获取标签列表
        /// </summary>
        /// <returns></returns>
        Task<GetTagListResult> GetTagList();
        #endregion

        #region 素材管理

        /// <summary>
        ///   一键同步组织架构
        /// </summary>
        Task<AsynchronousJobId> ExportDepartment(EntityDto<int?> input);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task ExportTag(EntityDto<int?> input); 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<UploadTemporaryResultJson> UploadMedia(UploadMedia input);
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetWechatLoginUserIdByCodeOutput> GetWechatLoginUserIdByCode(GetWechatLoginInput input);


        /// <summary>
        /// 获取用户打卡数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetCheckinDataJsonResult_Result[]> GetUserCheckin(GetUserCheckinInput input);


    }
}
