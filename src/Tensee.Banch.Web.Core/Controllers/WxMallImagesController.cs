using Abp.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using Tensee.Banch.Mobile.Imgs;

namespace Tensee.Banch.Web.Controllers
{
    /// <summary>
    /// 图片类型
    /// </summary>
    enum ImgType
    {
        /// <summary>
        /// 轮播图
        /// </summary>
        Banner = 4,
        /// <summary>
        /// 商品图
        /// </summary>
        GoodsImg,
        /// <summary>
        /// 品类图
        /// </summary>
        Category,
        /// <summary>
        /// 品牌图
        /// </summary>
        Brand
    }
    public class WxMallImagesController : BanchControllerBase
    {
        private readonly IAppFolders appFolders;
        private readonly IImagesAppService imagesAppService;
        string webRoot;
        private readonly Dictionary<ImageFormat, string> ImgDic = new Dictionary<ImageFormat, string>()
        {
            {ImageFormat.Bmp,".bmp" },
            {ImageFormat.Jpeg, ".jpg" },
            {ImageFormat.Png, ".png" },
            {ImageFormat.Gif,".gif" },
            {ImageFormat.Icon, ".ico" }
        };

        public WxMallImagesController(IAppFolders appFolders, IImagesAppService images, IHostingEnvironment env)
        {
            this.appFolders = appFolders;
            imagesAppService = images;
            webRoot = env.WebRootPath;
        }

        public async Task<JsonResult> OnlyUploadGoodsImg()
        {
            List<string> result = new List<string>();
            var imgFiles = Request.Form.Files;
            if (imgFiles.Count <= 0)
            {
                throw new UserFriendlyException(L("no_any_Img"));
            }
            foreach (var img in imgFiles)
            {
                string filename = Guid.NewGuid().ToString();
                if (!Directory.Exists(appFolders.WxMallGoodsImgFolder))//路径不存在则创建
                {
                    Directory.CreateDirectory(appFolders.WxMallGoodsImgFolder);
                }
                string path = Path.Combine(appFolders.WxMallGoodsImgFolder, filename + ".jpg");

                using (Stream stream = new FileStream(path, FileMode.CreateNew))
                {
                    await img.CopyToAsync(stream);
                }
                result.Add(filename);
            }
            return new JsonResult(result);
        }
        public async Task<JsonResult> OnlyUploadAfterSaleImg()
        {
            List<string> result = new List<string>();
            var imgFiles = Request.Form.Files;
            if (imgFiles.Count <= 0)
            {
                throw new UserFriendlyException(L("no_any_Img"));
            }
            foreach (var img in imgFiles)   
            {
                string filename = Guid.NewGuid().ToString();
                if (!Directory.Exists(appFolders.WxMallAfterSaleImgFolder))//路径不存在则创建
                {
                    Directory.CreateDirectory(appFolders.WxMallAfterSaleImgFolder);
                }
                string path = Path.Combine(appFolders.WxMallAfterSaleImgFolder, filename + ".jpg");

                using (Stream stream = new FileStream(path, FileMode.CreateNew))
                {
                    await img.CopyToAsync(stream);
                }
                result.Add(path.Replace(webRoot, string.Empty).Replace(Path.DirectorySeparatorChar, '/'));
            }
            return new JsonResult(result);
        }
    }
}
