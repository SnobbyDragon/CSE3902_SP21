using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Stuti Shah
namespace sprint0
{
    public class Key : IItem
    {
        public bool PickedUp { get; set; }
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private List<Rectangle> sources;
        private readonly int xOffset = 240, yOffset = 0, width = 8, height = 16;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;


        public Key(Texture2D texture, Vector2 location)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;

            //add sprites
            sources = new List<Rectangle>
            {
                new Rectangle(xOffset, yOffset, width, height),
                new Rectangle(xOffset+width+1, yOffset, width, height)
            };

            currFrame = 0;
            totalFrames = 2;
            repeatedFrames = 8;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, sources[currFrame / repeatedFrames], Color.White);
        }

        public void Update()
        {
            //switches between two versions of the key (not sure if that's correct)
            currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
        }
    }
}
