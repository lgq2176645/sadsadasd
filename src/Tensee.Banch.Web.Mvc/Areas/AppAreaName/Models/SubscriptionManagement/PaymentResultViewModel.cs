using Abp.AutoMapper;
using Tensee.Banch.Editions;
using Tensee.Banch.MultiTenancy.Payments.Dto;

namespace Tensee.Banch.Web.Areas.AppAreaName.Models.SubscriptionManagement
{
    [AutoMapTo(typeof(ExecutePaymentDto))]
    public class PaymentResultViewModel : SubscriptionPaymentDto
    {
        public EditionPaymentType EditionPaymentType { get; set; }
    }
}