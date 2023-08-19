namespace EMSA.WebUI.Services
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInternalServices(this IServiceCollection services, IConfiguration config)
        {
            return services
                .Configure<TokenSetting>(config.GetSection("JwtToken"))
                .AddScoped<ITokenService, TokenService>();
        }
    }
}