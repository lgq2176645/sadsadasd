using System.Collections.Generic;
using Tensee.Banch.Authorization.Permissions.Dto;

namespace Tensee.Banch.Web.Areas.AppAreaName.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}