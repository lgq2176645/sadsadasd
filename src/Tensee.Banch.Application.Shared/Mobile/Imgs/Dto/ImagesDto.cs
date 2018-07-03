using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.Mobile.Imgs.Dto
{
    public class ImagesDto
    {
        public int? Id { get; set; }
        //public Guid? ProfilePictureId { get; set; }
        public int Sort { get; set; }
        /// <summary>
        /// 0轮播图/1属性图
        /// </summary>
        public int ImgType { get; set; }
        //public  byte[] Bytes { get; set; }
        public string FileName { get; set; }

        public string Code { get; set; }

    }
}
