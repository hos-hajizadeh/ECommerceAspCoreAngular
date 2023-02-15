using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Basket.Application;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddBasketApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMediatR(typeof(DependencyInjectionExtensions));
        return services;
    }
}