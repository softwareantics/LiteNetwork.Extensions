namespace TestProject.Server.Handlers;

using System.Threading.Tasks;
using LiteNetwork.Extensions.Processing.Contexts;
using LiteNetwork.Extensions.Processing.Handling;
using TestProject.Common;

public sealed class TestPacketHandler : LitePacketHandlerBase<TestPacket>
{
    protected override async Task Handle(TestPacket packet, ILitePacketContext context)
    {
        await Task.Run(() =>
        {
            Console.WriteLine(packet.TestData.ToString());

            var response = new TestPacket()
            {
                TestData = "Ping",
            };

            Thread.Sleep(1000);

            context.Send(response);
        });
    }
}
