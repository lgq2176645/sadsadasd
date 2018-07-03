using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.Mobile.Orders.Dto
{
    public class CreateCommentInput
    {
        //public int UserId { get; set; }
        public string SessionId { get; set; }
        public int OrderId { get; set; }
        public string Title { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
    }
}
