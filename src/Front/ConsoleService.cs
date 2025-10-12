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
        logger.LogInformation("Console started.");

        FunctionResult text = await kernel.InvokePromptAsync("Introduce the current date.", cancellationToken: stoppingToken);

        KernelFunction dateFunction = kernel.Plugins[Plugins.DatePlugin.Key]["get_utc_now_date"];
        FunctionResult date = await kernel.InvokeAsync(dateFunction, cancellationToken: stoppingToken);

        Console.WriteLine("{0}. Date: {1}", text, date);
    }
}
