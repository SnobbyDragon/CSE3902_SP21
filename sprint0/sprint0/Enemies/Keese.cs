using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Keese : Enemy, IEnemy
    { 
        public Keese(Texture2D texture, Vector2 location, string keeseColor, Game1 game): base(texture, location, game)
        {
            dirChangeDelay = 5;
            width = height = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            color = keeseColor;
            currentFrame = 0;
            totalFrames = 2;
            repeatedFrames = 8;
            direction = Direction.n;

            colorMap = new Dictionary<string, List<Rectangle>>
            {
                { "blue", SpritesheetHelper.GetFramesH(183, 11, width, height, totalFrames) },
                { "red", SpritesheetHelper.GetFramesH(183, 28, width, height, totalFrames) }
            };
        }

        public new void Draw(SpriteBatch spriteBatch)
        {
            if (damageTimer % 2 == 0)
                spriteBatch.Draw(Texture, Location, colorMap[color][currentFrame / repeatedFrames], Color.White);
        }
    }
}