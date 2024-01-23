// <copyright file="ILitePacketExecutor.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace LiteNetwork.Extensions.Processing;

using System.Threading.Tasks;

public interface ILitePacketExecutor
{
    Task Execute(byte[] payload, LiteConnection connection);
}
