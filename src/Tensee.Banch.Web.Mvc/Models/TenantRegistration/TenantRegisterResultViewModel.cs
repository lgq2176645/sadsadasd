using Abp.AutoMapper;
using Tensee.Banch.MultiTenancy.Dto;

namespace Tensee.Banch.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(RegisterTenantOutput))]
    public class TenantRegisterResultViewModel : RegisterTenantOutput
    {
        public string TenantLoginAddress { get; set; }
    }
}