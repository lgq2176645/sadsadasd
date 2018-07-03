using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.DictionaryData.Dto
{

    public  class DictionaryDto
    {

        /// <summary>
        /// 节点id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 节点父级ID
        /// </summary>
        public int? ParentID { get; set; }

    }
}
