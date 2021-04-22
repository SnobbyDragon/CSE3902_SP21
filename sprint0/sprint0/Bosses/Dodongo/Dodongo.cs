using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson

namespace sprint0
{
    public class Dodongo : AbstractEnemy
    {
        private readonly List<Rectangle> upDownSources;
        private readonly List<Rectangle> rightLeftSources;
        private readonly int totalFramesUD;
        private int currentFrameUD;

        private readonly int totalFramesRL;
        private int currentFrameRL;
        private readonly int totalSpriteEffects = 2;
        private int currentSpriteEffect;
        private readonly List<SpriteEffects> spriteEffects;
        public Vector2 Destination { get; set; }

        protected readonly int sideLength = 16;
        private readonly int scaledSideLength, scaledWidth;
        private readonly int xOffsetUD = 1, yOffset = 58, xOffsetRL;

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

            direction = Direction.West;
            Location = new Rectangle((int)location.X, (int)location.Y, scaledWidth, scaledSideLength);
            Texture = texture;

            totalFramesUD = 4; currentFrameUD = 0;
            totalFramesRL = 3; currentFrameRL = 0;
            repeatedFrames = 10;
            damage = 2;

            xOffsetRL = xOffsetUD + totalFramesUD * (1 + sideLength);
            upDownSources = SpritesheetHelper.GetFramesH(xOffsetUD, yOffset, sideLength, sideLength, totalFramesUD);
            rightLeftSources = SpritesheetHelper.GetFramesH(xOffsetRL, yOffset, width, sideLength, totalFramesRL);


            currentSpriteEffect = 0;
            spriteEffects = new List<SpriteEffects> {
                SpriteEffects.None,
                SpriteEffects.FlipHorizontally
            };

            eatingCounter = 0;
            eatingTime = 20;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (damageTimer % 2 == 0)
            {
                if (direction == Direction.West || direction == Direction.East)
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
        }

        public override void Update()
        {
            if (damageTimer > 0) damageTimer--;
            CheckHealth();
            if (!game.Room.FreezeEnemies)
            {
                moveCounter++;
                if (moveCounter == dirChangeDelay) ChangeDirection();
                if (eatingCounter == 0)
                {
                    if (direction == Direction.West)
                    {
                        currentSpriteEffect = repeatedFrames + 1;
                        currentFrameRL = (currentFrameRL + 1) % ((totalFramesRL - 1) * repeatedFrames);
                        Location = new Rectangle(Location.X - 1, Location.Y, scaledWidth, scaledSideLength);
                    }
                    else if (direction == Direction.East)
                    {
                        currentSpriteEffect = 0;
                        currentFrameRL = (currentFrameRL + 1) % ((totalFramesRL - 1) * repeatedFrames);
                        Location = new Rectangle(Location.X + 1, Location.Y, scaledWidth, scaledSideLength);
                    }
                    else if (direction == Direction.South)
                    {
                        currentSpriteEffect = (currentSpriteEffect + 1) % (totalSpriteEffects * repeatedFrames);
                        Location = new Rectangle(Location.X, Location.Y + 1, scaledSideLength, scaledSideLength);
                    }
                    else
                    {
                        currentSpriteEffect = (currentSpriteEffect + 1) % (totalSpriteEffects * repeatedFrames);
                        Location = new Rectangle(Location.X, Location.Y - 1, scaledSideLength, scaledSideLength);
                    }
                }
            }
            if (eatingCounter > 0)
            {
                eatingCounter = (eatingCounter + 1) % eatingTime;
                if (eatingCounter == 0)
                {
                    if (bombsEaten >= MAX_NUM_OF_BOMBS_TO_EAT) Perish();
                    FaceDirection(direction);
                }
            }
            
        }

        public void EatBomb()
        {
            game.Room.RoomSound.AddSoundEffect(ParseSound(GetType().Name));
            bombsEaten++;
            eatingCounter = 1;
            if (direction == Direction.South) currentFrameUD = repeatedFrames;
            else if (direction == Direction.North) currentFrameUD = 3 * repeatedFrames;
            else currentFrameRL = 2 * repeatedFrames;
        }

        public override void ChangeDirection()
        {
            base.ChangeDirection();
            FaceDirection(direction);
        }

        private void FaceDirection(Direction dir)
        {
            switch (dir)
            {
                case Direction.North:
                    FaceNorth();
                    break;
                case Direction.South:
                    FaceSouth();
                    break;
                case Direction.East:
                    FaceEast();
                    break;
                case Direction.West:
                    FaceWest();
                    break;
                default:
                    throw new ArgumentException("Invalid direction for dodongo!");
            }
        }

        private void FaceNorth()
        {
            direction = Direction.North;
            currentFrameUD = 2 * repeatedFrames;
            Location = new Rectangle(Location.X, Location.Y, scaledSideLength, scaledSideLength);
        }

        private void FaceSouth()
        {
            direction = Direction.South;
            currentFrameUD = 0;
            Location = new Rectangle(Location.X, Location.Y, scaledSideLength, scaledSideLength);
        }

        private void FaceEast()
        {
            direction = Direction.East;
            currentFrameRL = 0;
            Location = new Rectangle(Location.X, Location.Y, scaledWidth, scaledSideLength);
        }

        private void FaceWest()
        {
            direction = Direction.West;
            currentFrameRL = repeatedFrames;
            Location = new Rectangle(Location.X, Location.Y, scaledWidth, scaledSideLength);
        }
        private SoundEnum ParseSound(string sound)
             => (SoundEnum)Enum.Parse(typeof(SoundEnum), sound, true);
    }
}