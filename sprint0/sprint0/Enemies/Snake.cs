using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson

namespace sprint0
{
    public class Snake : AbstractEnemy
    {

        private readonly List<Rectangle> sources;
        private SpriteEffects spriteEffect;

        public Snake(Texture2D texture, Vector2 location, Game1 game) : base(texture, location, game)
        {
            dirChangeDelay = 25;
            health = 16;
            width = height = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            spriteEffect = SpriteEffects.None;
            totalFrames = 2;
            currentFrame = 0;
            repeatedFrames = 10;
            int xPos = 126, yPos = 59;
            sources = SpritesheetHelper.GetFramesH(xPos, yPos, width, height, totalFrames);
            damage = 1;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (damageTimer % 2 == 0)
                spriteBatch.Draw(Texture, Location, sources[currentFrame / repeatedFrames],
                    Color.White, 0, new Vector2(0, 0), spriteEffect, 0);
        }

        public override void Update()
        {
            moveCounter++;
            if (moveCounter == dirChangeDelay)
            {
                ArbitraryDirection(200, 3300);
            }

            CheckHealth();
            currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);
            if (direction == Direction.w)
            {
                spriteEffect = SpriteEffects.FlipHorizontally;
                Location = new Rectangle(Location.X - 1, Location.Y, Location.Width, Location.Height);
            }
            else if (direction == Direction.e)
            {
                spriteEffect = SpriteEffects.None;
                Location = new Rectangle(Location.X + 1, Location.Y, Location.Width, Location.Height);
            }
            else if (direction == Direction.s)
            {
                Location = new Rectangle(Location.X, Location.Y + 1, Location.Width, Location.Height);
            }
            else
            {
                Location = new Rectangle(Location.X, Location.Y - 1, Location.Width, Location.Height);
                if (Location.Y <= (Game1.HUDHeight + 50) * Game1.Scale)
                {
                    direction = Direction.w;
                }
            }
        }
    }
}
