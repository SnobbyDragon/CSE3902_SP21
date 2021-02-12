using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Dodongo:ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private List<Rectangle> sources;
        private int totalFrames, currentFrame, repeatedFrames;

        //TODO:fix this by making seperate classes
        enum Direction {left,right,front,back}
        private Direction direction = Direction.left;

        //list of source frames

        public Dodongo(Texture2D texture, Vector2 location)
        {
            Location = location;
            Texture = texture;
            totalFrames = 7;
            currentFrame = 0;
            repeatedFrames = 10;
            sources = new List<Rectangle>();
            int xPos =1, yPos =58, sideLength =16;
            for (int frame = 0; frame < totalFrames; frame++) {
                sources.Add(new Rectangle(xPos,yPos,sideLength, sideLength));
                xPos += sideLength + 1;
            }
        }

        

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, sources[currentFrame/repeatedFrames], Color.White);
        }

        public void Update()
        {
            currentFrame = (currentFrame + 1) % (totalFrames*repeatedFrames);

        }
    }
}
