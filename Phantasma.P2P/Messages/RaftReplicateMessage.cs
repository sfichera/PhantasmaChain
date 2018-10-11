﻿using System.IO;
using Phantasma.Blockchain;
using Phantasma.Core;
using Phantasma.Cryptography;
    
namespace Phantasma.Network.P2P.Messages
{
    internal class RaftReplicateMessage : Message
    {
        public readonly Block block;

        public RaftReplicateMessage(Nexus nexus, Address address, Block block) : base(nexus, Opcode.RAFT_Replicate, address)
        {
            Throw.IfNull(block, nameof(block));
            this.block = block;
        }

        internal static RaftReplicateMessage FromReader(Nexus nexus, Address address, BinaryReader reader)
        {
            var block = Block.Unserialize(nexus, reader);
            return new RaftReplicateMessage(nexus, address, block);
        }
    }
}