using System.ComponentModel.DataAnnotations;

namespace Tensee.Banch.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
