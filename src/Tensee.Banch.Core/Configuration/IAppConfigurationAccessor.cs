using Microsoft.Extensions.Configuration;

namespace Tensee.Banch.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
