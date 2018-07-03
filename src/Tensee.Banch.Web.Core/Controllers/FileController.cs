using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Abp.Auditing;
using Abp.Extensions;
using Abp.IO.Extensions;
using Abp.Runtime.Session;
using Abp.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Tensee.Banch.Authorization.Users.Profile.Dto;
using Tensee.Banch.Dto;
using Tensee.Banch.IO;
using Tensee.Banch.Web.Controllers.Handlers;
using Tensee.Banch.Web.Helpers;

namespace Tensee.Banch.Web.Controllers
{
    public class FileController : BanchControllerBase
    {
        private readonly IAppFolders _appFolders;
        string webRoot;

        public FileController(IAppFolders appFolders, IHostingEnvironment env)
        {
            _appFolders = appFolders;
            webRoot = env.WebRootPath;
        }

        [DisableAuditing]
        public ActionResult DownloadTempFile(FileDto file)
        {
            var filePath = Path.Combine(_appFolders.TempFileDownloadFolder, file.FileToken);
            if (!System.IO.File.Exists(filePath))
            {
                throw new UserFriendlyException(L("RequestedFileDoesNotExists"));
            }

            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            System.IO.File.Delete(filePath);
            return File(fileBytes, file.FileType, file.FileName);
        }

        public async Task<ActionResult> UploadGoods()
        {
            List<string> excels = new List<string>();
            if (!Directory.Exists(_appFolders.WxMallExcelsFolder))
            {
                Directory.CreateDirectory(_appFolders.WxMallExcelsFolder);
            }
            foreach (var file in Request.Form.Files)
            {
                var filePath = Path.Combine(_appFolders.WxMallExcelsFolder, file.FileName);
                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    await file.CopyToAsync(fs);
                }
                excels.Add(filePath);
            }
            return new JsonResult(excels);
        }

        public async Task<ActionResult> UploadProfile()
        {
            var profile = Request.Form.Files.First();
            if (profile == null)
            {
                throw new Exception("Uploaded file is Empty !");
            }
            if (!Directory.Exists(_appFolders.TempFileDownloadFolder))
            {
                Directory.CreateDirectory(_appFolders.TempFileDownloadFolder);
            }
            byte[] fileBytes;
            using (var stream = profile.OpenReadStream())
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
            var fileInfo = new FileInfo(profile.FileName);
            var tempFileName = "userProfileImage_" + AbpSession.GetUserId() + fileInfo.Extension;
            var tempFilePath = Path.Combine(_appFolders.TempFileDownloadFolder, tempFileName);
            await System.IO.File.WriteAllBytesAsync(tempFilePath, fileBytes);
            return new JsonResult(tempFileName);
        }

        #region 木梨谷
        public ActionResult TravelsProcess()
        {
            Handler action;
            switch (Request.Query["action"])
            {
                case "config":
                    action = new ConfigHandler(Request.HttpContext);
                    break;
                case "uploadimage":
                    action = new UploadHandler(Request.HttpContext, new UploadConfig()
                    {
                        AllowExtensions = Config.GetStringList("imageAllowFiles"),
                        PathFormat = Config.GetString("imagePathFormat"),
                        SizeLimit = Config.GetInt("imageMaxSize"),
                        UploadFieldName = Config.GetString("imageFieldName")
                    }, webRoot);
                    break;
                case "uploadscrawl":
                    action = new UploadHandler(Request.HttpContext, new UploadConfig()
                    {
                        AllowExtensions = new string[] { ".png" },
                        PathFormat = Config.GetString("scrawlPathFormat"),
                        SizeLimit = Config.GetInt("scrawlMaxSize"),
                        UploadFieldName = Config.GetString("scrawlFieldName"),
                        Base64 = true,
                        Base64Filename = "scrawl.png"
                    }, webRoot);
                    break;
                case "uploadvideo":
                    action = new UploadHandler(Request.HttpContext, new UploadConfig()
                    {
                        AllowExtensions = Config.GetStringList("videoAllowFiles"),
                        PathFormat = Config.GetString("videoPathFormat"),
                        SizeLimit = Config.GetInt("videoMaxSize"),
                        UploadFieldName = Config.GetString("videoFieldName")
                    }, webRoot);
                    break;
                case "uploadfile":
                    action = new UploadHandler(Request.HttpContext, new UploadConfig()
                    {
                        AllowExtensions = Config.GetStringList("fileAllowFiles"),
                        PathFormat = Config.GetString("filePathFormat"),
                        SizeLimit = Config.GetInt("fileMaxSize"),
                        UploadFieldName = Config.GetString("fileFieldName")
                    }, webRoot);
                    break;
                case "listimage":
                    action = new ListFileManager(Request.HttpContext, Config.GetString("imageManagerListPath"), Config.GetStringList("imageManagerAllowFiles"), webRoot);
                    break;
                case "listfile":
                    action = new ListFileManager(Request.HttpContext, Config.GetString("fileManagerListPath"), Config.GetStringList("fileManagerAllowFiles"), webRoot);
                    break;
                case "catchimage":
                    action = new CrawlerHandler(Request.HttpContext, webRoot);
                    break;
                default:
                    action = new NotSupportedHandler(Request.HttpContext);
                    break;
            }
            return action.Process();
        }
        /// <summary>
        /// 上传多媒体文件
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> UploadMedia()
        {
            long userId = AbpSession.UserId ?? 0;
            List<string> files = new List<string>();
            foreach (var file in Request.Form.Files)
            {
                FileInfo info = new FileInfo(file.FileName);
                string filename = Guid.NewGuid().ToString() + info.Extension;
                var folder = Path.Combine(_appFolders.TravelsMediaFolder, userId.ToString());
                if (!Directory.Exists(folder))//路径不存在则创建
                {
                    Directory.CreateDirectory(folder);
                }
                string path = Path.Combine(folder, filename );
                using (var fs = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(fs);
                    files.Add(path.Replace(webRoot, string.Empty).Replace(Path.DirectorySeparatorChar, '/'));
                }//减去 wwwroot路径，并把分隔符改为/  方便前端直接拼接访问路径
            }
            return new JsonResult(files);
        }

        public async Task<UploadProfilePictureOutput> UploadTravelPic()
        {
            long userId = AbpSession.GetUserId();
            var file = Request.Form.Files.First();
            if (file == null)
            {
                throw new UserFriendlyException(L("ProfilePicture_Change_Error"));
            }
            FileInfo info = new FileInfo(file.FileName);
            string filename = Guid.NewGuid().ToString() + info.Extension;
            var folder = Path.Combine(_appFolders.TravelsMediaFolder, userId.ToString());
            if (!Directory.Exists(folder))//路径不存在则创建
            {
                Directory.CreateDirectory(folder);
            }
            string path = Path.Combine(folder, filename);
            using (var fs = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fs);
            }

            using (var bmpImage = new Bitmap(path))
            {
                return new UploadProfilePictureOutput
                {
                    FileName = path,
                    Width = bmpImage.Width,
                    Height = bmpImage.Height
                };
            }
        }


        #endregion


    }
}