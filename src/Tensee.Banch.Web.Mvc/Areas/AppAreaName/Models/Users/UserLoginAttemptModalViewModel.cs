using System.Collections.Generic;
using Tensee.Banch.Authorization.Users.Dto;

namespace Tensee.Banch.Web.Areas.AppAreaName.Models.Users
{
    public class UserLoginAttemptModalViewModel
    {
        public List<UserLoginAttemptDto> LoginAttempts { get; set; }
    }
}