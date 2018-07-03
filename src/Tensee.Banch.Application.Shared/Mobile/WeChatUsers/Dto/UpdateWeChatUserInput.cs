using System.ComponentModel.DataAnnotations;

namespace Tensee.Banch.Mobile.WeChatUsers
{
    public class UpdateWeChatUserInput
    {
        /// <summary>
        /// 本用户Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 是否可以发展下线
        /// </summary>
        public bool CanCreate { get; set; }
        /// <summary>
        /// 用户编码
        /// </summary>
        public string UserCode { get; set; }

        /// <summary>
        /// 代理级别
        /// </summary>
        public byte AgentClass { get; set; }
        /// <summary>
        /// 用户真实姓名
        /// </summary>
        [MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        public string PartnerCode { get; set; }
        public string SaleBrand { get; set; }
    }
}