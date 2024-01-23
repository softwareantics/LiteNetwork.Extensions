namespace TestProject.Server;

using LiteNetwork.Extensions.Processing.Extensions;
using LiteNetwork.Hosting;
using LiteNetwork.Server.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TestProject.Common;
using TestProject.Server.Handlers;

internal static class Program
{
    private static async Task Main()
    {
        var host = new HostBuilder()
            .ConfigureLogging(x =>
            {
                x.SetMinimumLevel(LogLevel.Trace);
                x.AddConsole();
            })
            .ConfigureLiteNetwork(x =>
            {
                x.AddLiteServer<TestServer>(options =>
                {
                    options.Host = "127.0.0.1";
                    options.Port = 44444;
                });

                x.UsePacketHandling();
                x.RegisterPacketHandler<TestPacket, TestPacketHandler>();
            })
            .UseConsoleLifetime()
            .Build();

        await host.RunAsync();
    }
}
