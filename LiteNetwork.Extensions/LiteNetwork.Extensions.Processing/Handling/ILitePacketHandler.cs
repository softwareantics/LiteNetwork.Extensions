// <copyright file="ILitePacketHandler.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace LiteNetwork.Extensions.Processing.Handling;

using System.Threading.Tasks;
using LiteNetwork.Extensions.Processing.Contexts;

public interface ILitePacketHandler
{
    Task Handle(byte[] packetBytes, ILitePacketContext context);
}
