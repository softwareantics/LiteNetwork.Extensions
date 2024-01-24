// <copyright file="ILitePacketHandler.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace LiteNetwork.Extensions.Processing.Handling;

using System.Threading.Tasks;
using LiteNetwork.Extensions.Processing.Contexts;

/// <summary>
///   Defines an interface that represents a packet handler used to handle an incoming packet.
/// </summary>
public interface ILitePacketHandler
{
    /// <summary>
    ///   Handles the incoming <paramref name="packetBytes"/> sent by the specified <paramref name="context"/>.
    /// </summary>
    /// <param name="packetBytes">
    ///   The packet bytes that were sent by the specified <paramref name="context"/>.
    /// </param>
    /// <param name="context">
    ///   The context that sent to the specified <paramref name="packetBytes"/>.
    /// </param>
    /// <returns>
    ///   The <see cref="Task"/> that represents the asynchronous operation.
    /// </returns>
    Task Handle(byte[] packetBytes, ILitePacketContext context);
}
