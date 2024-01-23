// <copyright file="LitePacketHandlerFetcher.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace LiteNetwork.Extensions.Processing.Handling;

using System;
using Microsoft.Extensions.DependencyInjection;

public sealed class LitePacketHandlerFetcher : ILitePacketHandlerFetcher
{
    private readonly IServiceProvider serviceProvider;

    public LitePacketHandlerFetcher(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
    }

    public ILitePacketHandler FetchHandlerByName(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));

        var handler = this.serviceProvider.GetKeyedService<ILitePacketHandler>(name)
            ?? throw new ArgumentException($"Failed locate a packet handler for packet: '{name}'", nameof(name));

        return handler;
    }
}
