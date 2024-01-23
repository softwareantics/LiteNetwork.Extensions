// <copyright file="ILitePacketContext.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace LiteNetwork.Extensions.Processing.Contexts;

using LiteNetwork.Extensions.Processing.Serialization;

public interface ILitePacketContext
{
    LiteConnection Connection { get; }

    ILitePacketSerializer Serializer { get; }

    void Send<TPacket>(TPacket packet)
        where TPacket : class;
}
