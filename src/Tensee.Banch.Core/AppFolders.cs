using Abp.Dependency;

namespace Tensee.Banch
{
    public class AppFolders : IAppFolders, ISingletonDependency
    {
        public string TempFileDownloadFolder { get; set; }

        public string SampleProfileImagesFolder { get; set; }

        public string WebLogsFolder { get; set; }
        public string ImagesFolder { get; set; }
        /// <summary>
        /// 商品图片路径
        /// </summary>
        public string WxMallGoodsImgFolder { get; set; }
        /// <summary>
        /// 品牌图片路径
        /// </summary>
        public string WxMallBrandImgFolder { get; set; }
        /// <summary>
        /// 品类图片路径
        /// </summary>
        public string WxMallCategoryImgFolder { get; set; }
        /// <summary>
        /// 轮播图路径
        /// </summary>
        public string WxMallBannerImgFolder { get; set; }
        /// <summary>
        /// 导入数据excel的路径
        /// </summary>
        public string WxMallExcelsFolder { set; get; }

        public string TravelsMediaFolder { set; get; }
        /// <summary>
        /// 售后凭证
        /// </summary>
        public string WxMallAfterSaleImgFolder { set; get; }
    }
}