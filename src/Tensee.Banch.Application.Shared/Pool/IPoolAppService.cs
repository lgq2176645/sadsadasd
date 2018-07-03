using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tensee.Banch.Pool.Dto;

namespace Tensee.Banch
{
  public interface IPoolAppService : IApplicationService
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        PagedResultDto<MessagPeoolDto> GetMessagepool(GetMessagepoolInput input);

        /// <summary>
        /// 判断Id是否为空 有就修改没有就添加
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        bool CreateMessagePool(CreateMessagepoolInput input);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteMessagepool(EntityDto input);

        Task UpdateMessagepools(EntityDto input);
        /// <summary>
        /// 将对象转换json 或者字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        string FormatToJson<T>(T input);
        /// <summary>
        /// 修改 只修改状态为0
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        bool UpdateMessagepool(CreateMessagepoolInput input);

        bool InsertMessagePoolHistory(MessagePoolHistoryDto input);
    }
}
