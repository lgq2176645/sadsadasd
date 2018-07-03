using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tensee.Banch.Mobile.Coupons.Dto;

namespace Tensee.Banch.Mobile.Coupons
{
    public interface ICouponAppService: IApplicationService
    {
        /// <summary>
        /// 获取用户所有优惠券
        /// </summary>
        /// <returns></returns>
        Task<ListResultDto<UserCouponDto>> GetUserCouponList(string sessionId);
        Task<PagedResultDto<CouponDto>> GetAllCouponList(GetCouponDto input);

        Task<CouponDto> CreateOrUpdateCoupon(CreateOrUpdateCouponInput input);
        Task CreateUserCoupon(CreateUserCouponInput input);

        Task DeleteCoupon(EntityDto input);

    }
}
