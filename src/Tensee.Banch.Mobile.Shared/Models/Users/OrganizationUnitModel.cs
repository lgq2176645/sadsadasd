using Abp.AutoMapper;
using Tensee.Banch.Organizations.Dto;

namespace Tensee.Banch.Models.Users
{
    [AutoMapFrom(typeof(OrganizationUnitDto))]
    public class OrganizationUnitModel : OrganizationUnitDto
    {
        public bool IsAssigned { get; set; }
    }
}