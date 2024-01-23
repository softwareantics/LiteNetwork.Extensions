// <copyright file="LitePacketExecutor.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace LiteNetwork.Extensions.Processing;

using System;
using System.IO;
using System.Threading.Tasks;
using LiteNetwork.Extensions.Processing.Serialization;

public sealed class LitePacketExecutor : ILitePacketExecutor
{
    private readonly ILitePacketHandlerFetcher fetcher;

    private readonly ILitePacketSerializer serializer;

    public LitePacketExecutor(ILitePacketHandlerFetcher fetcher, ILitePacketSerializer serializer)
    {
        this.fetcher = fetcher ?? throw new ArgumentNullException(nameof(fetcher));
        this.serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
    }

    public async Task Execute(byte[] payload)
    {
        ArgumentNullException.ThrowIfNull(payload, nameof(payload));

        using (var stream = new MemoryStream(payload))
        {
            using (var reader = new BinaryReader(stream))
            {
                int nameLength = reader.ReadInt32();
                int dataLength = reader.ReadInt32();
                int totalLength = nameLength + dataLength + (sizeof(int) * 2);

                if (payload.Length != totalLength)
                {
                    throw new ArgumentException("Payload size is incorrect, this is possible data allocation attack.", nameof(payload));
                }

                string packetName = new(reader.ReadChars(nameLength));
                byte[] packetBytes = reader.ReadBytes(dataLength);

                var handler = this.fetcher.FetchHandlerByName(packetName)
                    ?? throw new InvalidOperationException($"Failed to locate packet handler for packet: '{packetName}'.");

                await handler.Handle(packetBytes, this.serializer).ConfigureAwait(false);
            }
        }
    }
}
