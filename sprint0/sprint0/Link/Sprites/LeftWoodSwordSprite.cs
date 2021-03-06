﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/*
 * Last updated: 2/21/21 by urick.9
 */
namespace sprint0
{

    class LeftWoodSwordSprite : ISprite
    {
        public Texture2D Texture { get => texture; set => texture = value; }
        public Rectangle Location { get; set; }
        private readonly List<Rectangle> sources;
        private Texture2D texture;

        private int currFrame;
        private int slow;
        private readonly int xOffset = 1, yOffset = 77;
        private int width = 16;
        private readonly int height = 16;
        private readonly List<Vector2> locations;
        private readonly List<int> xSizes;

        public LeftWoodSwordSprite(Texture2D texture, Vector2 location, PlayerItems sword)
        {
            if (sword == PlayerItems.WhiteSword) xOffset += 93;
            else if (sword == PlayerItems.MagicalSword) xOffset += 187;
            this.texture = texture;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            sources = GetFrames();
            locations = new List<Vector2>
            {
                location,
                new Vector2(Location.X-(11 * Game1.Scale), Location.Y),
                new Vector2(Location.X-(10 * Game1.Scale), Location.Y),
                new Vector2(Location.X-(3 * Game1.Scale), Location.Y)
            };
            xSizes = new List<int>
            {
                16,
                16+11,
                16+10,
                16+3
            };
        }

        private List<Rectangle> GetFrames()
        {
            int xPos, yPos;
            List<Rectangle> sources = new List<Rectangle>();
            xPos = xOffset;
            yPos = yOffset;
            sources.Add(new Rectangle(xPos, yPos, width, height));
            xPos += width + 1;
            width = height + 11;
            sources.Add(new Rectangle(xPos, yPos, width, height));
            xPos += width + 1;
            width = height + 7;
            sources.Add(new Rectangle(xPos, yPos, width, height));
            xPos += width + 1;
            width = height + 3;
            sources.Add(new Rectangle(xPos, yPos, width, height));
            return sources;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (currFrame < 4)
            {
                Location = new Rectangle((int)locations[currFrame].X, (int)locations[currFrame].Y, (int)(xSizes[currFrame] * Game1.Scale), (int)(height * Game1.Scale));
                spriteBatch.Draw(Texture, Location, sources[currFrame], Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);
            }
        }

        public void Update()
        {
            slow++;
            if (slow % 8 == 0) currFrame += 1;
        }
    }
}