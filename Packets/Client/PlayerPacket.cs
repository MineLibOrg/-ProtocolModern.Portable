using MineLib.Core;
using MineLib.Core.IO;

namespace ProtocolModern.Packets.Client
{
    public struct PlayerPacket : IPacket
    {
        public bool OnGround;

        public byte ID { get { return 0x03; } }

        public IPacket ReadPacket(IProtocolDataReader reader)
        {
            OnGround = reader.ReadBoolean();

            return this;
        }

        public IPacket WritePacket(IProtocolStream stream)
        {
            stream.WriteVarInt(ID);
            stream.WriteBoolean(OnGround);
            
            return this;
        }
    }
}