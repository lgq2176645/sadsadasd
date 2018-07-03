namespace Tensee.Banch.Mobile.WeChatUsers.Dto
{
    public class CreateAppWeChatUserInput
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
    }
}
