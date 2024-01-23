// <copyright file="LitePacketHandlerRegistrar.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace LiteNetwork.Extensions.Processing;

using System;
using System.Collections.Generic;

public sealed class LitePacketHandlerRegistrar : ILitePacketHandlerRegistrar, ILitePacketHandlerFetcher
{
    private readonly IDictionary<string, ILitePacketHandler> nameToPacketHandlerMap;

    public LitePacketHandlerRegistrar()
    {
        this.nameToPacketHandlerMap = new Dictionary<string, ILitePacketHandler>();
    }

    public ILitePacketHandler FetchHandlerByName(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));

        return null!;
    }

    public void RegisterPacketHandler(Type packetType, ILitePacketHandler handler)
    {
        ArgumentNullException.ThrowIfNull(packetType, nameof(packetType));
        ArgumentNullException.ThrowIfNull(handler, nameof(handler));

        this.nameToPacketHandlerMap.Add(packetType.Name, handler);
    }
}
