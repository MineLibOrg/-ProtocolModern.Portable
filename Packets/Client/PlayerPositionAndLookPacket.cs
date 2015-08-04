using MineLib.Core.Interfaces;
using MineLib.Core.IO;

namespace ProtocolModern.Packets.Client
{
    public struct PlayerPositionAndLookPacket : IPacket
    {
        public double X { get; set; }
        public double FeetY { get; set; }
        public double Z { get; set; }
        public float Yaw { get; set; }
        public float Pitch { get; set; }
        public bool OnGround { get; set; }

        public byte ID { get { return 0x06; } }

        public IPacket ReadPacket(IProtocolDataReader reader)
        {
            X = reader.ReadDouble();
            FeetY = reader.ReadDouble();
            Z = reader.ReadDouble();
            Yaw = reader.ReadFloat();
            Pitch = reader.ReadFloat();
            OnGround = reader.ReadBoolean();

            return this;
        }

        public IPacket WritePacket(IProtocolStream stream)
        {
            stream.WriteDouble(X);
            stream.WriteDouble(FeetY);
            stream.WriteDouble(Z);
            stream.WriteFloat(Yaw);
            stream.WriteFloat(Pitch);
            stream.WriteBoolean(OnGround);
            
            return this;
        }
    }
}