using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Tensee.Banch.Configuration.Tenants.Dto;

namespace Tensee.Banch.Web.Areas.AppAreaName.Models.Settings
{
    public class SettingsViewModel
    {
        public TenantSettingsEditDto Settings { get; set; }
        
        public List<ComboboxItemDto> TimezoneItems { get; set; }
    }
}