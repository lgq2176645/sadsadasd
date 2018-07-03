using Abp.AutoMapper;
using Tensee.Banch.MultiTenancy;
using Tensee.Banch.MultiTenancy.Dto;
using Tensee.Banch.Web.Areas.AppAreaName.Models.Common;

namespace Tensee.Banch.Web.Areas.AppAreaName.Models.Tenants
{
    [AutoMapFrom(typeof (GetTenantFeaturesEditOutput))]
    public class TenantFeaturesEditViewModel : GetTenantFeaturesEditOutput, IFeatureEditViewModel
    {
        public Tenant Tenant { get; set; }

        public TenantFeaturesEditViewModel(Tenant tenant, GetTenantFeaturesEditOutput output)
        {
            Tenant = tenant;
            output.MapTo(this);
        }
    }
}