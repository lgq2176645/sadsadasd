using System.Threading.Tasks;
using Tensee.Banch.ApiClient.Models;

namespace Tensee.Banch.ApiClient
{
    public interface IAccessTokenManager
    {
        Task<string> GetAccessTokenAsync();
         
        Task<AbpAuthenticateResultModel> LoginAsync();

        void Logout();

        bool IsUserLoggedIn { get; }
    }
}