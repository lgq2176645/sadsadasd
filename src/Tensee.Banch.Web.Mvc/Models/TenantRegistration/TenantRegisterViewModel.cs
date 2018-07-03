using Tensee.Banch.Editions;
using Tensee.Banch.Editions.Dto;
using Tensee.Banch.Security;
using Tensee.Banch.MultiTenancy.Payments;
using Tensee.Banch.MultiTenancy.Payments.Dto;

namespace Tensee.Banch.Web.Models.TenantRegistration
{
    public class TenantRegisterViewModel
    {
        public PasswordComplexitySetting PasswordComplexitySetting { get; set; }

        public int? EditionId { get; set; }

        public string PaymentId { get; set; }

        public SubscriptionPaymentGatewayType? Gateway { get; set; }

        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }

        public bool ShowPaymentExpireNotification()
        {
            return !string.IsNullOrEmpty(PaymentId);
        }
    }
}
