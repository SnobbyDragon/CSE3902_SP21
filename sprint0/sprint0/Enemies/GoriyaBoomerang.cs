
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class GoriyaBoomerang : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int xOffset = 290, yOffset = 11, sizeX = 7, sizeY = 15;
        private List<Rectangle> sources;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;
        SpriteEffects h = SpriteEffects.FlipHorizontally;
        SpriteEffects v = SpriteEffects.FlipVertically;
        enum Direction { left, right, up, down, ne, se, sw, nw }
        Direction direction;

        public GoriyaBoomerang(Texture2D texture, Vector2 location, int dir)
        {
            Location = location;
            Texture = texture;
            direction = (Direction)dir;
            sources = new List<Rectangle>
            {
                new Rectangle(xOffset, yOffset, sizeX, sizeY),
                new Rectangle(xOffset + sizeX + 2, yOffset, sizeX, sizeY),
                new Rectangle(xOffset + sizeX*2 + 4, yOffset, sizeX+1, sizeY)
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
                spriteBatch.Draw(Texture, Location, sources[1], Color.White, 0, new Vector2(0, 0), new Vector2(1, 1), h, 0);
            }
            else if (tempFrame == 4){
                spriteBatch.Draw(Texture, Location, sources[0], Color.White, 0, new Vector2(0, 0), new Vector2(1, 1), h, 0);
            }
            else if (tempFrame == 5)
            {
                spriteBatch.Draw(Texture, Location, sources[1], Color.White, 0, new Vector2(0, 0), new Vector2(1, 1), v | h, 0);
            }
            else if (tempFrame == 6)
            {
                spriteBatch.Draw(Texture, Location, sources[2], Color.White, 0, new Vector2(0, 0), new Vector2(1, 1), v, 0);
            }
            else if (tempFrame == 7)
            {
                spriteBatch.Draw(Texture, Location, sources[1], Color.White, 0, new Vector2(0, 0), new Vector2(1, 1), v, 0);
            }
            else
            {
                spriteBatch.Draw(Texture, Location, sources[currFrame / repeatedFrames], Color.White);
            }
            
        }

        public void Update()
        {
            currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
            if (direction == Direction.left)
            {
                //moves sprite left
                Location += new Vector2(-1, 0);

                if (Location.X <= 50 * Game1.Scale)
                {
                    direction = Direction.right;

                }
            }
            else if (direction == Direction.right)
            {

                //moves sprite right
                Location += new Vector2(1, 0);

                if (Location.X >= (Game1.Width - 50) * Game1.Scale)
                {
                    direction = Direction.left;
                }
            }
            else if (direction == Direction.ne)
            {
                Location += new Vector2(1, -1);
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
                Location += new Vector2(-1, 1);
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
                Location += new Vector2(-1, -1);
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
                Location += new Vector2(1, 1);
                if (Location.Y >= (Game1.HUDHeight + Game1.MapHeight - 50) * Game1.Scale)
                {
                    direction = Direction.ne;
                }
                if (Location.X >= (Game1.Width - 50) * Game1.Scale)
                {
                    direction = Direction.sw;
                }
            }
            else if (direction == Direction.down)
            {
                //moves sprite down
                Location += new Vector2(0, 1);

                if (Location.Y >= (Game1.HUDHeight + Game1.MapHeight - 50) * Game1.Scale)
                {
                    direction = Direction.up;
                }
            }
            else
            { //direction==Direction.up
                //moves sprite up
                Location += new Vector2(0, -1);

                if (Location.Y <= (Game1.HUDHeight + 50) * Game1.Scale)
                {
                    direction = Direction.down;
                }
            }
        }
    }
}