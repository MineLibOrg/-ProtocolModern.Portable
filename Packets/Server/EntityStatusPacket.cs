using MineLib.Core;
using MineLib.Core.Interfaces;
using MineLib.Core.IO;
using MineLib.Core.Wrappers;

using ProtocolModern.Enum;

namespace ProtocolModern.Packets.Server
{
    public struct EntityStatusPacket : IPacket
    {
        public int EntityID;
        public EntityStatus Status;

        public byte ID { get { return 0x1A; } }

        public IPacket ReadPacket(IProtocolDataReader reader)
        {
            EntityID = reader.ReadInt();
            Status = (EntityStatus) reader.ReadSByte();

            return this;
        }

        public IPacket WritePacket(IProtocolStream stream)
        {
            stream.WriteInt(EntityID);
            stream.WriteSByte((sbyte) Status);
            
            return this;
        }
    }
}