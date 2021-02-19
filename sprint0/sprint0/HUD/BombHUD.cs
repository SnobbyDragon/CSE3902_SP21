using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class BombHUD : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        public int bombNumTens;
        public int bombNumOnes;
        private List<Rectangle> sources;
        private int sideLength = 8;

        public BombHUD(Texture2D texture, Vector2 location, int bombNum)
        {
            Location = location;
            Texture = texture;
            bombNumTens = bombNum / 10;
            bombNumOnes = bombNum % 10;
            int totalFrames = 10;
            int xPos = 528, yPos = 117;
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
            spriteBatch.Draw(Texture, new Rectangle((int)Location.X, (int)Location.Y, (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale)), sources[10], Color.White);
            spriteBatch.Draw(Texture, new Rectangle((int)(Location.X + sideLength * Game1.Scale), (int)Location.Y, (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale)), sources[bombNumTens], Color.White);
            spriteBatch.Draw(Texture, new Rectangle((int)(Location.X + 2 * sideLength * Game1.Scale), (int)Location.Y, (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale)), sources[bombNumOnes], Color.White);
        }

        public void Update()
        {
            //Does nothing
        }
    }
}
