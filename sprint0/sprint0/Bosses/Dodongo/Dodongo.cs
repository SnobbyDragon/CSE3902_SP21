using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson

namespace sprint0
{
    public class Dodongo : IEnemy
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private List<Rectangle> upDownSources, rightLeftSources;
        private int totalFramesUD, currentFrameUD, repeatedFrames;
        private int totalFramesRL, currentFrameRL;
        private int totalSpriteEffects, currentSpriteEffect;
        private List<SpriteEffects> spriteEffects;
        public Vector2 Destination { get; set; }
        private Direction direction;
        private readonly int sideLength = 16, width = 32;
        private readonly int scaledSideLength, scaledWidth;
        private int eatingCounter, eatingTime;
        private readonly Game1 game;
        private int health;
        public Dodongo(Texture2D texture, Vector2 location, Game1 game)
        {
            health = 50;
            this.game = game;
            scaledSideLength = (int)(sideLength * Game1.Scale);
            scaledWidth = (int)(width * Game1.Scale);
            direction = Direction.w;
            Location = new Rectangle((int)location.X, (int)location.Y, scaledWidth, scaledSideLength);
            // starts horizontal
            Texture = texture;
            totalFramesUD = 4; currentFrameUD = 0;
            totalFramesRL = 3; currentFrameRL = 0;
            repeatedFrames = 10;
            upDownSources = new List<Rectangle>();
            rightLeftSources = new List<Rectangle>();
            int xPos = 1, yPos = 58;

            //adds up and down frames
            for (int frame = 0; frame < totalFramesUD; frame++)
            {
                upDownSources.Add(new Rectangle(xPos, yPos, sideLength, sideLength));
                xPos += sideLength + 1;
            }
            //adds right and left frames
            for (int frame = 0; frame < totalFramesRL; frame++)
            {
                rightLeftSources.Add(new Rectangle(xPos, yPos, width, sideLength));
                xPos += width + 1;
            }

            //Creates sprite effect list
            totalSpriteEffects = 2; currentSpriteEffect = 0;
            spriteEffects = new List<SpriteEffects> {
                SpriteEffects.None,
                SpriteEffects.FlipHorizontally
            };

            //sets Destination-later can make a set destination method
            //TODO:make movement dependent on destination
            Destination = new Vector2(700, 300);

            eatingCounter = 0; // not eating a bomb
            eatingTime = 20; // arbitrary; total time it takes to eat the bomb
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (direction == Direction.w || direction == Direction.e)
            {
                spriteBatch.Draw(Texture, Location, rightLeftSources[currentFrameRL / repeatedFrames],
                    Color.White, 0, new Vector2(0, 0), spriteEffects[currentSpriteEffect / repeatedFrames], 0);
            }
            else
            {
                spriteBatch.Draw(Texture, Location, upDownSources[currentFrameUD / repeatedFrames], Color.White,
                    0, new Vector2(0, 0), spriteEffects[currentSpriteEffect / repeatedFrames], 0);
            }
        }

        public void Update()
        {
            CheckHealth();
            //handles movement
            if (eatingCounter == 0) // not eating
            {
                if (direction == Direction.w)
                {
                    //Sets sprite effect
                    currentSpriteEffect = repeatedFrames + 1;

                    //walking animation
                    currentFrameRL = (currentFrameRL + 1) % ((totalFramesRL - 1) * repeatedFrames);

                    //moves sprite left
                    Location = new Rectangle(Location.X - 1, Location.Y, Location.Width, Location.Height);
                    if (Location.X <= 50 * Game1.Scale)
                    {
                        FaceSouth();
                    }
                }
                else if (direction == Direction.e)
                {
                    //Sets sprite effect
                    currentSpriteEffect = 0;

                    //walking animation
                    currentFrameRL = (currentFrameRL + 1) % ((totalFramesRL - 1) * repeatedFrames);

                    //moves sprite right
                    Location = new Rectangle(Location.X + 1, Location.Y, Location.Width, Location.Height);
                    if (Location.X >= (Game1.Width - 50) * Game1.Scale)
                    {
                        FaceNorth();
                    }
                }
                else if (direction == Direction.s)
                {
                    //animates sprite by fliping after every repeatedFrames frames
                    currentSpriteEffect = (currentSpriteEffect + 1) % (totalSpriteEffects * repeatedFrames);

                    //moves sprite down
                    Location = new Rectangle(Location.X, Location.Y + 1, Location.Width, Location.Height);
                    if (Location.Y >= (Game1.HUDHeight + Game1.MapHeight - 50) * Game1.Scale)
                    {
                        FaceEast();
                    }
                }
                else
                {   //direction == Direction.n

                    //animates sprite by flipping after every repeatedFrames frames
                    currentSpriteEffect = (currentSpriteEffect + 1) % (totalSpriteEffects * repeatedFrames);

                    //moves sprite up
                    Location = new Rectangle(Location.X, Location.Y - 1, Location.Width, Location.Height);
                    if (Location.Y <= (Game1.HUDHeight + 50) * Game1.Scale)
                    {
                        FaceWest();
                    }
                }
            }
            else // eating; do not move
            {
                eatingCounter = (eatingCounter + 1) % eatingTime;
                if (eatingCounter == 0) // done eating; return to normal frames
                {
                    FaceDirection(direction);
                }
            }
        }

        private void FaceDirection(Direction dir)
        {
            switch (dir)
            {
                case Direction.n:
                    FaceNorth();
                    break;
                case Direction.s:
                    FaceSouth();
                    break;
                case Direction.e:
                    FaceEast();
                    break;
                case Direction.w:
                    FaceWest();
                    break;
                default:
                    throw new ArgumentException("Invalid direction for dodongo!");
            }
        }

        public void EatBomb()
        {
            eatingCounter = 1;
            if (direction == Direction.s) // south
            {
                currentFrameUD = repeatedFrames;
            }
            else if (direction == Direction.n) // north
            {
                currentFrameUD = 3 * repeatedFrames;
            }
            else // right-left movement
            {
                currentFrameRL = 2 * repeatedFrames;
            }
        }

        public void ChangeDirection()
        {
            Random random = new Random();
            FaceDirection((Direction)random.Next(0, 4));
        }

        private void FaceNorth()
        {
            direction = Direction.n;
            currentFrameUD = 2 * repeatedFrames;
            Location = new Rectangle(Location.X, Location.Y, scaledSideLength, scaledSideLength); // change to vertical dimensions
        }

        private void FaceSouth()
        {
            direction = Direction.s;
            currentFrameUD = 0;
            Location = new Rectangle(Location.X, Location.Y, scaledSideLength, scaledSideLength); // change to vertical dimensions
        }

        private void FaceEast()
        {
            direction = Direction.e;
            currentFrameRL = 0;
            Location = new Rectangle(Location.X, Location.Y, scaledWidth, scaledSideLength); // change to horizontal dimensions
        }

        private void FaceWest()
        {
            direction = Direction.w;
            currentFrameRL = repeatedFrames;
            Location = new Rectangle(Location.X, Location.Y, scaledWidth, scaledSideLength); // change to horizontal dimensions
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