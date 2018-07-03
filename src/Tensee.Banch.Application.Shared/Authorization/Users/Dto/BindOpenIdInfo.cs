using System.ComponentModel.DataAnnotations;

namespace Tensee.Banch.Authorization.Users.Dto
{
    public class BindOpenIdInfo
    {
        /// <summary>
        /// 同一账号主体下的用户唯一ID
        /// </summary>
        [MaxLength(50)]
        public string UnionId { get; set; }
        /// <summary>
        /// 小程序OpenId
        /// </summary>
        [MaxLength(50)]
        public string MiniProgramOpenId { get; set; }
        /// <summary>
        /// 公众号OpenId
        /// </summary>
        [MaxLength(50)]
        public string PublicAccoutOpenId { get; set; }
        /// <summary>
        /// 小游戏OpenId
        /// </summary>
        [MaxLength(50)]
        public string MiniGameOpenId { get; set; }
    }
}
