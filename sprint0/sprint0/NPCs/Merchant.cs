﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Merchant : INpc
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        public Color Type { get; set; }
        private readonly int xOffset = 109, yOffset = 11, width, height;
        private readonly Dictionary<Color, Rectangle> typeRectMap;

        public Merchant(Texture2D texture, Vector2 location, Color type)
        {
            width = height = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            Type = type;
            List<Rectangle> sources = SpritesheetHelper.GetFramesH(xOffset, yOffset, width, height, 3);
            typeRectMap = new Dictionary<Color, Rectangle>
            {
                { Color.Green, sources[0] },
                { Color.White, sources[1] },
                { Color.Red, sources[2] }
            };
        }

        public void Draw(SpriteBatch spriteBatch)
            => spriteBatch.Draw(Texture, Location, typeRectMap[Type], Color.White);
        public void Update() { }
    }
}
