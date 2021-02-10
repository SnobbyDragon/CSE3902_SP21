using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Keese : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private List<Rectangle> sources;
        private int currentFrame;
        private string color;
        private readonly int totalFrames, repeatedFrames;

        public Keese(Texture2D texture, Vector2 location, String keeseColor)
        {
            Location = location;
            Texture = texture;
            color = keeseColor;
            currentFrame = 0;
            totalFrames = 2;
            repeatedFrames = 8;

            colorMap = new Dictionary<string, List<Rectangle>>
            {
                { "blue", GetFrames(183, 11, 2)},
                { "red", GetFrames(183, 28, 2)}
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