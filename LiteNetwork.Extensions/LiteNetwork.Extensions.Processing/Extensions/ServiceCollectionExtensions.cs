// <copyright file="ServiceCollectionExtensions.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace LiteNetwork.Extensions.Processing.Extensions;

using System;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterPacketHandler<TPacket, TPacketHandler>(this IServiceCollection services)
        where TPacket : class
        where TPacketHandler : LitePacketHandlerBase<TPacket>
    {
        ArgumentNullException.ThrowIfNull(services, nameof(services));

        services.AddSingleton<LitePacketHandlerBase<TPacket>, TPacketHandler>();

        return services;
    }
}
