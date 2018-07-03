﻿using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Tensee.Banch.Configuration.Host.Dto;
using Tensee.Banch.Editions.Dto;

namespace Tensee.Banch.Web.Areas.AppAreaName.Models.HostSettings
{
    public class HostSettingsViewModel
    {
        public HostSettingsEditDto Settings { get; set; }

        public List<SubscribableEditionComboboxItemDto> EditionItems { get; set; }

        public List<ComboboxItemDto> TimezoneItems { get; set; }
    }
}