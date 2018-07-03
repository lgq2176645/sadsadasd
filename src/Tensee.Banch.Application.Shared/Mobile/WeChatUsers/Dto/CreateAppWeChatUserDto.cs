namespace Tensee.Banch.Mobile.WeChatUsers.Dto
{
    public  class CreateAppWeChatUserDto
    {

        public string Key { get; set; }
        /// <summary>
        /// 微商城用户信息
        /// </summary>
        public WxMallUser_info User_info { get; set; }

        public string encrypted_data { get; set; }
        /// <summary>
        /// 解密
        /// </summary>
        public string iv { get; set; }

        public string signature { get; set; }
        
        public int? AgentClass { get; set; }

    }

    public class WxMallUser_info
    {
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 客户编码
        /// </summary>
        public string UserCode { get; set; }

        /// <summary>
        /// 代理级别 
        /// </summary>
        public byte? WxMallAgentClass { get; set; }
    }
}
