using Tensee.Banch.Dto;

namespace Tensee.Banch.Common.Dto
{
    public class FindUsersInput : PagedAndFilteredInputDto
    {
        public int? TenantId { get; set; }
    }
}