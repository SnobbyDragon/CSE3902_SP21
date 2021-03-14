using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson

namespace sprint0
{
    public class Gel : Enemy, IEnemy
    {
        private readonly Dictionary<string, List<Rectangle>> colorMap;

        private int directionChangeCounter;

        public Gel(Texture2D texture, Vector2 location, Game1 gm, string gelColor) : base(texture, location, gm)
        {
            width = 8;
            height = 16;
            repeatedFrames = 10;
            health = 10;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            totalFrames = 2;
            currentFrame = 0;
            color = gelColor;
            directionChangeCounter = 0;

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
            spriteBatch.Draw(Texture, Location, colorMap[color][currentFrame / repeatedFrames], Color.White);
        }

        public new void Update()
        {
            moveCounter++;
            if (moveCounter == dirChangeDelay)
            {
                ArbitraryDirection(30, 50);
            }
            CheckHealth();
            currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);

            if (directionChangeCounter== 100) { ChangeDirection(); directionChangeCounter = 0; }

            if (direction == Direction.w)
            {
                //moves sprite left
                Location = new Rectangle(Location.X - 1, Location.Y, Location.Width, Location.Height);
            }
            else if (direction == Direction.e)
            {
                //moves sprite right
                Location = new Rectangle(Location.X + 1, Location.Y, Location.Width, Location.Height);
            }
            else if (direction == Direction.s)
            {
                //moves sprite down
                Location = new Rectangle(Location.X, Location.Y + 1, Location.Width, Location.Height);
            }
            else
            {   //direction == Direction.n
                //moves sprite up
                Location = new Rectangle(Location.X, Location.Y - 1, Location.Width, Location.Height);
            }
            directionChangeCounter++;
        }
    }
}
