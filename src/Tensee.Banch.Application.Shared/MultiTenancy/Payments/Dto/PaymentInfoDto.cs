using Tensee.Banch.Editions.Dto;

namespace Tensee.Banch.MultiTenancy.Payments.Dto
{
    public class PaymentInfoDto
    {
        public EditionSelectDto Edition { get; set; }

        public decimal AdditionalPrice { get; set; }
    }
}
