using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;

namespace SK.Basic.Front;

public sealed class ConsoleService(
    Kernel kernel,
    ILogger<ConsoleService> logger) :
    BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("ConsoleService started.");
        FunctionResult result = await kernel.InvokePromptAsync(
            "Write a haiku about Semantic Kernel.",
            cancellationToken: stoppingToken);

        Console.WriteLine("Result: {0}", result);
    }
}
