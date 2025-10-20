using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.SemanticKernel;
using SK.Basic.Front.Plugins;

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

            builder.AddAzureOpenAIChatCompletion(modelId, endpoint, openAiKey);

            // Option 1: Add plugin from type.
            // builder.Plugins.AddFromType<DatePlugin>(DatePlugin.Key);

            Kernel kernel = builder.Build();

            // Option 2: Add plugin from object.
            kernel.ImportPluginFromObject(new DatePlugin(), DatePlugin.Key);

            return kernel;
        });

        services.AddHostedService<ConsoleService>();

        return services;
    }
}
