using System.ComponentModel.DataAnnotations;

namespace Tensee.Banch.Authorization.Accounts.Dto
{
    public class SendEmailActivationLinkInput
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}