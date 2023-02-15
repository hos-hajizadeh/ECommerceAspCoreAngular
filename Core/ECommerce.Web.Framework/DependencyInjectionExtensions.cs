using ECommerce.Share.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Web.Framework;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddWebFrameworkServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IWorkContext, WorkContext>();
        return services;
    }
}