using System.Collections.Generic;
using Tensee.Banch.Authorization.Permissions.Dto;

namespace Tensee.Banch.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}