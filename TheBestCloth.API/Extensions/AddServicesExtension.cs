using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheBestCloth.API.AppSettingsModel;
using TheBestCloth.API.Interfaces;
using TheBestCloth.API.Service;
using TheBestCloth.BLL.Interfaces;
using TheBestCloth.DAL.Repositories;

namespace TheBestCloth.API.Extensions
{
    public static class AddServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IShoppingItemRepository, ShoppingItemRepository>();
            services.AddScoped<IShoppingItemsService, ShoppingItemsService>();
            services.AddScoped<ICloudinaryService, CloudinaryService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ITokenService, TokenService>();
            services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings"));

            return services;
        }
    }
}
