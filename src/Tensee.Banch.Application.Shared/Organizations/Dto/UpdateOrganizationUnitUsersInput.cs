using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tensee.Banch.Organizations.Dto
{
    public class UpdateOrganizationUnitUsersInput
    {
        public long? UserId { get; set; }

        public string Name { get; set; }

        public string Sex { get; set; }

        public string Age { get; set; }

        public string LevelDesc { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public int RoleId { get; set; }

        [Range(1, long.MaxValue)]
        public long OrganizationUnitId { get; set; }
    }
}
