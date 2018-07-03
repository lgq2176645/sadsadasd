using System;
using System.Collections.Generic;
using System.Text;
using Tensee.Banch.Dto;

namespace Tensee.Banch.Mobile.Orders.Dto
{
    public class GetAllCommentInput : PagedAndSortedInputDto
    {
        public int Id { get; set; }
    }
}
