using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson

namespace sprint0
{
    public class Dodongo : IEnemy
    {
        //TODO:Add bomb eating animation and logic

        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private List<Rectangle> upDownSources, rightLeftSources;
        private int totalFramesUD, currentFrameUD, repeatedFrames;
        private int totalFramesRL, currentFrameRL;
        private int totalSpriteEffects, currentSpriteEffect;
        private List<SpriteEffects> spriteEffects;
        public Vector2 Destination { get; set; }
        private Direction direction = Direction.w;
        private readonly int sideLength = 16, width = 32;

        //list of source frames

        public Dodongo(Texture2D texture, Vector2 location)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(sideLength * Game1.Scale));
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
            int xPosCopy = xPos;
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


            //handles movement

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
                    direction = Direction.s;
                    currentFrameUD = 0;
                    Location = new Rectangle(Location.X, Location.Y, sideLength, Location.Height); // change to vertical dimensions
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
                    direction = Direction.n;
                    currentFrameUD = (totalFramesUD * repeatedFrames / 2) + 1;
                    Location = new Rectangle(Location.X, Location.Y, sideLength, Location.Height); // change to vertical dimensions
                }
            }
            else if (direction == Direction.s)
            {


                //amiantes sprite by fliping after every repeatedFrames frames
                currentSpriteEffect = (currentSpriteEffect + 1) % (totalSpriteEffects * repeatedFrames);

                //moves sprite down
                Location = new Rectangle(Location.X, Location.Y + 1, Location.Width, Location.Height);
                if (Location.Y >= (Game1.HUDHeight + Game1.MapHeight - 50) * Game1.Scale)
                {
                    direction = Direction.e;
                    currentFrameRL = 0;
                    Location = new Rectangle(Location.X, Location.Y, width, Location.Height); // change to horizontal dimensions
                }

            }
            else
            { //direction == Direction.up

                //amiantes sprite by fliping after every repeatedFrames frames
                currentSpriteEffect = (currentSpriteEffect + 1) % (totalSpriteEffects * repeatedFrames);

                //moves sprite up
                Location = new Rectangle(Location.X, Location.Y - 1, Location.Width, Location.Height);
                if (Location.Y <= (Game1.HUDHeight + 50) * Game1.Scale)
                {
                    direction = Direction.w;
                    currentFrameRL = (totalFramesRL * repeatedFrames / 2) + 1;
                    Location = new Rectangle(Location.X, Location.Y, width, Location.Height); // change to horizontal dimensions
                }
            }
        }
    }
}