﻿using MineLib.Core.Interfaces;
using MineLib.Core.IO;

namespace ProtocolModern.Packets.Server.Login
{
    public struct SetCompressionPacket : ISetCompressionPacket
    {
        public int Threshold { get; set; }

        public byte ID { get { return 0x03; } }

        public IPacket ReadPacket(IProtocolDataReader reader)
        {
            Threshold = reader.ReadVarInt();

            return this;
        }

        public IPacket WritePacket(IProtocolStream stream)
        {
            stream.WriteVarInt(Threshold);
            
            return this;
        }
    }
}
