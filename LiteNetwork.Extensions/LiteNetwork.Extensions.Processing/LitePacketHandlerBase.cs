// <copyright file="LitePacketHandlerBase.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace LiteNetwork.Extensions.Processing;

using System;
using System.Threading.Tasks;
using LiteNetwork.Extensions.Processing.Serialization;
using LiteNetwork.Server;

//// TODO: Create a way to manager sending and receiving data in both the server and the client in packet handler
//// TODO: Maybe separating into LiteServerPacketHandlerBase and LiteClientPacketHandlerBase

public abstract class LiteServerPacketHandlerBase<TPacket> : LitePacketHandlerBase<TPacket>
{
    protected internal override Task Handle(TPacket packet)
    {
        this.Handle(packet, this.context);
        throw new NotImplementedException();
    }

    protected abstract Task Handle(TPacket packet, LiteServerContext context);
}

public abstract class LitePacketHandlerBase<TPacket> : ILitePacketHandler
{
    async Task ILitePacketHandler.Handle(byte[] packetBytes, ILitePacketSerializer serializer)
    {
        ArgumentNullException.ThrowIfNull(packetBytes, nameof(packetBytes));
        ArgumentNullException.ThrowIfNull(serializer, nameof(serializer));

        var packet = serializer.Deserialize<TPacket>(packetBytes)
            ?? throw new ArgumentException($"Failed to deserialize packet for type: '{typeof(TPacket)}'.", nameof(packetBytes));

        await this.Handle(packet).ConfigureAwait(false);
    }

    protected internal abstract Task Handle(TPacket packet);
}
