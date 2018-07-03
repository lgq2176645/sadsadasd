using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Tensee.Banch.EntityFrameworkCore
{
    public static class BanchDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<BanchDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<BanchDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}