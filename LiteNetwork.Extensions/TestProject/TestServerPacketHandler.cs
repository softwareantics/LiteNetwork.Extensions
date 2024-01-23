namespace TestProject;

using System.Threading.Tasks;
using LiteNetwork.Extensions.Processing.Server;

public sealed class TestServerPacketHandler : LiteServerPacketHandlerBase<TestServerUser, TestPacket>
{
    public TestServerPacketHandler(TestServerUser serverUser)
        : base(serverUser)
    {
    }

    protected override Task Handle(TestPacket packet)
    {
        ArgumentNullException.ThrowIfNull(packet, nameof(packet));

        Console.WriteLine(packet.TestData);

        return Task.CompletedTask;
    }
}
