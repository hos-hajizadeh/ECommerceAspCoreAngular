using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Catalog.Application;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddCatalogApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMediatR(typeof(DependencyInjectionExtensions));
        return services;
    }
}