// <copyright file="LitePacketHandlerFetcher.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace LiteNetwork.Extensions.Processing.Handling;

using System;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
///   Provides a standard implementation of an <see cref="ILitePacketHandlerFetcher"/>.
/// </summary>
/// <seealso cref="ILitePacketHandlerFetcher"/>
public sealed class LitePacketHandlerFetcher : ILitePacketHandlerFetcher
{
    /// <summary>
    ///   The service provider, used to fetch the packet handler by key.
    /// </summary>
    private readonly IServiceProvider serviceProvider;

    /// <summary>
    ///   Initializes a new instance of the <see cref="LitePacketHandlerFetcher"/> class.
    /// </summary>
    /// <param name="serviceProvider">
    ///   The service provider, used to fetch the packet handler by key.
    /// </param>
    /// <exception cref="System.ArgumentNullException">
    ///   The specified <paramref name="serviceProvider"/> parameter cannot be null.
    /// </exception>
    public LitePacketHandlerFetcher(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentException">
    ///   Failed to locate a packet handler for packet <paramref name="packetName"/>.
    /// </exception>
    public ILitePacketHandler FetchHandlerByPacketName(string packetName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(packetName, nameof(packetName));

        var handler = this.serviceProvider.GetKeyedService<ILitePacketHandler>(packetName)
            ?? throw new ArgumentException($"Failed locate a packet handler for packet: '{packetName}'", nameof(packetName));

        return handler;
    }
}
