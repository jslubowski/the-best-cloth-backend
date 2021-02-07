using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheBestCloth.DAL.Interfaces;
using TheBestCloth.DAL.Repositories;

namespace TheBestCloth.API.Extensions
{
    public static class AddServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IShoppingItemRepository, ShoppingItemRepository>();

            return services;
        }
    }
}
