using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace Tensee.Banch.Web.Areas.AppAreaName.Models.Roles
{
    public class RoleListViewModel
    {
        public List<ComboboxItemDto> Permissions { get; set; }
    }
}