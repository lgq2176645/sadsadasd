using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tensee.Banch.TargetSale.Dto;

namespace Tensee.Banch.TargetSale
{
    public  interface ITargetAppService: IApplicationService
    {
        /// <summary>
        /// 获取店铺月销售目标
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetShopMonthTargetOutput> GetShopMonthTarget(GetShopMonthTargetInput input);

        /// <summary>
        /// 创建修改店铺月目标
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdateShopMonthTarget(CreateOrUpdateShopMonthTargetInput input);
        /// <summary>
        /// 创建修改店铺日目标
        /// </summary>
        /// <returns></returns>
        Task CreateOrUpdateShopDayTarget(CreateOrUpdateShopDayTargetInput input);
        /// <summary>
        /// 获取店铺日目标
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
       // Task<ListResultDto<CreateOrUpdateShopDayTargetInput>> GetShopDayTarget(GetShopMonthTargetInput input);

        /// <summary>
        /// 创建修改人员月目标
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdatePersonMonthTarget(List<CreateOrUpdatePersonMonthTargetInput> input);


        /// <summary>
        /// 获取人员月销售目标
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CreateOrUpdatePersonMonthTargetOutput> GetPersonMonthTarget(GetShopMonthTargetInput input);


    }
}
