using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson

namespace sprint0
{
    public class Dodongo : Enemy, IEnemy
    {


        private readonly List<Rectangle> upDownSources;
        private readonly List<Rectangle> rightLeftSources;
        private readonly int totalFramesUD;
        private int currentFrameUD;
  
        private readonly int totalFramesRL;
        private int currentFrameRL;
        private readonly int totalSpriteEffects;
        private int currentSpriteEffect;
        private readonly List<SpriteEffects> spriteEffects;
        public Vector2 Destination { get; set; }
        protected readonly int sideLength = 16;
        private readonly int scaledSideLength, scaledWidth;
        private int eatingCounter;
        private readonly int eatingTime;
        private readonly int MAX_NUM_OF_BOMBS_TO_EAT = 3;
        private int bombsEaten;
        public Dodongo(Texture2D texture, Vector2 location, Game1 game) : base(texture, location, game)
        {
            bombsEaten = 0;
            width = 32;
            health = 50;
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


            eatingCounter = 0; // not eating a bomb
            eatingTime = 20; // arbitrary; total time it takes to eat the bomb
        }

        public new void Draw(SpriteBatch spriteBatch)
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

        public new void Update()
        {

          
           
            moveCounter++;
            if (moveCounter == dirChangeDelay)
            {
               ArbitraryDirection(30,50);
            }
            FaceDirection(direction);

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
                        //FaceSouth();
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
                       // FaceNorth();
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
                        //FaceEast();
                    }
                }
                else
                {  
                    //animates sprite by flipping after every repeatedFrames frames
                    currentSpriteEffect = (currentSpriteEffect + 1) % (totalSpriteEffects * repeatedFrames);

                    //moves sprite up
                    Location = new Rectangle(Location.X, Location.Y - 1, Location.Width, Location.Height);
                    if (Location.Y <= (Game1.HUDHeight + 50) * Game1.Scale)
                    {

                       // FaceWest();
                    }
                }
            }
            else // eating; do not move
            {
                eatingCounter = (eatingCounter + 1) % eatingTime;
                if (eatingCounter == 0) // done eating; return to normal frames
                {
                    //FaceDirection(direction);

                }

            }
            if (bombsEaten >= MAX_NUM_OF_BOMBS_TO_EAT && eatingCounter == 0)
            {
                Perish();
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
            bombsEaten++;
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


    }
}