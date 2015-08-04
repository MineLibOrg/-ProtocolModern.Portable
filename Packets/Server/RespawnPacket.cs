using MineLib.Core;
using MineLib.Core.Interfaces;
using MineLib.Core.IO;
using MineLib.Core.Wrappers;

using ProtocolModern.Enum;

namespace ProtocolModern.Packets.Server
{
    public struct RespawnPacket : IPacket
    {
        public Dimension Dimension;
        public Difficulty Difficulty;
        public GameMode GameMode;
        public string LevelType;
    
        public byte ID { get { return 0x07; } }

        public IPacket ReadPacket(IProtocolDataReader reader)
        {
            Dimension = (Dimension) reader.ReadInt();
            Difficulty = (Difficulty) reader.ReadByte();
            GameMode = (GameMode) reader.ReadByte();
            LevelType = reader.ReadString();

            return this;
        }
    
        public IPacket WritePacket(IProtocolStream stream)
        {
            stream.WriteInt((int) Dimension);
            stream.WriteByte((byte) Difficulty);
            stream.WriteByte((byte) GameMode);
            stream.WriteString(LevelType);
            
            return this;
        }
    }
}