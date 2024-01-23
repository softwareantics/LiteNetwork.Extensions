// <copyright file="LitePacketHandlerExecutor.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace LiteNetwork.Extensions.Processing;

using System;
using System.IO;
using System.Threading.Tasks;
using LiteNetwork.Extensions.Processing.Contexts;
using LiteNetwork.Extensions.Processing.Handling;
using LiteNetwork.Extensions.Processing.Serialization;

/// <summary>
///   Provides a standard implementation of an <see cref="ILitePacketHandlerExecutor"/>.
/// </summary>
/// <seealso cref="ILitePacketHandlerExecutor"/>
public sealed class LitePacketHandlerExecutor : ILitePacketHandlerExecutor
{
    /// <summary>
    ///   Responsible for fetching the appropriate packet handler for an incoming packet.
    /// </summary>
    private readonly ILitePacketHandlerFetcher fetcher;

    /// <summary>
    ///   Responsible for serializing incoming and outgoing packets.
    /// </summary>
    private readonly ILitePacketSerializer serializer;

    /// <summary>
    ///   Initializes a new instance of the <see cref="LitePacketHandlerExecutor"/> class.
    /// </summary>
    /// <param name="fetcher">
    ///   The fetcher, responsible for fetching the appropriate packet handler for an incoming packet.
    /// </param>
    /// <param name="serializer">
    ///   The serializer, responsible for serializing incoming and outgoing packets.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///   The specified <paramref name="fetcher"/> or <paramref name="serializer"/> parameter cannot be null.
    /// </exception>
    public LitePacketHandlerExecutor(ILitePacketHandlerFetcher fetcher, ILitePacketSerializer serializer)
    {
        this.fetcher = fetcher ?? throw new ArgumentNullException(nameof(fetcher));
        this.serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">
    ///   The specified <paramref name="payload"/> or <paramref name="connection"/> parameter cannot be null.
    /// </exception>
    public async Task Execute(byte[] payload, LiteConnection connection)
    {
        ArgumentNullException.ThrowIfNull(payload, nameof(payload));
        ArgumentNullException.ThrowIfNull(connection, nameof(connection));

        using (var stream = new MemoryStream(payload))
        {
            using (var reader = new BinaryReader(stream))
            {
                int nameLength = reader.ReadInt32();
                int dataLength = reader.ReadInt32();
                int totalLength = nameLength + dataLength + (sizeof(int) * 2);

                if (payload.Length != totalLength)
                {
                    throw new ArgumentException("Payload size is incorrect, this is a possible data allocation attack.", nameof(payload));
                }

                string packetName = new(reader.ReadChars(nameLength));
                byte[] packetBytes = reader.ReadBytes(dataLength);

                var handler = this.fetcher.FetchHandlerByPacketName(packetName);

                var context = new LitePacketContext(
                    connection: connection,
                    serializer: this.serializer);

                await handler.Handle(packetBytes, context).ConfigureAwait(false);
            }
        }
    }
}
