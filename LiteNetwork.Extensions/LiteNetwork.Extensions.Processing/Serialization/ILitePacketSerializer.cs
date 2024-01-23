// <copyright file="ILitePacketSerializer.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace LiteNetwork.Extensions.Processing.Serialization;

public interface ILitePacketSerializer
{
    T? Deserialize<T>(byte[] packetBytes);

    byte[] Serialize<T>(T packet);
}
