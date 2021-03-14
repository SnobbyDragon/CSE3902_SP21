using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson

namespace sprint0
{
    public class Zol : IEnemy
    {
        private readonly Game1 game;
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int totalFrames;
        private int currentFrame;
        private readonly int repeatedFrames = 10;
        private readonly string color;
        private readonly Dictionary<string, List<Rectangle>> colorMap;
        private readonly int delay;
        private int moveCounter, dirChangeDelay;
        private readonly Random rand;
        private int delayCounter;
        private readonly int width = 16, height = 16;
        private Direction direction = Direction.w;
        private int spawnCounter;
        private readonly int spawnRate = 1500; // arbitrary; spawns a gel every spawnRate
        private int health;
        public Zol(Texture2D texture, Vector2 location, string gelColor, Game1 game)
        {
            health = 250;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            totalFrames = 2;
            currentFrame = 0;
            color = gelColor;
            delay = 50;
            delayCounter = 0;
            rand = new Random();
            colorMap = new Dictionary<string, List<Rectangle>>
            {
                { "green", GetFrames(77, 11, 2)},
                { "blkgold", GetFrames(111, 11, 2)},
                { "lime", GetFrames(145, 11, 2)},
                { "brown", GetFrames(77, 28, 2)},
                { "grey", GetFrames(111, 28, 2)},
                { "blkwhite", GetFrames(145, 28, 2)},
            };

            spawnCounter =(int) spawnRate/4;
            this.game = game;
        }

        //Adds source frames to a list
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
            CheckHealth();
            moveCounter++;
            SpawnGel();

            currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);
            if (moveCounter == dirChangeDelay)
            {
                ArbitraryDirection();
            }
            switch (direction)
            {
                case Direction.w:
                    //moves sprite left but in a halting manner
                    if (delayCounter == delay)
                    {
                        Location = new Rectangle(Location.X - 39, Location.Y, Location.Width, Location.Height);
                        delayCounter = 0;
                    }
                    break;
                case Direction.e:
                    if (delayCounter == delay)
                    {
                        Location = new Rectangle(Location.X + 39, Location.Y, Location.Width, Location.Height);
                        delayCounter = 0;
                    }

                    break;
                case Direction.s:
                    if (delayCounter == delay)
                    {
                        Location = new Rectangle(Location.X, Location.Y + 39, Location.Width, Location.Height);
                        delayCounter = 0;
                    }
                    break;
                case Direction.n:
                    if (delayCounter == delay)
                    {
                        Location = new Rectangle(Location.X, Location.Y - 39, Location.Width, Location.Height);
                        delayCounter = 0;
                    }
                    break;

            };
            delayCounter++;
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
            dirChangeDelay = rand.Next(10, 50); //TODO may still go into the wall... not sure if that's okay?
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

        private void SpawnGel()
        {
            // makes gel babies lol
            if (spawnCounter == spawnRate)
            {
                // TODO gel collides with zol, but maybe they should be able to be on top of each other?
                Vector2 spawnLoc = Location.Location.ToVector2();
                spawnLoc += new Vector2(-39, 0);
                game.AddEnemy(spawnLoc, color + " gel");
                spawnCounter = 0;
            }
            else
            {
                spawnCounter++;
            }
        }
    }
}
