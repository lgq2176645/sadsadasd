using System.ComponentModel.DataAnnotations;
using Abp.Organizations;

namespace Tensee.Banch.Organizations.Dto
{
    public class CreateOrganizationUnitInput
    {
        public long? ParentId { get; set; }

        [Required]
        [StringLength(OrganizationUnit.MaxDisplayNameLength)]
        public string DisplayName { get; set; }


        public string Leader { get; set; }

  
        public bool IsShop { get; set; }

      
        public int Status { get; set; }
    }
}