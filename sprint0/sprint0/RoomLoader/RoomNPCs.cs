using System;
using System.Collections.Generic;
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
