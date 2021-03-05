using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Goriya : ISprite
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private int currentFrame;
        private readonly string color;
        private int totalFrames, repeatedFrames;
        private Dictionary<string, List<Rectangle>> colorMap;
        private readonly SpriteEffects s = SpriteEffects.FlipHorizontally;
        private Direction direction;
        private readonly int width, height;

        public Goriya(Texture2D texture, Vector2 location, string goriyaColor)
        {
            width = height = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, width, height);
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

        private List<Rectangle> GetFrames(int xPos, int yPos, int numFrames)
        {
            List<Rectangle> sources = new List<Rectangle>();
            for (int i = 0; i < numFrames; i++)
            {
                sources.Add(new Rectangle(xPos, yPos, width, height));
                xPos += width + 1;
            }
            return sources;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (direction == Direction.w)
            {
                spriteBatch.Draw(Texture, Location, colorMap[color][(currentFrame / repeatedFrames) % 2 + 2], Color.White, 0, new Vector2(0, 0), s, 0);
                //TODO GoriyaBoomerang boomboom = new GoriyaBoomerang(Texture, new Vector2(0, 231));
            }
            else if (direction == Direction.e)
            {
                spriteBatch.Draw(Texture, Location, colorMap[color][(currentFrame / repeatedFrames) % 2 + 2], Color.White);
            }
            else if (direction == Direction.s)
            {
                spriteBatch.Draw(Texture, Location, colorMap[color][0], Color.White);
            }
            else
            {
                spriteBatch.Draw(Texture, Location, colorMap[color][1], Color.White);
            }

        }

        public void Update()
        {

            currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);
            if (direction == Direction.w)
            {
                //moves sprite left
                Location = new Rectangle(Location.X - 1, Location.Y, Location.Width, Location.Height);

                if (Location.X <= 50 * Game1.Scale)
                {
                    direction = Direction.s;

                }
            }
            else if (direction == Direction.e)
            {

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
                Location = new Rectangle(Location.X, Location.Y + 1, Location.Width, Location.Height); ;

                if (Location.Y >= (Game1.HUDHeight + Game1.MapHeight - 50) * Game1.Scale)
                {
                    direction = Direction.e;
                }
            }
            else
            {   //direction == Direction.up
                //moves sprite up
                Location = new Rectangle(Location.X, Location.Y - 1, Location.Width, Location.Height); ;

                if (Location.Y <= (Game1.HUDHeight + 50) * Game1.Scale)
                {
                    direction = Direction.w;
                }
            }
        }

        public Collision GetCollision(ISprite other)
        {   //TODO get collision
            return Collision.None;
        }
    }
}