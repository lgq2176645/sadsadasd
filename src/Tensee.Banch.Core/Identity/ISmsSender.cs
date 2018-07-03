using System.Threading.Tasks;

namespace Tensee.Banch.Identity
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
        
    }
}