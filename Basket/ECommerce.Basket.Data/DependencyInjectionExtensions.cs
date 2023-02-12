using MediatR;
using ECommerce.Basket.Data.Persistence.DbContexts;
using ECommerce.Basket.Data.Repositories;
using ECommerce.Basket.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Basket.Data
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddBasketDataServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<BasketContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddMediatR(typeof(DependencyInjectionExtensions));

            return services;
        }
    }
}