using System.Threading.Tasks;
using Abp.Dependency;

namespace Tensee.Banch.MultiTenancy.Accounting
{
    public interface IInvoiceNumberGenerator : ITransientDependency
    {
        Task<string> GetNewInvoiceNumber();
    }
}