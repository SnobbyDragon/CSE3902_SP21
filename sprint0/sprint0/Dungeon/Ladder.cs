﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson
namespace sprint0
{
    public class Ladder : AbstractBlock, IBlock
    {
        public Ladder(Texture2D texture, Vector2 location)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            source = new Rectangle(1001, 45, width, height);
        }
        public override bool IsWalkable() => true;
    }
}
