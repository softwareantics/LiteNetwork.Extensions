// <copyright file="ILitePacketContext.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace LiteNetwork.Extensions.Processing.Contexts;

using LiteNetwork.Extensions.Processing.Serialization;

/// <summary>
///   Defines an interface that represents the context that sent a packet.
/// </summary>
public interface ILitePacketContext
{
    /// <summary>
    ///   Gets the connection that sent the packet.
    /// </summary>
    /// <value>
    ///   The connection that sent the packet.
    /// </value>
    LiteConnection Connection { get; }

    /// <summary>
    ///   Gets the serializer.
    /// </summary>
    /// <value>
    ///   The serializer.
    /// </value>
    ILitePacketSerializer Serializer { get; }

    /// <summary>
    ///   Sends the specified <paramref name="packet"/> to the context connection.
    /// </summary>
    /// <typeparam name="TPacket">
    ///   The type of the packet.
    /// </typeparam>
    /// <param name="packet">
    ///   The packet to send to the context connection.
    /// </param>
    void Send<TPacket>(TPacket packet)
        where TPacket : class;
}
