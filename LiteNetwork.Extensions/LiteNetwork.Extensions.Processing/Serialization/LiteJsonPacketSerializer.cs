// <copyright file="LiteJsonPacketSerializer.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace LiteNetwork.Extensions.Processing.Serialization;

using System;
using System.IO;
using System.Text;
using System.Text.Json;

public sealed class LiteJsonPacketSerializer : ILitePacketSerializer
{
    public T? Deserialize<T>(byte[] packetBytes)
    {
        ArgumentNullException.ThrowIfNull(packetBytes, nameof(packetBytes));
        return JsonSerializer.Deserialize<T>(packetBytes);
    }

    public byte[] Serialize<T>(T packet)
    {
        ArgumentNullException.ThrowIfNull(packet, nameof(packet));

        using (var stream = new MemoryStream())
        {
            using (var writer = new BinaryWriter(stream))
            {
                byte[] nameBytes = Encoding.ASCII.GetBytes(typeof(T).Name);
                byte[] packetBytes = JsonSerializer.SerializeToUtf8Bytes(packet);

                writer.Write(nameBytes.Length);
                writer.Write(packetBytes.Length);
                writer.Write(nameBytes);
                writer.Write(packetBytes);
            }

            return stream.ToArray();
        }
    }
}
