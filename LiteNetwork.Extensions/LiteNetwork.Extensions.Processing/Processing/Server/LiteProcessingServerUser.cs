// <copyright file="LiteProcessingServerUser.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace LiteNetwork.Extensions.Processing.Server;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using LiteNetwork.Server;

/// <summary>
///   Provides a basic user implementaion that can be used for a <see cref="LiteServer{TUser}"/> with automated packet handling.
/// </summary>
/// <seealso cref="LiteClient"/>
[ExcludeFromCodeCoverage(Justification = "Invocation")]
public class LiteProcessingServerUser : LiteServerUser
{
    /// <summary>
    ///   Responsible for executing packet handlers for incoming packets.
    /// </summary>
    private readonly ILitePacketHandlerExecutor executor;

    /// <summary>
    ///   Initializes a new instance of the <see cref="LiteProcessingServerUser"/> class.
    /// </summary>
    /// <param name="options">
    ///   The client options.
    /// </param>
    /// <param name="executor">
    ///   The packet executor, responsible for executing packet handlers for incoming packets.
    /// </param>
    /// <param name="serviceProvider">
    ///   The service provider.
    /// </param>
    /// <exception cref="System.ArgumentNullException">
    ///   The specified <paramref name="executor"/> parameter cannot be null.
    /// </exception>
    public LiteProcessingServerUser(ILitePacketHandlerExecutor executor)
    {
        this.executor = executor ?? throw new ArgumentNullException(nameof(executor));
    }

    /// <summary>
    ///   Handles an incoming packet message asynchronously and executes the appropriate packet handler.
    /// </summary>
    /// <param name="packetBuffer">
    ///   The complete packet buffer.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///   The specified <paramref name="packetBuffer"/> parameter cannot be null.
    /// </exception>
    /// <inheritdoc/>
    public override async Task HandleMessageAsync(byte[] packetBuffer)
    {
        ArgumentNullException.ThrowIfNull(packetBuffer, nameof(packetBuffer));
        await this.executor.Execute(packetBuffer, this).ConfigureAwait(false);
    }

    /// <summary>
    ///   Sends the specified packet using the serializer.
    /// </summary>
    /// <typeparam name="TPacket">
    ///   The type of the packet.
    /// </typeparam>
    /// <param name="packet">
    ///   The packet to send.
    /// </param>
    public void Send<TPacket>(TPacket packet)
    {
        this.Send(this.executor.Serializer.Serialize(packet));
    }
}
