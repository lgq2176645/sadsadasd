using Abp.Application.Services.Dto;

namespace Tensee.Banch.Organizations.Dto
{
    public class OrganizationUnitDto : AuditedEntityDto<long>
    {
        public long? ParentId { get; set; }

        public string Code { get; set; }

        public string DisplayName { get; set; }

        public int MemberCount { get; set; }

        public int Depth { get; set; }

        public string Number { get; set; }

        public string Leader { get; set; }

        public bool IsShop { get; set; }

        public int Status { get; set; }

    }
}