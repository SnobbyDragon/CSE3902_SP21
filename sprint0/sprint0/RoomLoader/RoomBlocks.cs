using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class RoomBlocks
    {
        public List<IBlock> Blocks { get => blocks; set => blocks = value; }
        private List<IBlock> blocks;
        public RoomBlocks()
        {
            blocks = new List<IBlock>();
        }

        public void Update()
        {
            foreach (IBlock block in blocks)
                block.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IBlock block in blocks)
                block.Draw(spriteBatch);
        }
    }
}
