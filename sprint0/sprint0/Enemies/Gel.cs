using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson

namespace sprint0
{
    public class Gel : IEnemy
    {

        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int totalFrames;
        private int currentFrame;
        private readonly int repeatedFrames = 10;
        private readonly string color;
        private Dictionary<string, List<Rectangle>> colorMap;
        private readonly int width = 8, height = 16;
        private int health;
        private Direction direction = Direction.w;
        private int directionChangeCounter;
        private readonly Game1 game;
        private int moveCounter, dirChangeDelay;
        private readonly Random rand;
        public Gel(Texture2D texture, Vector2 location, Game1 game, string gelColor)
        {
            rand = new Random();
            this.game = game;
            health = 10;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            totalFrames = 2;
            currentFrame = 0;
            color = gelColor;
            directionChangeCounter = 0;

            colorMap = new Dictionary<string, List<Rectangle>>
            {
                { "teal", GetFrames(1,11,2)},
                { "blue", GetFrames(19, 11, 2)},
                { "green", GetFrames(37, 11, 2)},
                { "blkgold", GetFrames(55, 11, 2)},
                { "lime", GetFrames(1, 28, 2)},
                { "brown", GetFrames(19, 28, 2)},
                { "grey", GetFrames(37, 28, 2)},
                { "blkwhite", GetFrames(55, 28, 2)},
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
            moveCounter++;
            if (moveCounter == dirChangeDelay)
            {
                ArbitraryDirection();
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
