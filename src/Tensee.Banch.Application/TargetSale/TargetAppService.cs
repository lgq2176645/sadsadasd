using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Organizations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tensee.Banch.TargetSale.Dto;

namespace Tensee.Banch.TargetSale
{
    public class TargetAppService : BanchAppServiceBase, ITargetAppService
    {
        private readonly IRepository<PersonMonthTarget> _personMonthTarget;
        private readonly IRepository<ShopDayTarget> _shopDayTarget;
        private readonly IRepository<ShopMonthTarget> _shopMonthTarget;
     //   private readonly IRepository<UserUnits, long> _userUnitsRepository;
        private readonly IRepository<OrganizationUnit, long> _organizationUnitRepository;
        private readonly IRepository<UserOrganizationUnit, long> _userOrganizationUnitRepository;
        public TargetAppService(IRepository<PersonMonthTarget> personMonthTarget,
               IRepository<ShopDayTarget> shopDayTarget,
               IRepository<ShopMonthTarget> shopMonthTarget,
             //  IRepository<UserUnits, long> userUnitsRepository,
               IRepository<OrganizationUnit, long> organizationUnitRepository,
               IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository)
        {
            _personMonthTarget = personMonthTarget;
            _shopDayTarget = shopDayTarget;
            _shopMonthTarget = shopMonthTarget;
         //   _userUnitsRepository = userUnitsRepository;
            _organizationUnitRepository = organizationUnitRepository;
            _userOrganizationUnitRepository = userOrganizationUnitRepository;
        }


        /// <summary>
        /// 获取店铺月目标
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<GetShopMonthTargetOutput> GetShopMonthTarget(GetShopMonthTargetInput input)
        {

            var monthTargets =  _shopMonthTarget.GetAll()
                .AsNoTracking()
                .Where(r => r.ZYear == input.ZYear
                && r.ZMonth == input.ZMonth
                && r.OrganizationId == input.OrganizationId)
                .FirstOrDefault();

            var dayTargets =  (from r in _shopDayTarget.GetAll().AsNoTracking()
                              where r.OrganizationId == input.OrganizationId
                              && r.ZYear == input.ZYear && r.ZMonth == input.ZMonth
                              select r.MapTo<ShopDayTargetDto>()).OrderBy(r=>r.Date).ToList();

            return new GetShopMonthTargetOutput
            {
                ShopMonthTarget = monthTargets.MapTo<ShopMonthTargetDto>(),
                ShopDayTargets = dayTargets
            };
        }

        /// <summary>
        /// 创建修改店铺月目标
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdateShopMonthTarget(CreateOrUpdateShopMonthTargetInput input)
        {
            await _shopMonthTarget.DeleteAsync(r => r.OrganizationId == input.OrganizationId
           && r.ZYear == input.ZYear
           && r.ZMonth == input.ZMonth);
            ShopMonthTarget shopMonthTarget = new ShopMonthTarget
            {
                OrganizationId = input.OrganizationId,
                ZYear = input.ZYear,
                ZMonth = input.ZMonth,
                TargetSale = input.TargetSale,
                SprintTargetSale=input.SprintTargetSale,
                BasicsJointRate = input.BasicsJointRate,
                BasicsNewVip = input.BasicsNewVip,
                BasicsVipSaleTarget = input.BasicsVipSaleTarget,
                SprintJointRate = input.SprintJointRate,
                SprintNewVip = input.SprintNewVip,
                SprintVipSaleTarget = input.SprintVipSaleTarget
            };
            await _shopMonthTarget.InsertAsync(shopMonthTarget);
        }


        /// <summary>
        /// 创建修改店铺日目标
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdateShopDayTarget(CreateOrUpdateShopDayTargetInput input)
        {
            if (input == null)
            {
                throw new Exception("数据为空！");
            }
            var shopDayTarget = input.ShopMonthTarget;
            await _shopDayTarget
               .DeleteAsync(r => r.ZMonth == shopDayTarget.ZMonth
               && r.ZYear == shopDayTarget.ZYear
               && r.OrganizationId == shopDayTarget.OrganizationId);

            await  _shopMonthTarget.DeleteAsync(r => r.ZMonth == shopDayTarget.ZMonth
               && r.ZYear == shopDayTarget.ZYear
               && r.OrganizationId == shopDayTarget.OrganizationId);

            //ShopMonthTarget shopMonthTarget = new ShopMonthTarget();
            //ObjectMapper.Map(input.ShopMonthTarget, shopMonthTarget);
            ShopMonthTarget shopMonthTarget = new ShopMonthTarget
            {
                OrganizationId = input.ShopMonthTarget.OrganizationId,
                ZYear = input.ShopMonthTarget.ZYear,
                ZMonth = input.ShopMonthTarget.ZMonth,
                TargetSale = input.ShopMonthTarget.TargetSale,
                BasicsJointRate = input.ShopMonthTarget.BasicsJointRate,
                BasicsNewVip = input.ShopMonthTarget.BasicsNewVip,
                BasicsVipSaleTarget = input.ShopMonthTarget.BasicsVipSaleTarget,
                SprintTargetSale = input.ShopMonthTarget.SprintTargetSale,
                SprintJointRate = input.ShopMonthTarget.SprintJointRate,
                SprintNewVip = input.ShopMonthTarget.SprintNewVip,
                SprintVipSaleTarget = input.ShopMonthTarget.SprintVipSaleTarget
            };
            await  _shopMonthTarget.InsertAsync(shopMonthTarget);
            foreach (var item in input.ShopDayTargets)
            {
                ShopDayTarget data = new ShopDayTarget
                {
                    OrganizationId = item.OrganizationId,
                    ZYear = item.ZYear,
                    ZMonth = item.ZMonth,
                    DayTarget = item.DayTarget,
                    SprintDayTarget =  item.SprintDayTarget,
                    Date = item.Date
                };
                //  ObjectMapper.Map(item, data);
                await _shopDayTarget.InsertAsync(data);
            }
        }

