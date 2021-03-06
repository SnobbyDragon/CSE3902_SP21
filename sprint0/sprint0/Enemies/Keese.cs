using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Keese : IEnemy
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private int currentFrame;
        private string color;
        private readonly int totalFrames, repeatedFrames;
        private Dictionary<string, List<Rectangle>> colorMap;
        private readonly int width, height;

        Direction direction;
        public Keese(Texture2D texture, Vector2 location, String keeseColor)
        {
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
                { "blue", GetFrames(183, 11, 2)},
                { "red", GetFrames(183, 28, 2)}
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
            spriteBatch.Draw(Texture, Location, colorMap[color][currentFrame / repeatedFrames], Color.White);
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
                Location = new Rectangle(Location.X, Location.Y + 1, Location.Width, Location.Height);

                if (Location.Y >= (Game1.HUDHeight + Game1.MapHeight - 50) * Game1.Scale)
                {
                    direction = Direction.e;
                }
            }
            else
            { //direction==Direction.up
                //moves sprite up
                Location = new Rectangle(Location.X, Location.Y - 1, Location.Width, Location.Height);

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