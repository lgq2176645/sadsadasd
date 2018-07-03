using Abp.AutoMapper;
using Tensee.Banch.Authorization.Users;
using Tensee.Banch.Authorization.Users.Dto;
using Tensee.Banch.Web.Areas.AppAreaName.Models.Common;

namespace Tensee.Banch.Web.Areas.AppAreaName.Models.Users
{
    [AutoMapFrom(typeof(GetUserPermissionsForEditOutput))]
    public class UserPermissionsEditViewModel : GetUserPermissionsForEditOutput, IPermissionsEditViewModel
    {
        public User User { get; private set; }

        public UserPermissionsEditViewModel(GetUserPermissionsForEditOutput output, User user)
        {
            User = user;
            output.MapTo(this);
        }
    }
}