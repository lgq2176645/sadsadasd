using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.QYWechat.Dto.Agent
{
   public  class UploadMedia
    {
        /// <summary>
        /// 媒体文件类型，分别有图片（image）、语音（voice）、视频（video），普通文件(file)
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 文件绝对路径
        /// </summary>
        public string filenPath { get; set; }

    }
}
