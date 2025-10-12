using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.SemanticKernel;

namespace SK.Basic.Front.Configurations;

public static class ServiceConfigurations
{
    public static IServiceCollection AddServiceConfigurations(
        this IServiceCollection services)
    {
        services.AddSingleton(provider =>
        {
            IOptions<SemanticKernelOptions> options = provider.GetRequiredService<IOptions<SemanticKernelOptions>>();

            IKernelBuilder builder = Kernel.CreateBuilder();
            string openAiKey = options.Value.ApiKey;
            string endpoint = options.Value.Endpoint;
            string modelId = options.Value.DeploymentName;

            builder.Services.AddLogging();

            builder.AddAzureOpenAIChatCompletion(modelId, endpoint, openAiKey);

            return builder.Build();
        });

        services.AddHostedService<ConsoleService>();

        return services;
    }
}
