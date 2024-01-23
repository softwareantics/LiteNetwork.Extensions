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

/// <summary>
///   Provides extension methosd for an <see cref="ILiteBuilder"/>.
/// </summary>
[ExcludeFromCodeCoverage(Justification = "Extensions")]
public static class LiteBuilderExtensions
{
    /// <summary>
    ///   Registers a packet handler with the specified packet type and packet handler type.
    /// </summary>
    /// <typeparam name="TPacket">
    ///   The type of the packet.
    /// </typeparam>
    /// <typeparam name="TPacketHandler">
    ///   The type of the packet handler.
    /// </typeparam>
    /// <param name="builder">
    ///   The builder instance to register the packet handler with.
    /// </param>
    /// <param name="lifeTime">
    ///   The service lifetime of the registered packet handler (default is <see cref="ServiceLifetime.Singleton"/>).
    /// </param>
    /// <returns>
    ///   The updated <see cref="ILiteBuilder"/> instance after registering the packet handler.
    /// </returns>
    /// <exception cref="System.ArgumentNullException">
    ///   The specified <paramref name="builder"/> parameter cannot be null.
    /// </exception>
    public static ILiteBuilder RegisterPacketHandler<TPacket, TPacketHandler>(this ILiteBuilder builder, ServiceLifetime lifeTime = ServiceLifetime.Singleton)
        where TPacket : class
        where TPacketHandler : LitePacketHandlerBase<TPacket>
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.Services.Add(new ServiceDescriptor(typeof(ILitePacketHandler), typeof(TPacket).Name, typeof(TPacketHandler), lifeTime));
        return builder;
    }

    /// <summary>
    ///   Configures the builder to use JSON packet serialization when handling incoming packets.
    /// </summary>
    /// <param name="builder">
    ///   The builder instance to configure.
    /// </param>
    /// <returns>
    ///   The updated <see cref="ILiteBuilder"/> instance with JSON packet serialization configured.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///   The specified <paramref name="builder"/> parameter cannot be null.
    /// </exception>
    public static ILiteBuilder UseJsonPacketSerialization(this ILiteBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        builder.Services.AddSingleton<ILitePacketSerializer, LiteJsonPacketSerializer>();
        return builder;
    }

    /// <summary>
    ///   Configures the builder to use packet handling to ensure that incoming payload can be handled in a uniform way.
    /// </summary>
    /// <param name="builder">
    ///   The builder instance to configure.
    /// </param>
    /// <returns>
    ///   The updated <see cref="ILiteBuilder"/> instance with packet handling services configured.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///   The specified <paramref name="builder"/> parameter cannot be null.
    /// </exception>
    /// <remarks>
    ///   When using packet handling you need to ensure you also specify what kind of packet serialization you wish to use such as <see cref="UseJsonPacketSerialization(ILiteBuilder)"/>.
    /// </remarks>
    public static ILiteBuilder UsePacketHandling(this ILiteBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        builder.Services.AddSingleton<ILitePacketHandlerExecutor, LitePacketHandlerExecutor>();
        builder.Services.AddSingleton<ILitePacketHandlerFetcher, LitePacketHandlerFetcher>();

        return builder;
    }
}
