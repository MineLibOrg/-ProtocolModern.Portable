using MineLib.Core;
using MineLib.Core.IO;

namespace ProtocolModern.Packets.Server.Login
{
    public struct LoginDisconnectPacket : IPacket
    {
        public string Reason;

        public byte ID { get { return 0x00; } }

        public IPacket ReadPacket(IProtocolDataReader reader)
        {
            Reason = reader.ReadString();

            return this;
        }

        public IPacket WritePacket(IProtocolStream stream)
        {
            stream.WriteVarInt(ID);
            stream.WriteString(Reason);
            
            return this;
        }
    }
}