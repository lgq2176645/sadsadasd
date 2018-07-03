using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tensee.Banch.Wechat
{
    /// <summary>
    /// 微信用户信息
    /// </summary>
    public class WeChatUser : Entity, IHasCreationTime, ISoftDelete
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
        /// 微信性别 0:男 1:女
        /// </summary>
        public int Gender { get; set; }
        /// <summary>
        /// 微信账号唯一Id
        /// </summary>
        public string OpenId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
        /// <summary>
        /// 软删除
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 用户编码 最长20
        /// </summary>
        [MaxLength(20)]
        public string UserCode { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [MaxLength(20)]
        public string Phone { get; set; }
        /// <summary>
        /// ABP框架的用户Id
        /// </summary>
        public long UserId { get; set; }
    }
}
