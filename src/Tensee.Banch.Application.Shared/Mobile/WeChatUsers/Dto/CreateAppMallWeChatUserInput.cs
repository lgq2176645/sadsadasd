using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.Mobile.WeChatUsers.Dto
{
  public  class CreateAppMallWeChatUserInput
    {
        /// <summary>
        /// 微信昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 微信用户头像
        /// </summary>
        public string AvatarUrl { get; set; }
        /// <summary>
        /// 微信性别
        /// </summary>
        public int Gender { get; set; }
        //public string OpenId { get; set; }

        public string Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string user_info { get; set; }

        public string encrypted_data { get; set; }
        /// <summary>
        /// 解密
        /// </summary>
        public string iv { get; set; }

        public string signature { get; set; }
    }
}
