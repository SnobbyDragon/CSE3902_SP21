using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson

namespace sprint0
{
    public class Dodongo : ISprite
    {
        //TODO:Add bomb eating animation and logic

        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private List<Rectangle> upDownSources, rightLeftSources;
        private int totalFramesUD, currentFrameUD, repeatedFrames;
        private int totalFramesRL, currentFrameRL;
        private int totalSpriteEffects, currentSpriteEffect;
        private List<SpriteEffects> spriteEffects;
        public Vector2 Destination { get; set; }
        

        enum Direction { left, right, up, down }
        private Direction direction = Direction.left;

        //list of source frames

        public Dodongo(Texture2D texture, Vector2 location)
        {
            Location = location;
            Texture = texture;
            totalFramesUD = 4; currentFrameUD = 0;
            totalFramesRL = 3; currentFrameRL = 0;
            repeatedFrames = 10;
            upDownSources = new List<Rectangle>();
            rightLeftSources = new List<Rectangle>();
            int xPos = 1, yPos = 58, sideLength = 16;
         
            //adds up and down frames
            for (int frame = 0; frame < totalFramesUD; frame++)
            {
                upDownSources.Add(new Rectangle(xPos, yPos, sideLength, sideLength));
                xPos += sideLength + 1;
            }
            //adds right and left frames
            int width = 32;
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
            if (direction == Direction.left || direction == Direction.right)
            {
                
                spriteBatch.Draw(Texture, Location, rightLeftSources[currentFrameRL / repeatedFrames],
                    Color.White, 0, new Vector2(0, 0), new Vector2(1, 1), spriteEffects[currentSpriteEffect/repeatedFrames], 0);
            }
            else
            {
                
                spriteBatch.Draw(Texture, Location, upDownSources[currentFrameUD / repeatedFrames], Color.White,
                    0, new Vector2(0, 0), new Vector2(1, 1), spriteEffects[currentSpriteEffect / repeatedFrames], 0);
            }

        }

        public void Update()
        {

            
            //handles movement

            if (direction == Direction.left)
            {
                //Sets sprite effect
                currentSpriteEffect = repeatedFrames+1;

                //walking animation
                currentFrameRL = (currentFrameRL + 1) % ((totalFramesRL-1) * repeatedFrames);

                //moves sprite left
                Location += new Vector2(-1,0);
                if(Location.X <= 50 * Game1.Scale)
                {
                    direction = Direction.down;
                    currentFrameUD = 0;
                    
                }
            }
            else if (direction == Direction.right)
            {
                //Sets sprite effect
                currentSpriteEffect = 0;

                //walking animation
                currentFrameRL = (currentFrameRL + 1) % ((totalFramesRL-1) * repeatedFrames);

                
                //moves sprite right
                Location += new Vector2(1, 0);
                if (Location.X >= (Game1.Width - 50) * Game1.Scale)
                {
                    direction = Direction.up;
                    currentFrameUD = (totalFramesUD*repeatedFrames / 2)+1;
                    
                }



            } else if (direction == Direction.down) {
                 
               
                //amiantes sprite by fliping after every repeatedFrames frames
                currentSpriteEffect = (currentSpriteEffect + 1)%(totalSpriteEffects*repeatedFrames);

                //moves sprite down
                Location += new Vector2(0, 1);
                if (Location.Y >= (Game1.HUDHeight + Game1.MapHeight - 50) * Game1.Scale)
                {
                    direction = Direction.right;
                    currentFrameRL = 0;
                    
                }

            } else { //direction == Direction.up

                //amiantes sprite by fliping after every repeatedFrames frames
                currentSpriteEffect = (currentSpriteEffect + 1) % (totalSpriteEffects * repeatedFrames);
                
                //moves sprite up
                Location += new Vector2(0,-1);
                if (Location.Y <= (Game1.HUDHeight + 50) * Game1.Scale)
                {
                    direction = Direction.left;
                    currentFrameRL = (totalFramesRL*repeatedFrames / 2) + 1;
                    
                }
            }

        }
    }
}