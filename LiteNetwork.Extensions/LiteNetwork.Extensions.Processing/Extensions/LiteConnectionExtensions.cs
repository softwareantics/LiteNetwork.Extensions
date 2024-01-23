// <copyright file="LiteConnectionExtensions.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace LiteNetwork.Extensions.Processing.Extensions;

using System;
using System.Diagnostics.CodeAnalysis;
using LiteNetwork.Extensions.Processing.Serialization;

[ExcludeFromCodeCoverage(Justification = "Extensions")]
public static class LiteConnectionExtensions
{
    public static void SendPacket<TPacket>(this LiteConnection connection, TPacket packet, ILitePacketSerializer serializer)
        where TPacket : class
    {
        ArgumentNullException.ThrowIfNull(connection, nameof(connection));
        ArgumentNullException.ThrowIfNull(packet, nameof(packet));
        ArgumentNullException.ThrowIfNull(serializer, nameof(serializer));

        connection.Send(serializer.Serialize(packet));
    }
}
