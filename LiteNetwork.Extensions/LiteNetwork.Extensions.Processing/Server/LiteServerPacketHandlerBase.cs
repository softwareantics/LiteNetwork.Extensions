// <copyright file="LiteServerPacketHandlerBase.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace LiteNetwork.Extensions.Processing.Server;

using System;
using LiteNetwork.Server;

public abstract class LiteServerPacketHandlerBase<TUser, TPacket> : LitePacketHandlerBase<TPacket>
    where TUser : LiteServerUser
{
    protected LiteServerPacketHandlerBase(TUser serverUser)
    {
        this.ServerUser = serverUser ?? throw new ArgumentNullException(nameof(serverUser));
    }

    protected TUser ServerUser { get; }
}
