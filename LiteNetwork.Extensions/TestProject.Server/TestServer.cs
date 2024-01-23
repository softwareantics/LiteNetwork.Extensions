namespace TestProject.Server;

using System;
using LiteNetwork.Server;

public sealed class TestServer : LiteServer<TestServerUser>
{
    public TestServer(LiteServerOptions options, IServiceProvider? serviceProvider = null)
        : base(options, serviceProvider)
    {
    }
}
