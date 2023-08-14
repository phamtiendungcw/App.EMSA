namespace EMSA.WebUI.Services
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInternalServices(this IServiceCollection services)
        {
            return services.AddScoped<ITokenService, TokenService>();
        }
    }
}
