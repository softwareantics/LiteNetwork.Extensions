// <copyright file="LiteJsonPacketSerializer.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace LiteNetwork.Extensions.Processing.Serialization;

using System.Text.Json;

public sealed class LiteJsonPacketSerializer : ILitePacketSerializer
{
    public T? Deserialize<T>(byte[] packetBytes)
    {
        return JsonSerializer.Deserialize<T>(packetBytes);
    }
}
