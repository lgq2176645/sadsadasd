using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using Abp.Extensions;
using Abp.IO.Extensions;
using Abp.Runtime.Session;
using Abp.UI;
using Abp.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Tensee.Banch.Authorization.Users.Profile.Dto;
using Tensee.Banch.IO;
using Tensee.Banch.Web.Helpers;

namespace Tensee.Banch.Web.Controllers
{
    public abstract class ProfileControllerBase : BanchControllerBase
    {
        private readonly IAppFolders _appFolders;
        private const int MaxProfilePictureSize = 5242880; //5MB
      


        protected ProfileControllerBase(IAppFolders appFolders)
        {
            _appFolders = appFolders;
           
        }

        public UploadProfilePictureOutput UploadProfilePicture()
        {
            try
            {
                var profilePictureFile = Request.Form.Files.First();

                //Check input
                if (profilePictureFile == null)
                {
                    throw new UserFriendlyException(L("ProfilePicture_Change_Error"));
                }

                if (profilePictureFile.Length > MaxProfilePictureSize)
                {
                    throw new UserFriendlyException(L("ProfilePicture_Warn_SizeLimit", AppConsts.MaxProfilPictureBytesUserFriendlyValue));
                }

                byte[] fileBytes;
                using (var stream = profilePictureFile.OpenReadStream())
                {
                    fileBytes = stream.GetAllBytes();
                }

                if (!ImageFormatHelper.GetRawImageFormat(fileBytes).IsIn(ImageFormat.Jpeg, ImageFormat.Png, ImageFormat.Gif))
                {
                    throw new Exception("Uploaded file is not an accepted image file !");
                }

                //Delete old temp profile pictures
                AppFileHelper.DeleteFilesInFolderIfExists(_appFolders.TempFileDownloadFolder, "userProfileImage_" + AbpSession.GetUserId());

                //Save new picture
                var fileInfo = new FileInfo(profilePictureFile.FileName);
                var tempFileName = "userProfileImage_" + AbpSession.GetUserId() + fileInfo.Extension;
                var tempFilePath = Path.Combine(_appFolders.TempFileDownloadFolder, tempFileName);
                System.IO.File.WriteAllBytes(tempFilePath, fileBytes);

                using (var bmpImage = new Bitmap(tempFilePath))
                {
                    return new UploadProfilePictureOutput
                    {
                        FileName = tempFileName,
                        Width = bmpImage.Width,
                        Height = bmpImage.Height
                    };
                }
            }
            catch (UserFriendlyException ex)
            {
                return new UploadProfilePictureOutput(new ErrorInfo(ex.Message));
            }
        }

        public UploadProfilePictureOutput UploadProfile()
        {
            try
            {
                var proFile = Request.Form.Files.First();

                if (proFile == null)
                {
                    throw new UserFriendlyException(L("文件不存在"));
                }

                byte[] fileBytes;
                using (var stream = proFile.OpenReadStream())
                {
                    fileBytes = stream.GetAllBytes();
                }


                //Delete old temp profile pictures
                AppFileHelper.DeleteFilesInFolderIfExists(_appFolders.TempFileDownloadFolder, "Profile_" + AbpSession.GetUserId());

                //Save new picture
                var fileInfo = new FileInfo(proFile.FileName);
                var tempFileName = "Profile_" + AbpSession.GetUserId() + fileInfo.Extension;
                var tempFilePath = Path.Combine(_appFolders.TempFileDownloadFolder, tempFileName);
                System.IO.File.WriteAllBytes(tempFilePath, fileBytes);

                    return new UploadProfilePictureOutput
                    {
                        FileName = tempFileName,
                       
                    };
                
            }
            catch (UserFriendlyException ex)
            {
                return new UploadProfilePictureOutput(new ErrorInfo(ex.Message));
            }
        }

        public string CreatePicture()
        {
            var proFile = Request.Form.Files.First();
            if (proFile == null)
            {
                throw new UserFriendlyException(L("文件不存在"));
            }

            byte[] fileBytes;
            using (var stream = proFile.OpenReadStream())
            {
                fileBytes = stream.GetAllBytes();
            }


            //Delete old temp profile pictures
            //AppFileHelper.DeleteFilesInFolderIfExists(_appFolders.TempFileDownloadFolder, "Profile_" + AbpSession.GetUserId());
           
            //Save new picture
            var fileInfo = new FileInfo(proFile.FileName);
            //var tempFileName = "Profile_" + AbpSession.GetUserId() + fileInfo.Extension;
            var tempFileName = proFile.FileName;
            
            var tempFilePath = Path.Combine(_appFolders.ImagesFolder, tempFileName);

            System.IO.File.WriteAllBytes(tempFilePath, fileBytes);
            return tempFileName;
        }
    }
}