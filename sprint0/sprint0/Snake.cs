using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Snake:ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private List<Rectangle> sources;
        private int totalFrames;
        private int currentFrame;
        private int repeatedFrames = 10;

        public Snake(Texture2D texture, Vector2 location)
        {
            Location = location;
            Texture = texture;
            totalFrames = 2;
            currentFrame = 0;
            sources = new List<Rectangle>();
            int xPos = 126, yPos = 59, sideLength = 16;
            for (int frame = 0; frame < totalFrames; frame++)
            {
                sources.Add(new Rectangle(xPos, yPos, sideLength, sideLength));
                xPos += sideLength + 1;
            }
        }

        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, sources[currentFrame / repeatedFrames], Color.White);
        }

        public void Update()
        {
            currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);
        }
    }
}
