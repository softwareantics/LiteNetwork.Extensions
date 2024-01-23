// <copyright file="ILitePacketHandlerExecutor.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace LiteNetwork.Extensions.Processing;

using System.Threading.Tasks;

/// <summary>
///   Defines an interface that provides a method for executing a packet handler based on the specified payload.
/// </summary>
public interface ILitePacketHandlerExecutor
{
    /// <summary>
    ///   Executes a packet handler by processing the provided byte array payload.
    /// </summary>
    /// <param name="payload">
    ///   The byte array representing the packet payload.
    /// </param>
    /// <param name="connection">
    ///   The <see cref="LiteConnection"/> associated with the packet.
    /// </param>
    /// <returns>
    ///   The <see cref="Task"/> that represents the asynchronous operation.
    /// </returns>
    Task Execute(byte[] payload, LiteConnection connection);
}
