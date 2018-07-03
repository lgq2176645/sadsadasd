using Abp.AspNetCore.Mvc.Authorization;
using Abp.AspNetZeroCore.Net;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tensee.Banch.Storage;

namespace Tensee.Banch.Web.Controllers
{
    [AbpMvcAuthorize]
    public class ProfileController : ProfileControllerBase
    {
        private readonly IBinaryObjectManager _binaryObjectManager;

        public ProfileController(IAppFolders appFolders, IBinaryObjectManager binaryObjectManager)
            : base(appFolders)
        {
            _binaryObjectManager = binaryObjectManager;

        }

        public async Task<FileResult> GetPicture(Guid profilePictureId)
        {
            var file = await _binaryObjectManager.GetOrNullAsync(profilePictureId);
            if (file == null)
            {
                return GetDefaultProfilePicture();
            }

            return File(file.Bytes, MimeTypeNames.ImageJpeg);
        }

        private FileResult GetDefaultProfilePicture()
        {
            return File(
                @"Common\Images\default-profile-picture.png",
                MimeTypeNames.ImagePng
            );
        }
    }
}