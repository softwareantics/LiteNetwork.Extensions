// <copyright file="LitePacketContext.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace LiteNetwork.Extensions.Processing.Contexts;

using System;
using LiteNetwork;
using LiteNetwork.Extensions.Processing.Extensions;
using LiteNetwork.Extensions.Processing.Serialization;

internal sealed class LitePacketContext : ILitePacketContext
{
    public LitePacketContext(LiteConnection connection, ILitePacketSerializer serializer)
    {
        this.Connection = connection ?? throw new ArgumentNullException(nameof(connection));
        this.Serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
    }

    public LiteConnection Connection { get; }

    public ILitePacketSerializer Serializer { get; }

    public void Send<TPacket>(TPacket packet)
        where TPacket : class
    {
        this.Connection.SendPacket<TPacket>(packet, this.Serializer);
    }
}
