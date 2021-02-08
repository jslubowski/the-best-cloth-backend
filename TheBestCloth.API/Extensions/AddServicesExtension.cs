﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheBestCloth.BLL.Interfaces;
using TheBestCloth.BLL.Service;
using TheBestCloth.DAL.Interfaces;
using TheBestCloth.DAL.Repositories;

namespace TheBestCloth.API.Extensions
{
    public static class AddServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IShoppingItemRepository, ShoppingItemRepository>();
            services.AddScoped<IShoppingItemsService, ShoppingItemsService>();

            return services;
        }
    }
}
