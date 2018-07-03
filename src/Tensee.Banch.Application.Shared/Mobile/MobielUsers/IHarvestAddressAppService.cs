using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tensee.Banch.Mobile.MobielUsers.Dto;
using Tensee.Banch.Mobile.WeChatUsers.Dto;

namespace Tensee.Banch.Mobile.MobielUsers
{
    public interface IHarvestAddressAppService : IApplicationService
    {
        Task<HarvestAddressDto> GetDefaultHarvestAddress(string input);
        Task<ListResultDto<HarvestAddressDto>> GetUserHarvestAddressList(string input);

        Task<HarvestAddressDto> CreateHarvestAddress(CreateHarvestAddressInput input);
        Task UpdateDefaultAddress(UpdateDefaultAdressInput input);
        Task DeleteAddress(EntityDto id);

        /// <summary>
        /// 商城删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<object> DeleteWxAddress(EntityDto input);
        /// <summary>
        /// 微信商城创建地址
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<HarvestAddressDto> CreateWxHarvestAddress(CreateHarvestAddresssInput input);
        /// <summary>
        ///  微信商城获取用户地址列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ListResultDto<WxHarvestAddressDto>> GetWxUserHarvestAddressList(GetUserHarvestAddressListInput input);
        /// <summary>
        /// 修改默认
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateWxDefaultAddress(UpdateWxDefaultAdressInput input);
        /// <summary>
        /// 微信商城获取用户默认地址
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<WxHarvestAddressDto> GetWxDefaultHarvestAddress(GetUserHarvestAddressListInput input);


        

    }
}
