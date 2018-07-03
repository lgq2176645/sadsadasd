using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tensee.Banch.DictionaryData.Dto;

namespace Tensee.Banch.DictionaryData
{
    public class DictionaryAppService : BanchAppServiceBase, IDictionaryAppService
    {
        private readonly IRepository<Dictionary> _dictionary;
        public DictionaryAppService(IRepository<Dictionary> dictionary)
        {
            _dictionary = dictionary;
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public ListResultDto<GetDictionaryOutput> GetDictionary()
        {
            var data = (from a in _dictionary.GetAll()
                        where a.ParentID == 0
                        select new GetDictionaryOutput
                        {
                            Id=a.Id,
                            ParentID = a.ParentID,
                            Title = a.Title,
                            Value = a.Value,
                            Label= a.Title,
                            Data = a.Value,
                            Note = a.Note,
                            Code = a.Code,
                            Other = a.Other,
                            Sort = a.Sort,
                            ExpandedIcon="",
                            CollapsedIcon = "",
                            ChildrenCount = _dictionary.GetAll().Where(r=>r.ParentID==a.Id).Count()
                        }).ToList();

            return new ListResultDto<GetDictionaryOutput>(data);


        }
 

        public   ListResultDto<GetDictionaryOutput> GetDictionariesByParentID(DictionaryDto input)
        {
            var data = (from a in _dictionary.GetAll()
                       where a.ParentID == input.Id
                        select new GetDictionaryOutput
                        {
                            Id = a.Id,
                            ParentID = a.ParentID,
                            Title = a.Title,
                            Value = a.Value,
                            Label = a.Title,
                            Data = a.Value,
                            Note = a.Note,
                            Code = a.Code,
                            Other = a.Other,
                            Sort = a.Sort,
                            ExpandedIcon = "",
                            CollapsedIcon = "",
                            ChildrenCount = _dictionary.GetAll().Where(r => r.ParentID == a.Id).Count()
                        }).ToList();

            return new ListResultDto<GetDictionaryOutput>(data);
        }


        public ListResultDto<GetDictionary> GetDictionaryToChildren(DictionaryDto input)
        {
            List<Dictionary> list = new List<Dictionary>();
            var id = input.ParentID;//获取子父节点

            if (id == 0)
            {
                var demos = _dictionary.GetAll().Where(t => t.Id == input.Id).ToList();
                foreach (var item in demos)
                {
                    Dictionary node = new Dictionary();
                    node.Id = item.Id;
                    node.ParentID = item.ParentID != null ? item.ParentID : 0;
                    node.Title = item.Title;
                    node.Value = item.Value;
                    node.Note = item.Note;
                    node.Code = item.Code;
                    node.Other = item.Other;
                    node.Sort = item.Sort;
                    list.Add(node);
                }
            }
            var demo = _dictionary.GetAll().Where(t => t.ParentID == id).ToList();//查询子节点
            foreach (var item in demo)
            {
                Dictionary node = new Dictionary();
                node.Id = item.Id;
                node.ParentID = item.ParentID != null ? item.ParentID : 0;
                node.Title = item.Title;
                node.Value = item.Value;
                node.Note = item.Note;
                node.Code = item.Code;
                node.Other = item.Other;
                node.Sort = item.Sort;
                list.Add(node);
            }
            return new ListResultDto<GetDictionary>(ObjectMapper.Map<List<GetDictionary>>(list));
        }
        /// <summary>
        /// 根据value查出子节点
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ListResultDto<GetDictionary> GetDictionarByValue(GetDictionarvInput input)
        {

            var node = _dictionary.GetAll().Where(t => t.Value == input.Value).ToList().FirstOrDefault();
            if (node==null)
            {
                string result = string.Format("数据字典没有唯一值为{0}的节点",input.Value);
                throw new UserFriendlyException(L(result));
            }
            var data = _dictionary.GetAll().Where(r => r.ParentID == node.Id).ToList();
         
            return new ListResultDto<GetDictionary>(ObjectMapper.Map<List<GetDictionary>>(data));

        }

        public async Task<GetDictionaryOutput> CreateOrUpdateDictionary(CreateOrEditDictionaryInput input)
        {
            if (input.Id.HasValue)
            {
                return await UpdateDictionary(input);
            }
            else
            {
                return await CreateDictionary(input);
            }

        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected virtual async Task<GetDictionaryOutput> UpdateDictionary(CreateOrEditDictionaryInput input)
        {

            //System.Diagnostics.Debug.Assert(input.id != null, "input.id should be set.");
            if (!input.Id.HasValue)
            {
                throw new Exception("id 必须输入");
            }
            var dic = await _dictionary.GetAsync(input.Id.Value);
            var cnt = _dictionary.GetAll().FirstOrDefault(r => (r.Value == input.Value.Trim()&&r.ParentID==input.ParentID && r.Id != input.Id));
            if (cnt != null)
            {
                throw new Exception("值"+input.Value+"已存在");
            }
            ObjectMapper.Map(input, dic);
            await _dictionary.UpdateAsync(dic);
            var data = from a in _dictionary.GetAll()
                        where a.Id == input.Id
                        select new GetDictionaryOutput
                        {
                            Id = a.Id,
                            ParentID = a.ParentID,
                            Title = a.Title,
                            Value = a.Value,
                            Label = a.Title,
                            Data = a.Value,
                            Note = a.Note,
                            Code = a.Code,
                            Other = a.Other,
                            Sort = a.Sort,
                            ExpandedIcon = "",
                            CollapsedIcon = "",
                            ChildrenCount = _dictionary.GetAll().Where(r => r.ParentID == a.Id).Count()
                        };

            return data.FirstOrDefault();

        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected virtual async Task<GetDictionaryOutput> CreateDictionary(CreateOrEditDictionaryInput input)
        {
            Dictionary dic = new Dictionary();
            var cnt = _dictionary.GetAll().FirstOrDefault(r => (r.Value == input.Value.Trim() && r.ParentID == input.ParentID));
            if (cnt != null)
            {
                throw new Exception("值" + input.Value + "已存在");
            }
            ObjectMapper.Map(input, dic);
            var id = _dictionary.InsertAndGetIdAsync(dic);
            var data = from a in _dictionary.GetAll()
                       where a.Id == id.Result
                       select new GetDictionaryOutput
                       {
                           Id = a.Id,
                           ParentID = a.ParentID,
                           Title = a.Title,
                           Value = a.Value,
                           Label = a.Title,
                           Data = a.Value,
                           Note = a.Note,
                           Code = a.Code,
                           Other = a.Other,
                           Sort = a.Sort,
                           ExpandedIcon = "",
                           CollapsedIcon = "",
                           ChildrenCount = _dictionary.GetAll().Where(r => r.ParentID == a.Id).Count()
                       };

            return await data.FirstOrDefaultAsync();

        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// 
        public async Task DeleteDictionary(EntityDto input)
        {
            var obj = await _dictionary.GetAsync(input.Id);
            var data = _dictionary.DeleteAsync(obj);
            await _dictionary.DeleteAsync(obj);
        }

        /// <summary>
        /// 移动字典顺序 如果直接传入sort顺序值则不对IsUp上下移动1处理
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task MoveDicSort(MoveDicInput input)
        {
            Dictionary dic = _dictionary.Get(input.Id);
            int totalCount = await _dictionary.CountAsync(d => d.ParentID == dic.ParentID);
            if (input.Sort.HasValue)
            {
                if (input.Sort <= totalCount && input.Sort >= 1) dic.Sort = input.Sort.Value;
            }
            else
            {
                if (input.IsUp && dic.Sort > 1)
                {
                    var last = _dictionary.GetAll().Where(a => a.ParentID == dic.ParentID && a.Sort < dic.Sort).OrderByDescending(a => a.Sort).First();
                    int sort_t = last.Sort;
                    last.Sort = dic.Sort;
                    dic.Sort = sort_t;
                }
                    
                else if (!input.IsUp && dic.Sort < totalCount)
                {
                    var last = _dictionary.GetAll().Where(a => a.ParentID == dic.ParentID && a.Sort > dic.Sort).OrderBy(a => a.Sort).First();
                    int sort_t = last.Sort;
                    last.Sort = dic.Sort;
                    dic.Sort = sort_t;
                }

                    
            }
        }
    }
}
