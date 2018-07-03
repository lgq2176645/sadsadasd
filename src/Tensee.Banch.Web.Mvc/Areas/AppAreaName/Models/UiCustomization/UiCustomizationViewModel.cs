using Tensee.Banch.Configuration.Dto;

namespace Tensee.Banch.Web.Areas.AppAreaName.Models.UiCustomization
{
    public class UiCustomizationViewModel
    {
        public UiCustomizationSettingsEditDto Settings { get; set; }

        public bool HasUiCustomizationPagePermission { get; set; }
    }
}
