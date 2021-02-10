using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Goriya : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private List<Rectangle> sources;
        private int currentFrame;
        private string color;
        private readonly int totalFrames, repeatedFrames;

        public Goriya(Texture2D texture, Vector2 location, String goriyaColor)
        {
            Location = location;
            Texture = texture;
            color = goriyaColor;
            currentFrame = 0;
            totalFrames = 4;
            repeatedFrames = 8;

            colorMap = new Dictionary<string, List<Rectangle>>
            {
                { "red", GetFrames(222, 11, 4)},
                { "blue", GetFrames(222, 28, 4)}
            };
        }

        private List<Rectangle> GetFrames(int xPos, int yPos, int numFrames) {
            List<Rectangle> sources = new List<Rectangle>();
            int size =16;
            for (int i = 0; i < numFrames; i++) {
                sources.Add(new Rectangle(xPos,yPos,size,size));
                xPos += size + 1;
            }
            return sources;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, colorMap[color][currentFrame / repeatedFrames], Color.White);
        }

        public void Update()
        {
            // animates all the time for now
            currFrame = (currFrame + 1) % (totalFrames*repeatedFrames);
        }
    }
}