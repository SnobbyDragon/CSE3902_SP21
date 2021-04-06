using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class RoomNPCs
    {
        public List<INpc> NPCs { get => npcs; set => npcs = value; }
        private List<INpc> npcs;
        public RoomNPCs()
        {
            npcs = new List<INpc>();
        }

        public void UpdateOffset(Vector2 Offset)
        {
            foreach (INpc item in npcs)
                item.Location = new Rectangle(item.Location.X + (int)Offset.X, item.Location.Y + (int)Offset.Y, item.Location.Width, item.Location.Height);
        }
        public void Update()
        {
            foreach (INpc npc in npcs)
                npc.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (INpc npc in npcs)
                npc.Draw(spriteBatch);
        }
    }
}
