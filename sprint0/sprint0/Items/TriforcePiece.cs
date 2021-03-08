using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class TriforcePiece : ISprite
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private int currentFrame;
        private string color;
        private readonly int totalFrames, repeatedFrames;
        private Dictionary<string, List<Rectangle>> colorMap;
        private readonly int width, height;

        public TriforcePiece(Texture2D texture, Vector2 location, String triforceColor)
        {
            width = height = 14;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            color = triforceColor;
            currentFrame = 0;
            totalFrames = 1;
            repeatedFrames = 8;

            colorMap = new Dictionary<string, List<Rectangle>>
            {
                { "gold", GetFrames(273, 1, 1)},
                { "blue", GetFrames(273, 17, 1)}
            };
        }

        private List<Rectangle> GetFrames(int xPos, int yPos, int numFrames)
        {
            List<Rectangle> sources = new List<Rectangle>();
            for (int i = 0; i < numFrames; i++)
            {
                sources.Add(new Rectangle(xPos, yPos, width, height));
                xPos += width + 1;
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
            currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);
        }
    }
}