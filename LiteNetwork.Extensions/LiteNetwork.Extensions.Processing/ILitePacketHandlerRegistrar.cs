// <copyright file="ILitePacketHandlerRegistrar.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace LiteNetwork.Extensions.Processing;

using System;

public interface ILitePacketHandlerRegistrar
{
    void RegisterPacketHandler(Type packetType, ILitePacketHandler handler);
}
