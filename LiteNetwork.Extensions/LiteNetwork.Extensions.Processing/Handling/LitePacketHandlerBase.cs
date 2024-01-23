// <copyright file="LitePacketHandlerBase.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace LiteNetwork.Extensions.Processing.Handling;

using System;
using System.Threading.Tasks;
using LiteNetwork.Extensions.Processing.Contexts;

/// <summary>
///   Provides an abstract implementation of an <see cref="ILitePacketHandler"/>.
/// </summary>
/// <typeparam name="TPacket">
///   The type of the packet to handle.
/// </typeparam>
/// <seealso cref="ILitePacketHandler"/>
public abstract class LitePacketHandlerBase<TPacket> : ILitePacketHandler
    where TPacket : class
{
    /// <inheritdoc/>
    async Task ILitePacketHandler.Handle(byte[] packetBytes, ILitePacketContext context)
    {
        ArgumentNullException.ThrowIfNull(packetBytes, nameof(packetBytes));
        ArgumentNullException.ThrowIfNull(context, nameof(context));

        var packet = context.Serializer.Deserialize<TPacket>(packetBytes)
            ?? throw new ArgumentException($"Failed to deserialize packet for type: '{typeof(TPacket)}'.", nameof(packetBytes));

        await this.Handle(packet, context).ConfigureAwait(false);
    }

    /// <summary>
    ///   Handles the incoming <paramref name="packet"/> sent by the specified <paramref name="context"/>.
    /// </summary>
    /// <param name="packet">
    ///   The <paramref name="packet"/> that was sent by the specified <paramref name="context"/>.
    /// </param>
    /// <param name="context">
    ///   The <paramref name="context"/> that sent the specified <paramref name="packet"/>.
    /// </param>
    /// <returns>
    ///   The <see cref="Task"/> that represents the asynchronous operation.
    /// </returns>
    protected abstract Task Handle(TPacket packet, ILitePacketContext context);
}
