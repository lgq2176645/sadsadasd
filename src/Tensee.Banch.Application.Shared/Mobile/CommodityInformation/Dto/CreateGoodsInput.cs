using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.Mobile.CommodityInformation.Dto
{
    public class CreateGoodsInput
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }
        /// <summary>
        /// 项目
        /// </summary>
        public int ProjectId { get; set; }
        /// <summary>
        /// 型号
        /// </summary>
        public int MobileId { get; set; }
    }
}
