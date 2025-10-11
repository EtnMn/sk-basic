using Microsoft.Extensions.DependencyInjection;

namespace SK.Basic.Front.Configurations;

public static class ServiceConfigurations
{
    public static IServiceCollection AddServiceConfigurations(this IServiceCollection services)
    {
        services.AddHostedService<SemanticKernelService>();

        return services;
    }
}
