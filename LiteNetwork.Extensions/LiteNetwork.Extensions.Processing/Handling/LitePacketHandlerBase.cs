// <copyright file="LitePacketHandlerBase.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace LiteNetwork.Extensions.Processing.Handling;

using System;
using System.Threading.Tasks;
using LiteNetwork.Extensions.Processing.Contexts;

public abstract class LitePacketHandlerBase<TPacket> : ILitePacketHandler
    where TPacket : class
{
    async Task ILitePacketHandler.Handle(byte[] packetBytes, ILitePacketContext context)
    {
        ArgumentNullException.ThrowIfNull(packetBytes, nameof(packetBytes));
        ArgumentNullException.ThrowIfNull(context, nameof(context));

        var packet = context.Serializer.Deserialize<TPacket>(packetBytes)
            ?? throw new ArgumentException($"Failed to deserialize packet for type: '{typeof(TPacket)}'.", nameof(packetBytes));

        await this.Handle(packet, context).ConfigureAwait(false);
    }

    protected internal abstract Task Handle(TPacket packet, ILitePacketContext context);
}
