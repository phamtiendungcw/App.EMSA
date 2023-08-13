using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace EMSA.Data
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, string connectionString,
            bool sensitiveDataLogging, bool detailError)
        {
            return services
                .AddTenantContext(connectionString, sensitiveDataLogging, detailError)
                .AddScoped<ITenantDbContextFactory, TenantDbContextFactory>();
        }

        private static IServiceCollection AddTenantContext(this IServiceCollection services, string connectionString,
            bool sensitiveDataLogging, bool detailError)
        {
#if DEBUG
            sensitiveDataLogging = true;
            detailError = true;
#endif

            return services.AddDbContextFactory<TenantDbContext>(builder =>
            {
                builder.UseSqlServer(connectionString)
                    .EnableDetailedErrors(detailError)
                    .EnableSensitiveDataLogging(sensitiveDataLogging)
#if DEBUG
                    .LogTo(x => Debug.WriteLine(x));
#endif
            });
        }
    }
}