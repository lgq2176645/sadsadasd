using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tensee.Banch.Mobile.WeChatUsers.Dto;

namespace Tensee.Banch.Mobile.WeChatUsers
{
    public interface IAppWeChatUserAppService : IApplicationService
    {
        /// <summary>
        /// 记录微信登陆进来的用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<string> CreateAppWeChatUser(CreateAppWeChatUserInput input);

        /// <summary>
        /// 记录微信商城登陆进来的用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CreateAppWeChatUserDto> CreateAppMallWeChatUser(CreateAppMallWeChatUserInput input);
        string GetSessionOpenId(string sessionKey);


        /// <summary>
        /// 获取指定的微信用户信息
        /// <para>如果输入为空则获取所有用户</para>
        /// </summary>
        /// <param name="input">指定的用户Id</param>
        /// <returns>用户列表</returns>
        Task<ListResultDto<WeChatUserDto>> GetWeChatUser(EntityDto<int?> input);

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="input">新的用户信息</param>
        /// <returns></returns>
        Task UpdateWeChatUserAsync(UpdateWeChatUserInput input);

        Task MoveWeChatUserAsync(MoveWeChatUserInput input);

        /// <summary>
        /// 根据Id删除指定的用户信息
        /// </summary>
        /// <param name="input">用户Id</param>
        /// <returns></returns>
        Task DeleteWeChatUserAsync(EntityDto<int> input);

     
    }
}
