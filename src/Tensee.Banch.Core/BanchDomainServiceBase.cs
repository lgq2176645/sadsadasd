using Abp.Domain.Services;

namespace Tensee.Banch
{
    public abstract class BanchDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected BanchDomainServiceBase()
        {
            LocalizationSourceName = BanchConsts.LocalizationSourceName;
        }
    }
}
