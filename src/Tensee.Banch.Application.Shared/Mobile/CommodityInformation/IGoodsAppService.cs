using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tensee.Banch.Mobile.CommodityInformation.Dto;
using Tensee.Banch.Mobile.Goods.Dto;

namespace Tensee.Banch.Mobile.Goods
{
    public interface IGoodsAppService : IApplicationService
    {
        Task<ListResultDto<GoodsDto>> GetGoodsList(GetGoodsInput input);
        Task<GoodsDto> CreateGoods(CreateGoodsInput input);
        Task DeleteGoods(EntityDto input);
        Task UpdateGoods(UpdateGoodsInput input);


    }
}
