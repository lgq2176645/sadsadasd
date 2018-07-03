using Abp.AutoMapper;
using Tensee.Banch.Authorization.Roles.Dto;
using Tensee.Banch.Web.Areas.AppAreaName.Models.Common;

namespace Tensee.Banch.Web.Areas.AppAreaName.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class CreateOrEditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool IsEditMode
        {
            get { return Role.Id.HasValue; }
        }

        public CreateOrEditRoleModalViewModel(GetRoleForEditOutput output)
        {
            output.MapTo(this);
        }
    }
}