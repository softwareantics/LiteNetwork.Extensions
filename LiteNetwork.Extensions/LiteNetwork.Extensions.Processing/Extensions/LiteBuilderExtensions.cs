// <copyright file="LiteBuilderExtensions.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace LiteNetwork.Extensions.Processing.Extensions;

using System;
using System.Diagnostics.CodeAnalysis;
using LiteNetwork.Extensions.Processing.Handling;
using LiteNetwork.Extensions.Processing.Serialization;
using LiteNetwork.Hosting;
using Microsoft.Extensions.DependencyInjection;

[ExcludeFromCodeCoverage(Justification = "Extensions")]
public static class LiteBuilderExtensions
{
    public static ILiteBuilder RegisterPacketHandler<TPacket, TPacketHandler>(this ILiteBuilder builder, ServiceLifetime lifeTime = ServiceLifetime.Singleton)
        where TPacket : class
        where TPacketHandler : LitePacketHandlerBase<TPacket>
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.Services.Add(new ServiceDescriptor(typeof(ILitePacketHandler), typeof(TPacket).Name, typeof(TPacketHandler), lifeTime));
        return builder;
    }

    public static ILiteBuilder UseJsonPacketSerialization(this ILiteBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.Services.AddSingleton<ILitePacketSerializer, LiteJsonPacketSerializer>();
        return builder;
    }

    public static ILiteBuilder UsePacketHandling(this ILiteBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        builder.Services.AddSingleton<ILitePacketHandlerExecutor, LitePacketHandlerExecutor>();
        builder.Services.AddSingleton<ILitePacketHandlerFetcher, LitePacketHandlerFetcher>();

        return builder;
    }
}
