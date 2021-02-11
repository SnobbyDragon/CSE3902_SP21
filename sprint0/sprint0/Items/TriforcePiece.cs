using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class TriforcePiece : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private int currentFrame;
        private string color;
        private readonly int totalFrames, repeatedFrames;
        private Dictionary<string, List<Rectangle>> colorMap;

        public TriforcePiece(Texture2D texture, Vector2 location, String triforceColor)
        {
            Location = location;
            Texture = texture;
            color = triforceColor;
            currentFrame = 0;
            totalFrames = 4;
            repeatedFrames = 8;

            colorMap = new Dictionary<string, List<Rectangle>>
            {
                { "gold", GetFrames(273, 1, 1)},
                { "blue", GetFrames(273, 17, 1)}
            };
        }

        private List<Rectangle> GetFrames(int xPos, int yPos, int numFrames) {
            List<Rectangle> sources = new List<Rectangle>();
            int size =14;
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
            currentFrame = (currentFrame + 1) % (totalFrames*repeatedFrames);
        }
    }
}