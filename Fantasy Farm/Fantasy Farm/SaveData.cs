using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Microsoft.Xna.Framework;

namespace Fantasy_Farm
{
    [Serializable]
    class SaveData : ISerializable
    {
        public Point player_position = Point.Zero;
        public int gameDay = 0;
        public float time = 0;
        public PlayerTool playertool = PlayerTool.None;

        public Map map = null;

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("player_position", player_position);
            info.AddValue("gameDay", gameDay);
            info.AddValue("playertool", playertool);
        }

        public SaveData()
        {
        }

        public SaveData(SerializationInfo info, StreamingContext context)
        {
            player_position = (Point)info.GetValue("player_position", typeof(Point));
            gameDay = (int)info.GetValue("gameDay", typeof(int));
            playertool = (PlayerTool)info.GetValue("playertool", typeof(PlayerTool));
        }
    }
}
