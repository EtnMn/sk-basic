using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.AzureOpenAI;

namespace SK.Basic.Front;

public sealed class ConsoleService(
    Kernel kernel,
    ILogger<ConsoleService> logger) :
    BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("Console started.");

        // Invoke basic prompt.
        FunctionResult intro = await kernel.InvokePromptAsync("Introduce yourself.", cancellationToken: stoppingToken);

        // Create a semantic function from a prompt.
        string prompt = await File.ReadAllTextAsync("Prompts/historical_fact_today.txt", stoppingToken);
        KernelFunction factFunction = KernelFunctionFactory.CreateFromPrompt(
            prompt,
            executionSettings: new AzureOpenAIPromptExecutionSettings()
            {
                MaxTokens = 500,
                Temperature = 0.7,
                TopP = 0.7,
            });

        // Create a classic function.
        KernelFunction dateFunction = kernel.Plugins[Plugins.DatePlugin.Key]["get_utc_now_date"];
        FunctionResult date = await kernel.InvokeAsync(dateFunction, cancellationToken: stoppingToken);
        FunctionResult text = await kernel.InvokeAsync(
            factFunction,
            new KernelArguments() { ["today"] = date },
            cancellationToken: stoppingToken);

        Console.WriteLine("{0} {1}", intro.GetValue<string>(), text.GetValue<string>());
        Console.WriteLine("---");

        // Invoke prompt with auto function choice behavior.
        PromptExecutionSettings settings = new()
        {
            FunctionChoiceBehavior = FunctionChoiceBehavior.Auto(),
        };

        FunctionResult resultPromptFunction = await kernel.InvokePromptAsync(
            prompt,
            new(settings),
            cancellationToken: stoppingToken);

        Console.WriteLine("{0}", resultPromptFunction.GetValue<string>());
    }
}
