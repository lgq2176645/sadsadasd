using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Abp;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.AspNetZeroCore.Net;
using Abp.Auditing;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.IO.Extensions;
using Abp.Runtime.Session;
using Abp.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tensee.Banch.Authorization.Users;
using Tensee.Banch.Friendships;
using Tensee.Banch.IO;
using Tensee.Banch.Storage;

namespace Tensee.Banch.Web.Controllers
{
    [AbpMvcAuthorize]
    [DisableAuditing]
    public class ProfileController : ProfileControllerBase
    {
        private readonly UserManager _userManager;
        private readonly IBinaryObjectManager _binaryObjectManager;
        private readonly IFriendshipManager _friendshipManager;
        //private readonly IRepository<Images> _images;
        private readonly IRepository<BinaryObject, Guid> _binaryObjectRepository;
      

        public ProfileController(
                UserManager userManager,
                IBinaryObjectManager binaryObjectManager,
                IAppFolders appFolders,
                IFriendshipManager friendshipManager,
                //IRepository<Images> _images,
                IRepository<BinaryObject, Guid> _binaryObjectRepository
            ) : base(
                appFolders
            )
        {
            _userManager = userManager;
            _binaryObjectManager = binaryObjectManager;
            _friendshipManager = friendshipManager;
            //this._images = _images;
            this._binaryObjectRepository = _binaryObjectRepository;
        }

        public async Task<FileResult> GetProfilePicture()
        {
            var user = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());
            if (user.ProfilePictureId == null)
            {
                return GetDefaultProfilePicture();
            }

            return await GetProfilePictureById(user.ProfilePictureId.Value);
        }

        public async Task<FileResult> GetProfilePictureById(string id = "")
        {
            
            if (id.IsNullOrEmpty())
            {
                return GetDefaultProfilePicture();
            }

            return await GetProfilePictureById(Guid.Parse(id));
        }

        [UnitOfWork]
        public virtual async Task<FileResult> GetFriendProfilePictureById(long userId, int? tenantId, string id = "")
        {
            if (id.IsNullOrEmpty() ||
                await _friendshipManager.GetFriendshipOrNullAsync(AbpSession.ToUserIdentifier(), new UserIdentifier(tenantId, userId)) == null)
            {
                return GetDefaultProfilePicture();
            }

            using (CurrentUnitOfWork.SetTenantId(tenantId))
            {
                return await GetProfilePictureById(Guid.Parse(id));
            }
        }

        private FileResult GetDefaultProfilePicture()
        {
            return File(
                @"Common\Images\default-profile-picture.png",
                MimeTypeNames.ImagePng
            );
        }

        private async Task<FileResult> GetProfilePictureById(Guid profilePictureId)
        {
            var file = await _binaryObjectManager.GetOrNullAsync(profilePictureId);
            if (file == null)
            {
                return GetDefaultProfilePicture();
            }

            return File(file.Bytes, MimeTypeNames.ImageJpeg);
        }

        //public async Task<FileResult> GetPicture(int id)
        //{

        //    var data = await _images.GetAsync(id);

        //    //var file = await _binaryObjectRepository.GetAll().(t => t.Id.ToString().ToLower() == data.ProfilePictureId.ToString());
        //    //var file = await _binaryObjectManager.GetOrNullAsync(data.ProfilePictureId.Value);
        //    //StreamWriter sw = new StreamWriter("D:\\3.txt");
        //    //sw.Write(file.Bytes);
        //    //sw.Close();
        //    if (data == null)
        //    {
        //        return GetDefaultProfilePicture();
        //    }
        //    return File(data.Bytes, MimeTypeNames.ImageJpeg);
        //}
        //public string CreatePicture() {
        //    var proFile = Request.Form.Files.First();
        //    if (proFile == null)
        //    {
        //        throw new UserFriendlyException(L("文件不存在"));
        //    }

        //    byte[] fileBytes;
        //    using (var stream = proFile.OpenReadStream())
        //    {
        //        fileBytes = stream.GetAllBytes();
        //    }


        //    //Delete old temp profile pictures
        //    AppFileHelper.DeleteFilesInFolderIfExists(_appFolders.TempFileDownloadFolder, "Profile_" + AbpSession.GetUserId());
        //    string path = Path.Combine(_env.WebRootPath, $"Temp{Path.DirectorySeparatorChar}Images");
        //    //Save new picture
        //    var fileInfo = new FileInfo(proFile.FileName);
        //    //var tempFileName = "Profile_" + AbpSession.GetUserId() + fileInfo.Extension;
        //    var tempFileName = proFile.FileName;
           
        //    var tempFilePath = Path.Combine(path, tempFileName);
                          
        //    System.IO.File.WriteAllBytes(tempFilePath, fileBytes);
        //    return tempFileName;
        //}
    }
}