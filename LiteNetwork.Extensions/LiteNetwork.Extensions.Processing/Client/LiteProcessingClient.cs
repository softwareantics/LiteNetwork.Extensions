// <copyright file="LiteProcessingClient.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace LiteNetwork.Extensions.Processing.Client;

using System;
using System.Threading.Tasks;
using LiteNetwork.Client;

public class LiteProcessingClient : LiteClient
{
    private readonly ILitePacketExecutor executor;

    public LiteProcessingClient(
        LiteClientOptions options,
        ILitePacketExecutor executor,
        IServiceProvider? serviceProvider = null)
        : base(options, serviceProvider)
    {
        this.executor = executor ?? throw new ArgumentNullException(nameof(executor));
    }

    public override async Task HandleMessageAsync(byte[] packetBuffer)
    {
        ArgumentNullException.ThrowIfNull(packetBuffer, nameof(packetBuffer));
        await this.executor.Execute(packetBuffer, this).ConfigureAwait(false);
    }
}
