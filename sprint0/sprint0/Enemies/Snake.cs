using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson

namespace sprint0
{
    public class Snake : Enemy, IEnemy
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly List<Rectangle> sources;
        private SpriteEffects spriteEffect;

        public Snake(Texture2D texture, Vector2 location, Game1 game) : base(texture, location, game)
        {
            dirChangeDelay = 25;
            health = 25;
            width = height = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            spriteEffect = SpriteEffects.None;
            totalFrames = 2;
            currentFrame = 0;
            repeatedFrames = 10;
            sources = new List<Rectangle>();
            int xPos = 126, yPos = 59;
            //add frames to list
            for (int frame = 0; frame < totalFrames; frame++)
            {
                sources.Add(new Rectangle(xPos, yPos, width, height));
                xPos += width + 1;
            }
        }

        public new void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(Texture, Location, sources[currentFrame / repeatedFrames],
                    Color.White, 0, new Vector2(0, 0), spriteEffect, 0);
        }

        public new void Update()

        {
            moveCounter++;
            if (moveCounter == dirChangeDelay)
            {
                ArbitraryDirection(2000,200000);
            }

            CheckHealth();
            currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);
            if (direction == Direction.w)
            {
                //sets sprite effect so snake faces left
                spriteEffect = SpriteEffects.FlipHorizontally;
                //moves sprite left
                Location = new Rectangle(Location.X - 1, Location.Y, Location.Width, Location.Height);
            }
            else if (direction == Direction.e)
            {
                //sets sprite effect so snake faces right
                spriteEffect = SpriteEffects.None;
                //moves sprite right
                Location = new Rectangle(Location.X + 1, Location.Y, Location.Width, Location.Height);
            }
            else if (direction == Direction.s)
            {
                //moves sprite down
                Location = new Rectangle(Location.X, Location.Y + 1, Location.Width, Location.Height);
            }
            else
            { //direction == Direction.n
                //moves sprite up
                Location = new Rectangle(Location.X, Location.Y - 1, Location.Width, Location.Height);
                if (Location.Y <= (Game1.HUDHeight + 50) * Game1.Scale)
                {
                    direction = Direction.w;
                }
            }
        }

    }
}
