using EMSA.Product.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EMSA.Product
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddProductServices(this IServiceCollection services)
        {
            return services.AddScoped<IProductService, ProductService>();
        }
    }
}