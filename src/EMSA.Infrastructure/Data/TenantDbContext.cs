using EMSA.Core.Entities;
using EMSA.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EMSA.Infrastructure.Data
{
    public class TenantDbContext : DbContext
    {
        public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}