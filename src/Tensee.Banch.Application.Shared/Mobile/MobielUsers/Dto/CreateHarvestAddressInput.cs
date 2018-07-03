using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.Mobile.MobielUsers.Dto
{
    public class CreateHarvestAddressInput
    {
        /// <summary>
        /// 收货人
        /// </summary>
        public string Consignee { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 省份ID
        /// </summary>
        //public int ProvinceId { get; set; }
        ///// <summary>
        ///// 地区ID
        ///// </summary>
        //public int CityId { get; set; }
        ///// <summary>
        ///// 区域ID
        ///// </summary>
        //public int AreaId { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string AddressInfo { get; set; }
        /// <summary>
        /// 是否默认选中
        /// </summary>
        public bool IsDefault { get; set; }
        /// <summary>
        /// 邮政编码
        /// </summary>
        public int ZipPostalCode { get; set; }
        //public int UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SessionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string City { get; set; }
    }
}
