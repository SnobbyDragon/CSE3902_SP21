
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class GoriyaBoomerang : ISprite
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int xOffset = 290, yOffset = 11, width = 7, height = 15;
        private List<Rectangle> sources;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;
        private readonly SpriteEffects h = SpriteEffects.FlipHorizontally, v = SpriteEffects.FlipVertically;
        private Direction direction;

        public GoriyaBoomerang(Texture2D texture, Vector2 location, int dir)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, width, height);
            Texture = texture;
            direction = (Direction)dir;
            sources = new List<Rectangle>
            {
                new Rectangle(xOffset, yOffset, width, height),
                new Rectangle(xOffset + width + 2, yOffset, width, height),
                new Rectangle(xOffset + width*2 + 4, yOffset, width+1, height)
            };
            currFrame = 0;
            totalFrames = 8;
            repeatedFrames = 4;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int tempFrame = currFrame / repeatedFrames;
            if (tempFrame == 3)
            {
                spriteBatch.Draw(Texture, Location, sources[1], Color.White, 0, new Vector2(0, 0), h, 0);
            }
            else if (tempFrame == 4){
                spriteBatch.Draw(Texture, Location, sources[0], Color.White, 0, new Vector2(0, 0), h, 0);
            }
            else if (tempFrame == 5)
            {
                spriteBatch.Draw(Texture, Location, sources[1], Color.White, 0, new Vector2(0, 0), v | h, 0);
            }
            else if (tempFrame == 6)
            {
                spriteBatch.Draw(Texture, Location, sources[2], Color.White, 0, new Vector2(0, 0), v, 0);
            }
            else if (tempFrame == 7)
            {
                spriteBatch.Draw(Texture, Location, sources[1], Color.White, 0, new Vector2(0, 0), v, 0);
            }
            else
            {
                spriteBatch.Draw(Texture, Location, sources[currFrame / repeatedFrames], Color.White);
            }
            
        }

        public void Update()
        {
            currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
            if (direction == Direction.w)
            {
                //moves sprite left
                Location = new Rectangle(Location.X - 1, Location.Y, Location.Width, Location.Height);

                if (Location.X <= 50 * Game1.Scale)
                {
                    direction = Direction.e;

                }
            }
            else if (direction == Direction.e)
            {

                //moves sprite right
                Location = new Rectangle(Location.X + 1, Location.Y, Location.Width, Location.Height);

                if (Location.X >= (Game1.Width - 50) * Game1.Scale)
                {
                    direction = Direction.w;
                }
            }
            else if (direction == Direction.ne)
            {
                Location = new Rectangle(Location.X + 1, Location.Y - 1, Location.Width, Location.Height);
                if (Location.Y <= (Game1.HUDHeight + 50) * Game1.Scale)
                {
                    direction = Direction.se;
                }
                if (Location.X >= (Game1.HUDHeight + Game1.MapHeight - 50) * Game1.Scale)
                {
                    direction = Direction.nw;
                }

            }
            else if (direction == Direction.sw)
            {
                Location = new Rectangle(Location.X - 1, Location.Y + 1, Location.Width, Location.Height);
                if (Location.Y >= (Game1.HUDHeight + Game1.MapHeight - 50) * Game1.Scale)
                {
                    direction = Direction.nw;
                }
                if (Location.X <= 50 * Game1.Scale)
                {
                    direction = Direction.se;

                }
            }
            else if (direction == Direction.nw)
            {
                Location = new Rectangle(Location.X - 1, Location.Y - 1, Location.Width, Location.Height);
                if (Location.Y <= (Game1.HUDHeight + 50) * Game1.Scale)
                {
                    direction = Direction.sw;
                }
                if (Location.X <= 50 * Game1.Scale)
                {
                    direction = Direction.ne;

                }
            }
            else if (direction == Direction.se)
            {
                Location = new Rectangle(Location.X + 1, Location.Y + 1, Location.Width, Location.Height);
                if (Location.Y >= (Game1.HUDHeight + Game1.MapHeight - 50) * Game1.Scale)
                {
                    direction = Direction.ne;
                }
                if (Location.X >= (Game1.Width - 50) * Game1.Scale)
                {
                    direction = Direction.sw;
                }
            }
            else if (direction == Direction.s)
            {
                //moves sprite down
                Location = new Rectangle(Location.X, Location.Y + 1, Location.Width, Location.Height);

                if (Location.Y >= (Game1.HUDHeight + Game1.MapHeight - 50) * Game1.Scale)
                {
                    direction = Direction.n;
                }
            }
            else
            { //direction==Direction.up
                //moves sprite up
                Location = new Rectangle(Location.X, Location.Y - 1, Location.Width, Location.Height);

                if (Location.Y <= (Game1.HUDHeight + 50) * Game1.Scale)
                {
                    direction = Direction.s;
                }
            }
        }

        public Collision GetCollision(ISprite other)
        {   //TODO get collision
            return Collision.None;
        }
    }
}