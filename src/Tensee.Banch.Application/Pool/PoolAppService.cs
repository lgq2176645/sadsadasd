using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Tensee.Banch.Pool.Dto;

namespace Tensee.Banch.Pool
{
    public class PoolAppService : BanchAppServiceBase, IPoolAppService
    {
        private readonly IRepository<MessagePool> _messagePool;
        private readonly IRepository<MessagePoolHistory> _messagePoolHistory;
        private readonly IRepository<WechatConfig> _wechatConfig;
        public PoolAppService(IRepository<MessagePool> messagePool,
            IRepository<MessagePoolHistory> messagePoolHistory,
             IRepository<WechatConfig> wechatConfig)
        {
            _messagePool = messagePool;
            _messagePoolHistory = messagePoolHistory;
            _wechatConfig = wechatConfig;
        }

        /// <summary>
        /// 判断Id是否为空 有就修改没有就添加
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool CreateMessagePool(CreateMessagepoolInput input)
        {
            bool result = false;
            MessagePool pool = new MessagePool();
            pool.Id = input.Id;
            pool.PlatForm = input.PlatForm;
            pool.ModelName = input.ModelName;
            pool.OrtherMsg = input.OrtherMsg;
            pool.Operation = input.Operation;
            pool.JsonText = input.JsonText;
            pool.Status = 0;
            pool.ResultText = input.ResultText;
            var resultdata = _messagePool.Insert(pool);
            if (!string.IsNullOrWhiteSpace(resultdata.ToString()))
            {
                result = true;
            }
            return result;
            //if (true)
            //{
            //    if (input.PoolInfo.Id.HasValue)
            //    {
            //        await UpdateMessagepool(input);
            //    }
            //    else
            //    {
            //        await AddMessagePool(input);
            //    }

            //}
        }

        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PagedResultDto<MessagPeoolDto> GetMessagepool(GetMessagepoolInput input)
        {

            var query = _messagePool
                .GetAll()
                .Where(r => r.CreationTime >= input.StartTime && r.CreationTime <= input.EndTime)
                .WhereIf(input.Status.HasValue, r => r.Status == input.Status.Value)
                .AsNoTracking();//优化读取，不打开存入的通道

            var totalCount = query.Count();

            var data = query
                .OrderBy(r => r.CreationTime)
                .PageBy(input)
                .ToList();

            return new PagedResultDto<MessagPeoolDto>(totalCount, data.MapTo<List<MessagPeoolDto>>());



        }

        ///// <summary>
        ///// 添加
        ///// </summary>
        ///// <param name="input"></param>
        ///// <returns></returns>
        //private  async Task<string> AddMessagePool(CreateMessagepoolInput input) {
        //    var er = "添加成功";
        //    var obj = new MessagePool()
        //    {
        //        PlatForm = input.PoolInfo.PlatForm,
        //        ModelName=input.PoolInfo.ModelName,
        //        OrtherMsg=input.PoolInfo.OrtherMsg,
        //        Operation=input.PoolInfo.Operation,
        //        JsonText=input.PoolInfo.JsonText
        //    };
        //    var add = await _messagePool.InsertAsync(obj);
        //    if (!string.IsNullOrWhiteSpace(add.ToString()))
        //    {
        //        return er;
        //    }
        //    else
        //    {
        //        return er = "添加失败";
        //    }
        //}
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool UpdateMessagepool(CreateMessagepoolInput input)
        {

            var obj = _messagePool.GetAll().Where(t => t.Id == input.Id).FirstOrDefault();
            bool result = false;
            MessagePool pool = new MessagePool();
            pool.Id = input.Id;
            pool.PlatForm = input.PlatForm;
            pool.ModelName = input.ModelName;
            pool.OrtherMsg = input.OrtherMsg;
            pool.Operation = input.Operation;
            pool.JsonText = input.JsonText;
            pool.Status = 0;
            pool.ResultText = input.ResultText;
            var resultdata = _messagePool.Update(pool);
            if (!string.IsNullOrWhiteSpace(resultdata.ToString()))
            {
                result = true;
            }
            return result;


        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task DeleteMessagepool(EntityDto input)
        {
            var obj = _messagePool.GetAll().Where(t => t.Id == input.Id).FirstOrDefault();
            await _messagePool.DeleteAsync(obj);

        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task UpdateMessagepools(EntityDto input)
        {
            var obj = _messagePool.GetAll().Where(t => t.Id == input.Id).FirstOrDefault();
            obj.Status = 0;
            await _messagePool.UpdateAsync(obj);

        }
        /// <summary>
        /// 将对象转换json 或者字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public string FormatToJson<T>(T input)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                json.WriteObject(ms, input);
                string szJson = Encoding.UTF8.GetString(ms.ToArray());
                return szJson;
            }
        }


        public bool InsertMessagePoolHistory(MessagePoolHistoryDto input)
        {
            bool result = false;
            MessagePoolHistory history = new MessagePoolHistory();
            history.PlatForm = input.PlatForm;
            history.ModelName = input.ModelName;
            history.OrtherMsg = input.OrtherMsg;
            history.Operation = input.Operation;
            history.JsonText = input.JsonText;
            history.ResultText = input.ResultText;
            history.Status = input.Status;
            var data = _messagePoolHistory.InsertAsync(history);
            if (data != null)
            {
                result = true;
            }
            return result;
        }

    }
}
