using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Tensee.Banch.Configuration;
using Tensee.Banch.Web;

namespace Tensee.Banch.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class BanchDbContextFactory : IDesignTimeDbContextFactory<BanchDbContext>
    {
        public BanchDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BanchDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder(), addUserSecrets: true);

            BanchDbContextConfigurer.Configure(builder, configuration.GetConnectionString(BanchConsts.ConnectionStringName));

            return new BanchDbContext(builder.Options);
        }
    }
}