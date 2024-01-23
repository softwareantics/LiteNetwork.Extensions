// <copyright file="LitePacketContext.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace LiteNetwork.Extensions.Processing.Contexts;

using System;
using LiteNetwork;
using LiteNetwork.Extensions.Processing.Extensions;
using LiteNetwork.Extensions.Processing.Serialization;

/// <summary>
///   Provides a standard implementation of an <see cref="ILitePacketContext"/> that represents the context that sent a packet.
/// </summary>
/// <seealso cref="LiteNetwork.Extensions.Processing.Contexts.ILitePacketContext"/>
internal sealed class LitePacketContext : ILitePacketContext
{
    /// <summary>
    ///   Initializes a new instance of the <see cref="LitePacketContext"/> class.
    /// </summary>
    /// <param name="connection">
    ///   The connection that sent the packet.
    /// </param>
    /// <param name="serializer">
    ///   The serializer used to serialize outgoing packets.
    /// </param>
    /// <exception cref="System.ArgumentNullException">
    ///   connection or serializer
    /// </exception>
    public LitePacketContext(LiteConnection connection, ILitePacketSerializer serializer)
    {
        this.Connection = connection ?? throw new ArgumentNullException(nameof(connection));
        this.Serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
    }

    /// <inheritdoc/>
    public LiteConnection Connection { get; }

    /// <inheritdoc/>
    public ILitePacketSerializer Serializer { get; }

    /// <inheritdoc/>
    public void Send<TPacket>(TPacket packet)
        where TPacket : class
    {
        this.Connection.SendPacket<TPacket>(packet, this.Serializer);
    }
}
