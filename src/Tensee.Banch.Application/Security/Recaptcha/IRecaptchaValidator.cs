using System.Threading.Tasks;

namespace Tensee.Banch.Security.Recaptcha
{
    public interface IRecaptchaValidator
    {
        Task ValidateAsync(string captchaResponse);
    }
}