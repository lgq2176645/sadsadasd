using System.ComponentModel.DataAnnotations;

namespace Tensee.Banch.Web.Models.Account
{
    public class SendPasswordResetLinkViewModel
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}