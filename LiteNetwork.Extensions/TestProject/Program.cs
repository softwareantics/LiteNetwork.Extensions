namespace TestProject;

using LiteNetwork.Extensions.Processing.Extensions;
using LiteNetwork.Hosting;
using LiteNetwork.Server.Hosting;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static async Task Main()
    {
        var services = new ServiceCollection();

        services.UseLiteNetwork(x =>
        {
            x.AddLiteServer<TestServer>(x =>
            {
                x.Host = "127.0.0.1";
                x.Port = 44444;
            });
        });

        services.RegisterPacketHandler<TestPacket, TestServerPacketHandler>();

        var server = services.BuildServiceProvider().GetRequiredService<TestServer>();

        await server.StartAsync().ConfigureAwait(true);

        while (server.IsRunning)
        {
            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                await server.StopAsync().ConfigureAwait(true);
            }
        }
    }
}
