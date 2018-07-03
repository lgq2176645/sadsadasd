using System;
using System.Collections.Generic;
using System.Text;

namespace Tensee.Banch.Mobile.MobielUsers.Dto
{
   public class WxHarvestAddressDto
    {
        public int Id { get; set; }
        public string Consignee { get; set; }
        public string Phone { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public int AreaId { get; set; }
        public string AddressInfo { get; set; }
        public bool IsDefault { get; set; }
        public int ZipPostalCode { get; set; }
        public int UserId { get; set; }
        public string City { get; set; }
    }
}
