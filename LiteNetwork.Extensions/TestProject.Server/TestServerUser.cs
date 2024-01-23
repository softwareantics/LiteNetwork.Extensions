namespace TestProject.Server;

using LiteNetwork.Extensions.Processing;
using LiteNetwork.Extensions.Processing.Server;

public sealed class TestServerUser : LiteProcessingServerUser
{
    public TestServerUser(ILitePacketExecutor executor)
        : base(executor)
    {
    }
}
