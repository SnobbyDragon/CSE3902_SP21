using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Rupee : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private List<Rectangle> sources;
        private readonly int xOffset = 72, yOffset = 0, sizex = 8, sizey = 16;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;


        public Rupee(Texture2D texture, Vector2 location)
        {
            Location = location;
            Texture = texture;
            sources = new List<Rectangle>
            {
                new Rectangle(xOffset, yOffset, sizex, sizey),
                new Rectangle(xOffset, yOffset+sizey+1, sizex, sizey)
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
            //Switches between colors
            currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
        }
    }
}
