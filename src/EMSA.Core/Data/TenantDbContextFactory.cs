using Microsoft.EntityFrameworkCore;

namespace EMSA.Core.Data
{
    public interface ITenantDbContextFactory : IDbContextFactory<TenantDbContext>
    {
    }

    public class TenantDbContextFactory : ITenantDbContextFactory
    {
        private readonly DbContextOptions<TenantDbContext> _options;

        public TenantDbContextFactory(DbContextOptions<TenantDbContext> options)
        {
            _options = options;
        }

        public TenantDbContext CreateDbContext()
        {
            var db = new TenantDbContext(_options);

            // TODO: Config db

            return db;
        }
    }
}