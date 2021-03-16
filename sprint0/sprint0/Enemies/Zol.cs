using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson

namespace sprint0
{
    public class Zol : Enemy, IEnemy
    {
        private readonly int delay;
        private int delayCounter;
        private int spawnCounter;
        private readonly int spawnRate =1500; // arbitrary; spawns a gel every spawnRate

        public Zol(Texture2D texture, Vector2 location, string gelColor, Game1 game): base(texture, location, game)
        {
            width = 16;
            height = 16;
            repeatedFrames = 10;
            health = 10;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            totalFrames = 2;
            currentFrame = 0;
            color = gelColor;
            delay = 50;
            delayCounter = 0;
            colorMap = new Dictionary<string, List<Rectangle>>
            {
                { "green", SpritesheetHelper.GetFramesH(77, 11, width, height, totalFrames) },
                { "blkgold", SpritesheetHelper.GetFramesH(111, 11, width, height, totalFrames) },
                { "lime", SpritesheetHelper.GetFramesH(145, 11, width, height, totalFrames) },
                { "brown", SpritesheetHelper.GetFramesH(77, 28, width, height, totalFrames) },
                { "grey", SpritesheetHelper.GetFramesH(111, 28, width, height, totalFrames) },
                { "blkwhite", SpritesheetHelper.GetFramesH(145, 28, width, height, totalFrames) },
            };
            spawnCounter = spawnRate / 4;
        }

        public new void Draw(SpriteBatch spriteBatch)
        {
            if(damageTimer % 2 == 0)
                spriteBatch.Draw(Texture, Location, colorMap[color][currentFrame / repeatedFrames], Color.White);
        }

        public new void Update()
        {
            CheckHealth();
            moveCounter++;
            SpawnGel();

            currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);
            if (moveCounter == dirChangeDelay)
            {
                ArbitraryDirection(20, 80);
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

        private void SpawnGel()
        {
            if (spawnCounter == spawnRate)
            {
                Vector2 spawnLoc = Location.Location.ToVector2() + new Vector2(-39, 0);
                game.Room.AddEnemy(spawnLoc, color + " gel");
                spawnCounter = 0;
            }
            else
            {
                spawnCounter++;
            }
        }
    }
}
