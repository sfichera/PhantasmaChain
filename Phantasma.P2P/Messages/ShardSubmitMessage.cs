﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using Phantasma.Blockchain;
using Phantasma.Cryptography;

namespace Phantasma.Network.P2P.Messages
{
    internal class ShardSubmitMessage : Message
    {
        public readonly uint ShardID;
        public IEnumerable<Transaction> Transactions => _transactions;

        private Transaction[] _transactions;

        public ShardSubmitMessage(Nexus nexus, Address address, uint shardID, IEnumerable<Transaction> transactions) : base(nexus, Opcode.SHARD_Submit, address)
        {
            this.ShardID = shardID;
            this._transactions = transactions.ToArray();
        }

        internal static Message FromReader(Nexus nexus, Address address, BinaryReader reader)
        {
            var shardID = reader.ReadUInt32();
            var txCount = reader.ReadUInt16();
            var txs = new Transaction[txCount];
            for (int i=0; i<txCount; i++)
            {
                var tx = Transaction.Unserialize(reader);
            }

            return new ShardSubmitMessage(nexus, address, shardID, txs);
        }
    }
}