// <copyright file="ILitePacketHandler.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace LiteNetwork.Extensions.Processing;

using System.Threading.Tasks;
using LiteNetwork.Extensions.Processing.Serialization;

public interface ILitePacketHandler
{
    Task Handle(byte[] packetBytes, ILitePacketSerializer serializer);
}
