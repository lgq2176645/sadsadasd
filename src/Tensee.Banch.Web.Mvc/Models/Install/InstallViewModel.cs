using System.Collections.Generic;
using Abp.Localization;
using Tensee.Banch.Install.Dto;

namespace Tensee.Banch.Web.Models.Install
{
    public class InstallViewModel
    {
        public List<ApplicationLanguage> Languages { get; set; }

        public AppSettingsJsonDto AppSettingsJson { get; set; }
    }
}
