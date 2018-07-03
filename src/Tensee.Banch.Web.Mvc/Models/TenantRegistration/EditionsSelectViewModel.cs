using Abp.AutoMapper;
using Tensee.Banch.MultiTenancy.Dto;

namespace Tensee.Banch.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(EditionsSelectOutput))]
    public class EditionsSelectViewModel : EditionsSelectOutput
    {
        public EditionsSelectViewModel(EditionsSelectOutput output)
        {
            output.MapTo(this);
        }
    }
}
