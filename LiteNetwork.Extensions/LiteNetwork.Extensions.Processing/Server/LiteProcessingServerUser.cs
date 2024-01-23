// <copyright file="LiteProcessingServerUser.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace LiteNetwork.Extensions.Processing.Server;

using System;
using System.Threading.Tasks;
using LiteNetwork.Server;

public class LiteProcessingServerUser : LiteServerUser
{
    private readonly ILitePacketExecutor executor;

    public LiteProcessingServerUser(ILitePacketExecutor executor)
    {
        this.executor = executor ?? throw new ArgumentNullException(nameof(executor));
    }

    public override async Task HandleMessageAsync(byte[] packetBuffer)
    {
        ArgumentNullException.ThrowIfNull(packetBuffer, nameof(packetBuffer));
        await this.executor.Execute(packetBuffer, this).ConfigureAwait(false);
    }
}
