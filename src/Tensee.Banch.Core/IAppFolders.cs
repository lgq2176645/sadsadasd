namespace Tensee.Banch
{
    public interface IAppFolders
    {
        string TempFileDownloadFolder { get; }

        string SampleProfileImagesFolder { get; }

        string WebLogsFolder { get; set; }
        string ImagesFolder { get;  }
        /// <summary>
        /// 商品图片路径
        /// </summary>
        string WxMallGoodsImgFolder { get; }
        /// <summary>
        /// 品牌图片路径
        /// </summary>
        string WxMallBrandImgFolder { get; }
        string WxMallAfterSaleImgFolder { get; }
        /// <summary>
        /// 品类图片路径
        /// </summary>
        string WxMallCategoryImgFolder { get; }
        /// <summary>
        /// 轮播图路径
        /// </summary>
        string WxMallBannerImgFolder { get; }
        /// <summary>
        /// 导入数据excel的路径
        /// </summary>
        string WxMallExcelsFolder { get; }
        /// <summary>
        /// 木梨谷多媒体路径
        /// </summary>
        string TravelsMediaFolder { get; }

    }
}