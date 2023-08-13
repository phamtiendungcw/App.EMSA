using EMSA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EMSA.WebUI
{
    public class TenantDbContextFactory : IDesignTimeDbContextFactory<TenantDbContext>
    {
        public TenantDbContext CreateDbContext(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json", optional: true);
            var configuration = configurationBuilder.Build();
            var connectionString = configuration.GetConnectionString("TenantConnection");
            var dbContextOptionBuilder = new DbContextOptionsBuilder<TenantDbContext>();
            dbContextOptionBuilder.UseSqlServer(connectionString);

            return new TenantDbContext(dbContextOptionBuilder.Options);
        }
    }
}
