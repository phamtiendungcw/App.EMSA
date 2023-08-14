using EMSA.Core.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EMSA.Core
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions<TokenSetting>("JwtToken");

            return services;
        }
    }
}
