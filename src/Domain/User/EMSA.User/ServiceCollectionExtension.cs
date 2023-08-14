using EMSA.User.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EMSA.User
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddUserServices(this IServiceCollection services)
        {
            return services.AddScoped<IUserService, UserService>();
        }
    }
}
