// <copyright file="ILitePacketHandlerFetcher.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace LiteNetwork.Extensions.Processing.Handling;
public interface ILitePacketHandlerFetcher
{
    ILitePacketHandler FetchHandlerByName(string name);
}