        ///// <summary>
        ///// 获取店铺日目标
        ///// </summary>
        ///// <param name="input"></param>
        ///// <returns></returns>
        //public async Task<ListResultDto<CreateOrUpdateShopDayTargetInput>> GetShopDayTarget(GetShopMonthTargetInput input)
        //{
        //    var data = (from r in _shopDayTarget.GetAll().AsNoTracking()
        //                where r.OrganizationId == input.OrganizationId
        //                && r.ZYear == input.ZYear && r.ZMonth == input.ZMonth
        //                select r.MapTo<CreateOrUpdateShopDayTargetInput>()).ToList();
        //    return new ListResultDto<CreateOrUpdateShopDayTargetInput>(data);
        //}

        /// <summary>
        /// 创建修改人员月目标
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdatePersonMonthTarget(List<CreateOrUpdatePersonMonthTargetInput> input)
        {
            if (input == null || input.Count <= 0)
            {
                throw new Exception("数据为空！");
            }
            var deData = input.FirstOrDefault();
            await _personMonthTarget
                 .DeleteAsync(r => r.OrganizationId == deData.OrganizationId
                    && r.ZYear == deData.ZYear
                    && r.ZMonth == deData.ZMonth);

            foreach (var item in input)
            {
                PersonMonthTarget personMonthTarget = new PersonMonthTarget
                {
                    OrganizationId = item.OrganizationId,
                    ZYear = item.ZYear,
                    ZMonth = item.ZMonth,
                    UserId = item.UserId,
                    TargetSale = item.TargetSale,
                    JointRate = item.JointRate,
                    SprintTargetSale = item.SprintTargetSale,
                    NewVip = item.NewVip,
                    VipSaleTarget = item.VipSaleTarget,
                    SprintJointRate = item.SprintJointRate,
                    SprintNewVip = item.SprintNewVip,
                    SprintVipSaleTarget = item.SprintVipSaleTarget

                };
                //  PersonMonthTarget personMonthTarget = new PersonMonthTarget();

                // ObjectMapper.Map(item, personMonthTarget);
                await _personMonthTarget.InsertAsync(personMonthTarget);
            }

        }


        /// <summary>
        /// 获取人员销售月目标
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async  Task<CreateOrUpdatePersonMonthTargetOutput> GetPersonMonthTarget(GetShopMonthTargetInput input)
        {

            var monthTargets = _shopMonthTarget.GetAll()
               .AsNoTracking()
               .Where(r => r.ZYear == input.ZYear
               && r.ZMonth == input.ZMonth
               && r.OrganizationId == input.OrganizationId)
               .FirstOrDefault();

            var createOrUpdatePersonMonthTargetInputList = (from user in UserManager.Users
                        join userorgn in _userOrganizationUnitRepository.GetAll().AsNoTracking() on user.Id equals userorgn.UserId
                        join organ in _organizationUnitRepository.GetAll().AsNoTracking() on userorgn.OrganizationUnitId equals organ.Id
                        join person in _personMonthTarget.GetAll().AsNoTracking().Where(r => r.ZYear == input.ZYear && r.ZMonth == input.ZMonth)
                        on user.Id equals person.UserId into temp
                        from tt in temp.DefaultIfEmpty()
                        where organ.Id == input.OrganizationId
                        select new CreateOrUpdatePersonMonthTargetInput
                        {
                            OrganizationId = organ.Id,
                            ZMonth = input.ZMonth,
                            ZYear = input.ZYear,
                            UserId = Int32.Parse(user.Id.ToString()),
                            UserName = user.Name,
                            VipSaleTarget = tt == null ? 0 : tt.VipSaleTarget,
                            NewVip = tt == null ? 0 : tt.NewVip,
                            TargetSale = tt == null ? 0 : tt.TargetSale,
                            SprintTargetSale = tt == null ? 0 : tt.SprintTargetSale,
                            JointRate = tt == null ? 0 : tt.JointRate,
                            SprintJointRate = tt == null ? 0 : tt.SprintJointRate,
                            SprintNewVip = tt == null ? 0 : tt.SprintNewVip,
                            SprintVipSaleTarget = tt == null ? 0 : tt.SprintVipSaleTarget
                        }).ToList();

            return new CreateOrUpdatePersonMonthTargetOutput
            {
                ShopMonthTarget = monthTargets.MapTo<ShopMonthTargetDto>(),
                PersonMonthTargets = createOrUpdatePersonMonthTargetInputList
            };
        }

    }
}
