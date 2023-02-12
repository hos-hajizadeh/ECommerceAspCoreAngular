using ECommerce.Catalog.Data.Persistence.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Catalog.Data
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddCatalogDataServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<CatalogContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

            services.AddMediatR(typeof(DependencyInjectionExtensions));

            return services;
        }
    }
}