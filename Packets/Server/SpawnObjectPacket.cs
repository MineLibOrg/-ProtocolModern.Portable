using MineLib.Core;
using MineLib.Core.Data;
using MineLib.Core.Interfaces;
using MineLib.Core.IO;
using MineLib.Core.Wrappers;

using ProtocolModern.Enum;

namespace ProtocolModern.Packets.Server
{
    // TODO: Object data problems?
    public struct SpawnObjectPacket : IPacket
    {
        public int EntityID;
        public Objects Type;
        public Vector3 Vector3;
        public byte Yaw, Pitch;
        public short SpeedX;
        public short SpeedY;
        public short SpeedZ;

        public byte ID { get { return 0x0E; } }

        public IPacket ReadPacket(IProtocolDataReader reader)
        {
            EntityID = reader.ReadVarInt();
            Type = (Objects) reader.ReadByte();
            Vector3 = Vector3.FromReaderIntFixedPoint(reader);
            Yaw = reader.ReadByte();
            Pitch = reader.ReadByte();
            var data = reader.ReadInt();
            if (data > 0)
            {
                SpeedX = reader.ReadShort();
                SpeedY = reader.ReadShort();
                SpeedZ = reader.ReadShort();
            }

            return this;
        }


        public IPacket WritePacket(IProtocolStream stream) // TODO: Complete
        {
            stream.WriteVarInt(EntityID);
            stream.WriteByte((byte) Type);
            Vector3.ToStreamIntFixedPoint(stream);
            stream.WriteByte(Yaw);
            stream.WriteByte(Pitch);
            stream.WriteShort(SpeedX);
            stream.WriteShort(SpeedY);
            stream.WriteShort(SpeedZ);
            
            return this;
        }
    }
}