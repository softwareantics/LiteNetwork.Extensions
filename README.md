# LiteNetwork.Extensions

[LiteNetwork](https://github.com/Eastrall/LiteNetwork) is great, this repository aims to make it a little more awesome with some additional features.

## Features

### Simple Packet Handling

With [LiteNetwork.Extensions](https://github.com/softwareantics/LiteNetwork.Extensions/) you can easily send and receive packets via the packet handling feature. Setup is super simple, the steps are as follows:

1. Initialize the packet handling feature via `ILiteBuilder.UsePacketHandling()`.
2. Specify what kind of serialization you want (currently only JSON is provided but you can implement your own via `ILitePacketSerializer`).
3. Finally, for each packet you wish to handle register a packet handler via `ILiteBuilder.RegisterPacketHandler<TPacket, TPacketHandler>()`

Below, you'll find a simple example:

```csharp
using LiteNetwork.Hosting;
using LiteNetwork.Server.Hosting;
using LiteNetwork.Extensions.Processing.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

var host = new HostBuilder()
    // Configures the LiteNetwork context.
    .ConfigureLiteNetwork((context, builder) =>
    {
        // Add the server or client here...

        builder.UsePacketHandling();
        builder.UseJsonPacketSerialization();
        builder.RegisterPacketHandler<TestPacket, TestPacketHandler>();
    })
    .UseConsoleLifetime()
    .Build();

await host.RunAsync();
```

And of course, the packet and packet handler classes:

```csharp
public class TestPacket
{
    public string SomeTestData { get; set; }
}

public class TestPacketHandler : LitePacketHandlerBase<TestPacket>
{
    protected override async Task Handle(TPacket packet, ILitePacketContext context)
    {
        // Run CPU bound if you like.
        await Task.Run(() =>
        {
            Console.WriteLine(packet.SomeTestData);

            // Now let's send a response.
            context.Send(new TestPacket()
            {
                SomeTestData = "LiteNetwork is Awesome!",
            });
        });
    }
}
```

## Build Instructions

Below is a list of prerequisites and build instructions.

### Prerequisites

 - [.NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

### Building on Windows, Mac, and Linux

1. Download or clone the repository.
2. Open `LiteNetwork.Extensions.sln` in your preferred IDE.
3. Build the solution (or use `dotnet build`).

### Download

- Release builds will be accessible on GitHub and as NuGet packages.
