using System.Threading.Tasks;
using Abp.EntityFrameworkCore;
using Tensee.Banch.EntityFrameworkCore;
using Tensee.Banch.EntityFrameworkCore.Repositories;

namespace Tensee.Banch.MultiTenancy.Payments
{
    public class SubscriptionPaymentRepository : BanchRepositoryBase<SubscriptionPayment, long>, ISubscriptionPaymentRepository
    {
        public SubscriptionPaymentRepository(IDbContextProvider<BanchDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<SubscriptionPayment> UpdateByGatewayAndPaymentIdAsync(SubscriptionPaymentGatewayType gateway, string paymentId, int? tenantId, SubscriptionPaymentStatus status)
        {
            var payment = await SingleAsync(p => p.PaymentId == paymentId && p.Gateway == gateway);

            payment.Status = status;

            if (tenantId.HasValue)
            {
                payment.TenantId = tenantId.Value;
            }

            return payment;
        }

        public async Task<SubscriptionPayment> GetByGatewayAndPaymentIdAsync(SubscriptionPaymentGatewayType gateway, string paymentId)
        {
            return await SingleAsync(p => p.PaymentId == paymentId && p.Gateway == gateway);
        }
    }
}
