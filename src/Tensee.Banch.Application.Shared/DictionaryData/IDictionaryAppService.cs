using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tensee.Banch.DictionaryData.Dto;

namespace Tensee.Banch.DictionaryData
{
   public  interface IDictionaryAppService: IApplicationService
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        // Task<ListResultDto<GetDictionaryTree>> GetDictionary();
        ListResultDto<GetDictionaryOutput> GetDictionary();

        ListResultDto<GetDictionaryOutput> GetDictionariesByParentID(DictionaryDto input);
        ListResultDto<GetDictionary> GetDictionaryToChildren(DictionaryDto input);
  
        /// <summary>
        /// 根据value查出子节点
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        ListResultDto<GetDictionary> GetDictionarByValue(GetDictionarvInput input);
        /// <summary>
        /// 添加/修改字典项
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetDictionaryOutput> CreateOrUpdateDictionary(CreateOrEditDictionaryInput input);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteDictionary(EntityDto input);
        /// <summary>
        /// 更改字典排序
        /// </summary>
        /// <returns></returns>
        Task MoveDicSort(MoveDicInput input);
    }
}
