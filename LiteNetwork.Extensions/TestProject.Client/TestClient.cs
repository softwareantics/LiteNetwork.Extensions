namespace TestProject.Client;

using System;
using LiteNetwork.Client;
using LiteNetwork.Extensions.Processing;
using LiteNetwork.Extensions.Processing.Client;
using LiteNetwork.Extensions.Processing.Serialization;
using TestProject.Common;

public sealed class TestClient : LiteProcessingClient
{
    public TestClient(LiteClientOptions options, ILitePacketExecutor executor, IServiceProvider? serviceProvider = null) : base(options, executor, serviceProvider)
    {
    }

    protected override void OnConnected()
    {
        var serializer = new LiteJsonPacketSerializer();

        var packet = new TestPacket()
        {
            TestData = "Ping",
        };

        byte[] result = serializer.Serialize(packet);

        this.Send(result);

        base.OnConnected();
    }
}
