using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.Organizations.Dto
{
    public  class GetOrganizationUnitsAndUsersOutput
    {
        public int OrganizationId { get; set; }

        public string OrganizationName { get; set; }

        public List<OrganizationUsers> OrganizationUsers { get; set; }

        public GetOrganizationUnitsAndUsersOutput[] Children { get; set; }
    }
}
