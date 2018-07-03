using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tensee.Banch.OrganizationUnits.Wechat.Dto;

namespace Tensee.Banch.OrganizationUnits.Wechat
{
  public  class WechatAppService: BanchAppServiceBase,IWechatAppService
    {
        private readonly IRepository<WechatConfig> _wechat;
        public WechatAppService(IRepository<WechatConfig> wechat)
        {
            _wechat = wechat;
        }

        public WechatConfigDto GetWechatConfigByID(EntityDto input) {
            var obj = _wechat.GetAll().Where(t => t.Id == input.Id).FirstOrDefault();
            if (obj==null)
            {
                return null;
            }
            return ObjectMapper.Map<WechatConfigDto>(obj);
        }

        public List<WechatConfigDto> GetWechatConfigAll() {
            var data = (from a in _wechat.GetAll()
                        select a.MapTo<WechatConfigDto>()).ToList();
            if (data.Count<=0)
            {

                return null;
            }
            return data;
        }


        public async Task  CreateOrUpdateWechatConfig(List<WechatConfigDto> input)
        {
            //_wechat.Delete(r => 1 == 1);
            foreach (var item in input)
            {
            
                if (item.Id>0)
                {
                    var re = _wechat.GetAll().AsNoTracking().Where(r => r.Id == item.Id).FirstOrDefault();
                    re.Name = item.Name;
                    re.PageName = item.PageName;
                    re.PageRuslt = item.PageRuslt;
                    re.Value = item.Value;
                    re.AgentId = item.AgentId;
                    re.Secret = item.Secret;
                    await _wechat.UpdateAsync(re);
                }
                else
                {
                    WechatConfig wechat = new WechatConfig
                    {
                        Name = item.Name,
                        PageName = item.PageName,
                        PageRuslt = item.PageRuslt,
                        Value = item.Value,
                        AgentId = item.AgentId,
                        Secret = item.Secret
                    };
                    await _wechat.InsertAsync(wechat);
                }
               
            }
            //foreach (var item in input)
            //{
            //    if (item.Id==0)
            //    {
            //        WechatConfig wechat = new WechatConfig();
            //        ObjectMapper.Map(wechat, item);
            //        await _wechat.InsertAsync(wechat);
            //    }
            //    else
            //    {
            //        WechatConfig wechat = new WechatConfig();
            //        ObjectMapper.Map(wechat, item);
            //        await _wechat.UpdateAsync(wechat);
            //    }
            //}

            //List<WechatConfig> config = new List<WechatConfig>();
            //if (input.Count>0)
            //{
            //    ObjectMapper.Map(input, config);
            //    foreach (var item in config)
            //    {
            //        await _wechat.InsertOrUpdateAsync(item);
            //    }
            //}
            //if (input.Id.HasValue)
            //{
            //    return await UpdateWechatConfig(input);
            //}
            //else
            //{
            //    return await CreateWechatConfig(input);
            //}
        }
        //protected virtual async Task<WechatConfigDto> CreateWechatConfig(CreateOrUpdateWechatConfigInput inpu)
        //{
        //    WechatConfig data = new WechatConfig();
        //    ObjectMapper.Map(inpu, data);
        //    await _wechat.InsertAsync(data);
        //    return data.MapTo<WechatConfigDto>();

        //}

        //protected virtual async Task<WechatConfigDto> UpdateWechatConfig(CreateOrUpdateWechatConfigInput input)
        //{
        //    if (!input.Id.HasValue)
        //    {
        //        throw new Exception("Id必须输入");
        //    }
        //    var data = await _wechat.GetAsync(input.Id.Value);
        //    ObjectMapper.Map(input, data);
        //    await _wechat.UpdateAsync(data);
        //    return data.MapTo<WechatConfigDto>();
        //}
        ////    public WechatConfigDto CreateOrUpdateWechatConfig(CreateOrUpdateWechatConfigInput input) {
        ////    WechatConfig Wechat = new WechatConfig
        //    {
        //        Id = input.Id,
        //        AgentId = input.AgentId,
        //        Name = input.Name,
        //        Secret = input.Secret,
        //        Value = input.Value,
        //    };

        //    var data = _wechat.InsertOrUpdate(Wechat);
        //    return ObjectMapper.Map<WechatConfigDto>(Wechat);

        //}

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task <WechatConfigDto> DeleteWechatConfig(EntityDto input)
        {
            var obj = await _wechat.GetAsync(input.Id);
            var data = _wechat.DeleteAsync(obj);
            //await _wechat.DeleteAsync(obj);
            return ObjectMapper.Map<WechatConfigDto>(obj);
        }
        
    }
}
