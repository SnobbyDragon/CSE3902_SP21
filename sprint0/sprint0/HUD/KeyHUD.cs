using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class KeyHUD : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        public int keyNumTens;
        public int keyNumOnes;
        private List<Rectangle> sources;


        public KeyHUD(Texture2D texture, Vector2 location, int keyNum)
        {
            Location = location;
            Texture = texture;
            keyNumTens = keyNum / 10;
            keyNumOnes = keyNum % 10;
            int totalFrames = 10;
            int xPos = 528, yPos = 117, sideLength = 8;
            sources = new List<Rectangle>();
            for (int frame = 0; frame < totalFrames; frame++)
            {
                sources.Add(new Rectangle(xPos, yPos, sideLength, sideLength));
                xPos += sideLength;
            }
            sources.Add(new Rectangle(519, yPos, sideLength, sideLength));
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, sources[10], Color.White);
            spriteBatch.Draw(Texture, Location, sources[keyNumTens], Color.White);
            spriteBatch.Draw(Texture, Location, sources[keyNumOnes], Color.White);
        }

        public void Update()
        {
            //Does nothing
        }
    }
}
