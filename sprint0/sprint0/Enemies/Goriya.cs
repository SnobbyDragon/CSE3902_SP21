using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Goriya : IEnemy
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private int currentFrame;
        private readonly string color;
        private readonly int totalFrames;
        private readonly int repeatedFrames;
        private Dictionary<string, List<Rectangle>> colorMap;
        private readonly SpriteEffects s = SpriteEffects.FlipHorizontally;
        private Direction direction;
        private readonly int width, height;
        private int health;
        private int moveCounter, dirChangeDelay;
        private readonly Random rand;
        private readonly Game1 game;
        public Goriya(Texture2D texture, Vector2 location, string goriyaColor, Game1 game)
        {
            rand = new Random();
            this.game = game;
            health = 50;
            width = height = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
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
            moveCounter++;
            if (moveCounter == dirChangeDelay)
            {
                ArbitraryDirection();
            }
            CheckHealth();

            currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);
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
                Location = new Rectangle(Location.X, Location.Y + 1, Location.Width, Location.Height); ;

            }
            else
            {
                //moves sprite up
                Location = new Rectangle(Location.X, Location.Y - 1, Location.Width, Location.Height); ;

            }
        }
        private void ArbitraryDirection()
        {
            // changes to an arbitrary direction; if in wall, go into room, else random direction
            // TODO 32 is a magic number for room border / wall width... make static variable in Game1?
            moveCounter = 0;
            if (Location.X <= 32 * Game1.Scale) // in the left wall, move right
            {
                direction = Direction.e;
            }
            else if (Location.X >= (Game1.Width - 32) * Game1.Scale) // in the right wall, move left
            {
                direction = Direction.w;
            }
            else if (Location.Y <= (Game1.HUDHeight + 32) * Game1.Scale) // in the top wall, move down
            {
                direction = Direction.s;
            }
            else if (Location.Y >= (Game1.HUDHeight + Game1.MapHeight - 32) * Game1.Scale) // in the bottom wall, move up
            {
                direction = Direction.n;
            }
            else // not in a wall, move in random direction
            {
                direction = (Direction)rand.Next(0, 4);
            }
            dirChangeDelay = rand.Next(30, 50); //TODO may still go into the wall... not sure if that's okay?
        }

        public void ChangeDirection()
        {
            ArbitraryDirection();
        }

        private void CheckHealth()
        {
            if (health < 0) Perish();
        }
        public void TakeDamage(int damage)
        {
            health -= damage;
        }

        public void Perish()
        {
            game.RemoveEnemy(this);
        }
    }
}