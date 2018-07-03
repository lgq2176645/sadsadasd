using Abp.UI;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tensee.Banch.Mobile.WeChatUsers.Dto
{
    public class WeChatUserDto
    {
        int? parentId;
        bool? canCreate;
        public int? Id { get; set; }
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

        /// <summary>
        /// 合伙人Id
        /// </summary>
        public int? PartnerId { get; set; }
        /// <summary>
        /// 上级Code
        /// </summary>
        public string PartnerCode { get; set; }
        /// <summary>
        /// 用户编码
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// 是否可以发展下线
        /// </summary>
        public bool? CanCreate {
            get => canCreate;
            set
            {
                if (PartnerId == null && value == null)//如果父节点id和是否能发展下线同时为空则抛出异常
                {
                    throw new UserFriendlyException("Can not Empty Value");
                }
                canCreate = value;
            }
        }
        /// <summary>
        /// 用户微信唯一标识符
        /// </summary>
        public string OpenId { get; set; }
        /// <summary>
        /// 代理级别
        /// </summary>
        public byte AgentClass { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [MaxLength(20)]
        public string Name { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 品牌状态
        /// </summary>
        public List<brandrstatus> BrandInfo { get; set; }

    }
    public class brandrstatus {

        /// <summary>
        /// 品牌
        /// </summary>
        public string brand { get; set; }
        /// <summary>
        /// 品牌状态
        /// </summary>
        public bool Whether { get; set; }
      //  public bool id { get; set; }
    }
}
