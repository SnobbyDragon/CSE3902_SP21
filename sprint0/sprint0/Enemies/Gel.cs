using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson
namespace sprint0
{
    public class Gel : Enemy, IEnemy
    {
        public Gel(Texture2D texture, Vector2 location, Game1 gm, string gelColor) : base(texture, location, gm)
        {
            width = 8;
            height = 16;
            repeatedFrames = 10;
            health = 1;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            totalFrames = 2;
            currentFrame = 0;
            color = gelColor;

            colorMap = new Dictionary<string, List<Rectangle>>
            {
                { "teal", SpritesheetHelper.GetFramesH(1, 11, width, height, totalFrames) },
                { "blue", SpritesheetHelper.GetFramesH(19, 11, width, height, totalFrames) },
                { "green", SpritesheetHelper.GetFramesH(37, 11, width, height, totalFrames) },
                { "blkgold", SpritesheetHelper.GetFramesH(55, 11, width, height, totalFrames) },
                { "lime", SpritesheetHelper.GetFramesH(1, 28, width, height, totalFrames) },
                { "brown", SpritesheetHelper.GetFramesH(19, 28, width, height, totalFrames) },
                { "grey", SpritesheetHelper.GetFramesH(37, 28, width, height, totalFrames) },
                { "blkwhite", SpritesheetHelper.GetFramesH(55, 28, width, height, totalFrames) },
            };
        }
        
        public new void Draw(SpriteBatch spriteBatch)
        {
            if (damageTimer % 2 == 0)
                spriteBatch.Draw(Texture, Location, colorMap[color][currentFrame / repeatedFrames], Color.White);
        }
    }
}
