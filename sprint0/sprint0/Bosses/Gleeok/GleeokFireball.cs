﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
namespace sprint0
{
    public class GleeokFireball : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int xOffset = 271, yOffset = 31, width = 8, height = 10;
        private List<Rectangle> sources;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames, speed = 3;
        public Vector2 Direction { get; set; }
        public bool IsDead { get; set; }

        public GleeokFireball(Texture2D texture)
        {
            Texture = texture;
            currFrame = 0;
            totalFrames = 4;
            repeatedFrames = 2;
            sources = new List<Rectangle>();
            for (int frame = 0; frame < totalFrames; frame++)
            {
                sources.Add(new Rectangle(xOffset + frame * (width + 1), yOffset, width, height));
            };

            IsDead = true; // starts hidden
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!IsDead)
                spriteBatch.Draw(Texture, Location, sources[currFrame / repeatedFrames], Color.White);
        }

        public void Update()
        {
            if (!IsDead)
            {
                currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
                Location += speed * Direction;

                // checks if hit wall (left || right || up || down)
                if (Location.X <= 0 || Location.X >= Game1.Width * Game1.Scale || Location.Y <= Game1.HUDHeight * Game1.Scale || Location.Y >= (Game1.HUDHeight + Game1.MapHeight) * Game1.Scale)
                {
                    IsDead = true;
                }
            }
        }
    }
}