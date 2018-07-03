using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tensee.Banch.Mobile.Orders.Dto;

namespace Tensee.Banch.Mobile.Orders
{
    public interface ICommentAppService : IApplicationService
    {
        /// <summary>
        /// 获取所有5星评论
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        ListResultDto<CommentDto> GetGoodCommentList();

        Task<ReustModel> CreateComment(CreateCommentInput input);
        Task<PagedResultDto<CommentDto>> GetAllComment(GetAllCommentInput input);

        Task DeleteComment(EntityDto input);

    }
}
