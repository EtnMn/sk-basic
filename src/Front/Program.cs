using Microsoft.Extensions.Hosting;
using SK.Basic.Front.Configurations;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddOptionConfigurations()
    .AddServiceConfigurations();

IHost host = builder.Build();

await host.RunAsync();
