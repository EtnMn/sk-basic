using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SK.Basic.Front.Configurations;

namespace SK.Basic.Front;

public sealed class SemanticKernelService(
    IOptions<SemanticKernelOptions> options,
    ILogger<SemanticKernelService> logger) :
    BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("Key: {Key}", options.Value.ApiKey);
        await Task.FromResult(0);
    }
}
