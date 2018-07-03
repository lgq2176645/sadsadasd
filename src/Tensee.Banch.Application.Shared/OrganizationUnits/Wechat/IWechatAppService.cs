using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tensee.Banch.OrganizationUnits.Wechat.Dto;

namespace Tensee.Banch.OrganizationUnits.Wechat
{
  public interface IWechatAppService: IApplicationService
    {
        /// <summary>
        /// 查询 单条数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        WechatConfigDto GetWechatConfigByID(EntityDto input);

        /// <summary>
        ///查询全部数据
        /// </summary>
        /// <returns></returns>
        List<WechatConfigDto> GetWechatConfigAll();

        /// <summary>
        /// 添加和修改数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //WechatConfigDto CreateOrUpdateWechatConfig(CreateOrUpdateWechatConfigInput input);
        Task  CreateOrUpdateWechatConfig(List<WechatConfigDto> input);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<WechatConfigDto> DeleteWechatConfig(EntityDto input);
    }
}
