using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Goriya : Enemy, IEnemy
    {


        public Goriya(Texture2D texture, Vector2 location, string goriyaColor, Game1 game) : base(texture, location, game)
        {


            health = 50;
            width = height = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            color = goriyaColor;
            currentFrame = 0;
            totalFrames = 4;
            repeatedFrames = 20;
            direction = Direction.n;

            colorMap = new Dictionary<string, List<Rectangle>>
            {
                { "red", GetFrames(222, 11, 4)},
                { "blue", GetFrames(222, 28, 4)}
            };
        }

 
      
    }
}