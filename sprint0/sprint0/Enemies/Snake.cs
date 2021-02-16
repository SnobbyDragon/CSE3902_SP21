using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Snake:ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private List<Rectangle> sources;
        private int totalFrames;
        private int currentFrame;
        private int repeatedFrames;
        private SpriteEffects spriteEffect;

        enum Direction { left, right, up, down }
        private Direction direction = Direction.left;

        public Snake(Texture2D texture, Vector2 location)
        {
            Location = location;
            Texture = texture;
            spriteEffect = SpriteEffects.None;
            totalFrames = 2;
            currentFrame = 0;
            repeatedFrames = 10;
            sources = new List<Rectangle>();
            int xPos = 126, yPos = 59, sideLength = 16;
            //add frames to list
            for (int frame = 0; frame < totalFrames; frame++)
            {
                sources.Add(new Rectangle(xPos, yPos, sideLength, sideLength));
                xPos += sideLength + 1;
            }
            


        }

        
        public void Draw(SpriteBatch spriteBatch)
        {
           
            spriteBatch.Draw(Texture, Location, sources[currentFrame / repeatedFrames],
                    Color.White, 0, new Vector2(0, 0), new Vector2(1, 1), spriteEffect, 0);
        }

        public void Update()
        {
            currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);
            if (direction == Direction.left)
            {
                //sets sprite effect so snake faces left
                spriteEffect = SpriteEffects.FlipHorizontally;
                //moves sprite left
                Location += new Vector2(-1, 0);
                if (Location.X <= 100)
                {
                    direction = Direction.down;
                    

                }
            }
            else if (direction == Direction.right)
            {
                //sets sprite effect so snake faces right
                spriteEffect = SpriteEffects.None;
                //moves sprite right
                Location += new Vector2(1, 0);
                if (Location.X >= 690)
                {
                    direction = Direction.up;
                   
                }
            }
            else if (direction == Direction.down)
            {
                //moves sprite down
                Location += new Vector2(0, 1);
                if (Location.Y >= 396)
                {
                    direction = Direction.right;
                  
                }
            }
            else { //direction==Direction.up
                //moves sprite up
                Location += new Vector2(0, -1);
                if (Location.Y <= 136)
                {
                    direction = Direction.left;
                    
                }
            }
        }
    }
}
