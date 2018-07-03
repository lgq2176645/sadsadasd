using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.QYWechat.Dto.Agent
{
    public class SetAgentInput
    {
        /// <summary>
        /// 企业应用的id
        /// </summary>
        public string agentid { get; set; }

        /// <summary>
        /// 企业应用是否打开地理位置上报 0：不上报；1：进入会话上报；
        /// </summary>
        public string report_location_flag { get; set; }

        /// <summary>
        /// 企业应用头像的mediaid，通过素材管理接口上传图片获得mediaid，上传后会自动裁剪成方形和圆形两个头像
        /// </summary>
        public string logo_mediaid { get; set; }

        /// <summary>
        /// 企业应用名称，长度不超过32个字符
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 企业应用详情，长度为4至120个字符
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// 企业应用可信域名。注意：域名需通过所有权校验，否则jssdk功能将受限，此时返回错误码85005
        /// </summary>
        public string redirect_domain { get; set; }

        /// <summary>
        /// 是否上报用户进入应用事件。0：不接收；1：接收。
        /// </summary>
        public string isreportenter { get; set; }

        /// <summary>
        /// 应用主页url。url必须以http或者https开头。
        /// </summary>
        public string home_url { get; set; }
    }
}
