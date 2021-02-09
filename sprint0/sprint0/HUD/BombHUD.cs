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


        public BombHUD(Texture2D texture, Vector2 location, int bombNum)
        {
            Location = location;
            Texture = texture;
            bombNumTens = bombNum / 10;
            bombNumOnes = bombNum % 10;
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
            spriteBatch.Draw(Texture, Location, sources[bombNumTens], Color.White);
            spriteBatch.Draw(Texture, Location, sources[bombNumOnes], Color.White);
        }

        public void Update()
        {
            //Does nothing
        }
    }
}
