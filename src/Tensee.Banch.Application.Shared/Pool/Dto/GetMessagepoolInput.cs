using System;
using System.Collections.Generic;
using System.Text;
using Tensee.Banch.Dto;

namespace Tensee.Banch.Pool.Dto
{
   public class GetMessagepoolInput: PagedInputDto
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int? Status { get; set; }
    }
}
