using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class RupeeHUD : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        public int rupeeNumTens;
        public int rupeeNumOnes;
        private List<Rectangle> sources;


        public RupeeHUD(Texture2D texture, Vector2 location, int rupeeNum)
        {
            Location = location;
            Texture = texture;
            rupeeNumTens = rupeeNum / 10;
            rupeeNumOnes = rupeeNum % 10;
            int totalFrames = 10;
            int xPos = 528, yPos = 117, sideLength = 8;
            sources = new List<Rectangle>();
            for (int frame = 0; frame < totalFrames; frame++)
            {
                sources.Add(new Rectangle(xPos, yPos, sideLength, sideLength));
                xPos += sideLength + 1;
            }
            sources.Add(new Rectangle(519, yPos, sideLength, sideLength));
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, sources[10], Color.White);
            spriteBatch.Draw(Texture, new Vector2(Location.X + 8, Location.Y), sources[rupeeNumTens], Color.White);
            spriteBatch.Draw(Texture, new Vector2(Location.X + 16, Location.Y), sources[rupeeNumOnes], Color.White);
        }

        public void Update()
        {
            //Does nothing
        }
    }
}
