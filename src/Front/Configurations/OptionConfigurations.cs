using Microsoft.Extensions.DependencyInjection;

namespace SK.Basic.Front.Configurations;

public static class OptionConfigurations
{
    public static IServiceCollection AddOptionConfigurations(this IServiceCollection services)
    {
        services
          .AddOptionsWithValidateOnStart<SemanticKernelOptions>()
          .BindConfiguration(SemanticKernelOptions.Key)
          .ValidateDataAnnotations();

        return services;
    }
}
