using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.Organizations.Dto
{
   public class UpdateWXOrganizationInput
    {
        public string name { get; set; }

        public int parentid { get; set; }

        public int order { get; set; }

        public string id { get; set; }
    }
}
