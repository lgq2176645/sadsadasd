using Abp.AutoMapper;
using Tensee.Banch.Sessions.Dto;

namespace Tensee.Banch.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}