// <copyright file="ILitePacketSerializer.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace LiteNetwork.Extensions.Processing.Serialization;

/// <summary>
///   Defines an interface that represents a packet serializer.
/// </summary>
public interface ILitePacketSerializer
{
    /// <summary>
    ///   Deserializes the specified <paramref name="packetBytes"/>.
    /// </summary>
    /// <typeparam name="T">
    ///   The type used for deserializing the specified <paramref name="packetBytes"/>.
    /// </typeparam>
    /// <param name="packetBytes">
    ///   The packet bytes to deserialize.
    /// </param>
    /// <returns>
    ///   The deserialized object of the specified type from the provided <paramref name="packetBytes"/>.
    /// </returns>
    T? Deserialize<T>(byte[] packetBytes);

    /// <summary>
    ///   Serializes the specified object of type <typeparamref name="T"/> into a byte array.
    /// </summary>
    /// <typeparam name="T">
    ///   The type of the object to be serialized.
    /// </typeparam>
    /// <param name="packet">
    ///   The object to be serialized.
    /// </param>
    /// <returns>
    ///   The serialized byte array representing the specified <paramref name="packet"/>.
    /// </returns>
    byte[] Serialize<T>(T packet);
}
