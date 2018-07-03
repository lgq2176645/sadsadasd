using System.ComponentModel.DataAnnotations;

namespace Tensee.Banch.Localization.Dto
{
    public class CreateOrUpdateLanguageInput
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}