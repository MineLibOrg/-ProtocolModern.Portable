﻿using MineLib.Core;
using MineLib.Core.Interfaces;
using MineLib.Core.IO;
using MineLib.Core.Wrappers;

namespace ProtocolModern.Packets.Server
{
    public struct PlayerListHeaderFooterPacket : IPacket
    {
        public string Header;
        public string Footer;

        public byte ID { get { return 0x47; } }

        public IPacket ReadPacket(IProtocolDataReader reader)
        {
            Header = reader.ReadString();
            Footer = reader.ReadString();

            return this;
        }

        public IPacket WritePacket(IProtocolStream stream)
        {
            stream.WriteString(Header);
            stream.WriteString(Footer);
            
            return this;
        }
    }
}
