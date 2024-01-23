// <copyright file="ILitePacketHandlerFetcher.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace LiteNetwork.Extensions.Processing.Handling;

/// <summary>
///   Defines an interface that provides a method to handle fetching an <see cref="ILitePacketHandler"/> based on it's packet name.
/// </summary>
public interface ILitePacketHandlerFetcher
{
    /// <summary>
    ///   Fetches an <see cref="ILitePacketHandler"/> that handles a packet with the name of <paramref name="packetName"/>.
    /// </summary>
    /// <param name="packetName">
    ///   The name of the packet that the <see cref="ILitePacketHandler"/> should handle.
    /// </param>
    /// <returns>
    ///   The <see cref="ILitePacketHandler"/> that handles a packet with the name of <paramref name="packetName"/>.
    /// </returns>
    ILitePacketHandler FetchHandlerByPacketName(string packetName);
}
