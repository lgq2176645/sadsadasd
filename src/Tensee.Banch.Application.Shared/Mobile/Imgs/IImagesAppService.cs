using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using Tensee.Banch.Mobile.Imgs.Dto;

namespace Tensee.Banch.Mobile.Imgs
{
    public interface IImagesAppService : IApplicationService
    {
        /// <summary>
        /// 获取轮播图片
        /// </summary>
        /// <returns></returns>
        Task<ListResultDto<ImagesDto>> GetImagesList(EntityDto input);
        /// <summary>
        /// 获取全部图片
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ListResultDto<ImagesDto>> GetAllImagesList();
        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteImages(EntityDto input);

        Task<ImagesDto> CreateImages(CreatrImgInput input);
    }
}
