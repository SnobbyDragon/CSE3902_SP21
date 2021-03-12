using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson

namespace sprint0
{
    public class Snake : IEnemy
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private List<Rectangle> sources;
        private int totalFrames;
        private int currentFrame;
        private int repeatedFrames;
        private SpriteEffects spriteEffect;
        private readonly int width, height;
        private Direction direction = Direction.w;

        public Snake(Texture2D texture, Vector2 location)
        {
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

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(Texture, Location, sources[currentFrame / repeatedFrames],
                    Color.White, 0, new Vector2(0, 0), spriteEffect, 0);
        }

        public void Update()
        {
            currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);
            if (direction == Direction.w)
            {
                //sets sprite effect so snake faces left
                spriteEffect = SpriteEffects.FlipHorizontally;
                //moves sprite left
                Location = new Rectangle(Location.X - 1, Location.Y, Location.Width, Location.Height);
                if (Location.X <= 50 * Game1.Scale)
                {
                    direction = Direction.s;
                }
            }
            else if (direction == Direction.e)
            {
                //sets sprite effect so snake faces right
                spriteEffect = SpriteEffects.None;
                //moves sprite right
                Location = new Rectangle(Location.X + 1, Location.Y, Location.Width, Location.Height);
                if (Location.X >= (Game1.Width - 50) * Game1.Scale)
                {
                    direction = Direction.n;
                }
            }
            else if (direction == Direction.s)
            {
                //moves sprite down
                Location = new Rectangle(Location.X, Location.Y + 1, Location.Width, Location.Height);
                if (Location.Y >= (Game1.HUDHeight + Game1.MapHeight - 50) * Game1.Scale)
                {
                    direction = Direction.e;
                }
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

        public void ChangeDirection()
        {
            Random random = new Random();
            direction = (Direction)random.Next(0, 4);
        }

        public void TakeDamage()
        {
            // TODO
        }
    }
}
