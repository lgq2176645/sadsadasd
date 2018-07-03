using System.IO;
using System.Threading.Tasks;
using Tensee.Banch.Authorization.Users.Profile.Dto;

namespace Tensee.Banch.Authorization.Users.Profile
{
    public class ProxyProfileControllerService : ProxyControllerBase
    {
        public async Task<UploadProfilePictureOutput> UploadProfilePicture(Stream stream, string fileName)
        {
            return await ApiClient
                .PostMultipartAsync<UploadProfilePictureOutput>(GetEndpoint(nameof(UploadProfilePicture)), stream, fileName);
        }
    }
}