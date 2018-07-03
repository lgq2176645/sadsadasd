using System.Threading.Tasks;
using Tensee.Banch.Sessions.Dto;

namespace Tensee.Banch.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
