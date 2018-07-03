using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.Mobile.Goods.Dto
{
    public class GoodsDto
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }
        public int ProjectId { get; set; }
        public int MobileId { get; set; }
    }
}
