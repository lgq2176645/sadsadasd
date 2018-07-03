using Abp.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.Mobile.Orders.Dto
{

    public class CommentDto : AbpModule
    {
        
        public int UserId { get; set; }
        
        public int OrderId { get; set; }
        public string Title { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public virtual string NickName { get; set; }
    }
}
