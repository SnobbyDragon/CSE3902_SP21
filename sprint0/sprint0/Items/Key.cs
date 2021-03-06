﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Stuti Shah
//Updated: 04/12/21 by shah.1440
namespace sprint0
{
    public class Key : AbstractItem, IItem
    {
        private readonly int xOffset = 240, yOffset = 0;
        public new PlayerItems PlayerItems { get => PlayerItems.Key; }

        public Key(Texture2D texture, Vector2 location)
        {
            width = 8;
            height = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            PickedUpDuration = -2;
            source = new Rectangle(xOffset, yOffset, width, height);
        }
        public override void Update() { }
    }
}
