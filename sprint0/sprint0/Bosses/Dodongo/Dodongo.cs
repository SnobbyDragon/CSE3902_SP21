using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Dodongo : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private List<Rectangle> upDownSources, rightLeftSources;
        private int totalFramesUD, currentFrameUD, repeatedFrames;
        private int totalFramesRL, currentFrameRL;
        SpriteEffects s = SpriteEffects.FlipHorizontally;
        private int xcoordinate;
        private int ycoordinate;
        public Vector2 Destination { get; set; }
        private Rectangle destinationRectangle;


        enum Direction { left, right, up, down }
        private Direction direction = Direction.left;

        //list of source frames

        public Dodongo(Texture2D texture, Vector2 location)
        {
            Location = location;
            Texture = texture;
            totalFramesUD = 4; currentFrameUD = 0;
            totalFramesRL = 6; currentFrameRL = (totalFramesRL/2)+1;
            repeatedFrames = 10;
            upDownSources = new List<Rectangle>();
            rightLeftSources = new List<Rectangle>();
            int xPos = 1, yPos = 58, sideLength = 16;
            xcoordinate = (int)Location.X;
            ycoordinate = (int)Location.Y;
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
                if (frame == 3) { xPos = xPosCopy; }
                rightLeftSources.Add(new Rectangle(xPos, yPos, width, sideLength));
                xPos += width + 1;

            }

            //sets Destination-later can make a set destination method
            Destination = new Vector2(700, 300);
        }



        public void Draw(SpriteBatch spriteBatch)

        {
          

            if (direction == Direction.left || direction == Direction.right)
            {
                destinationRectangle = new Rectangle(xcoordinate, ycoordinate, 32, 16);
                
                spriteBatch.Draw(Texture, destinationRectangle, rightLeftSources[currentFrameRL / repeatedFrames],
                    Color.White, 0, new Vector2(0, 0), s, 0);
            }
            else
            {
                destinationRectangle = new Rectangle(xcoordinate, ycoordinate, 16, 16);
                spriteBatch.Draw(Texture, destinationRectangle, upDownSources[currentFrameUD / repeatedFrames], Color.White,
                    0, new Vector2(0, 0), s, 0);
            }

        }

        public void Update()
        {

            
            //handels movement

            if (direction == Direction.left)
            {
                //Sets sprite effect
                s = SpriteEffects.FlipHorizontally;

                currentFrameRL = (currentFrameRL + 1) % (totalFramesRL * repeatedFrames);
                if (currentFrameRL == totalFramesRL * repeatedFrames-1) 
                {
                    currentFrameRL = (totalFramesRL*repeatedFrames / 2) + 1;
                }


                xcoordinate--;
                if (xcoordinate <= 200)
                {
                    direction = Direction.down;
                    currentFrameUD = 0;
                    
                }
            }
            else if (direction == Direction.right)
            {
                //Sets sprite effect
                s = SpriteEffects.None;

                currentFrameRL = (currentFrameRL + 1) % (totalFramesRL * repeatedFrames);
                if (currentFrameRL == totalFramesRL*repeatedFrames / 2)
                {
                    currentFrameRL = 0;
                }
                


                xcoordinate++;
                if (xcoordinate >= 500)
                {
                    direction = Direction.up;
                    currentFrameUD = (totalFramesUD*repeatedFrames / 2)+1;
                    
                }



            } else if (direction == Direction.down) {
                currentFrameUD = (currentFrameUD + 1) % (totalFramesUD * repeatedFrames);
                if (currentFrameUD == totalFramesUD*repeatedFrames / 2)
                {
                    currentFrameUD = 0;
                }

                ycoordinate++;
                if (ycoordinate >= 300)
                {
                    direction = Direction.right;
                    currentFrameRL = 0;
                    
                }

            } else { //direction == Direction.up

                currentFrameUD = (currentFrameUD + 1) % (totalFramesUD * repeatedFrames);
                if (currentFrameUD == totalFramesUD*repeatedFrames-1)
                {
                    currentFrameUD = (totalFramesUD*repeatedFrames / 2) + 1;
                }

                ycoordinate--;
                if (ycoordinate <= 200)
                {
                    direction = Direction.left;
                    currentFrameRL = (totalFramesRL*repeatedFrames / 2) + 1;
                    
                }
            }

        }
    }
}