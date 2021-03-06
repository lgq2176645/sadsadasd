﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.DictionaryData.Dto
{
   public class CreateOrEditDictionaryInput
    {
        /// <summary>
        /// 节点Id
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// 节点父级ID
        /// </summary>
        public int ParentID { get; set; }

        /// <summary>
        /// 节点标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 唯一标识值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 备注说明
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 其他信息
        /// </summary>
        public string Other { get; set; }

        /// <summary>
        /// 排在节点的第几位
        /// </summary>
        public int Sort { get; set; }
    }
}
