using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson

namespace sprint0
{
    public class Zol:ISprite
    {

        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private int totalFrames;
        private int currentFrame;
        private int repeatedFrames = 10;
        private string color;
        private Dictionary<string, List<Rectangle>> colorMap;
        private int delay, delayCounter;

        enum Direction { left, right, up, down }
        private Direction direction = Direction.left;


        public Zol(Texture2D texture, Vector2 location, string gelColor)
        {
            Location = location;
            Texture = texture;
            totalFrames = 2;
            currentFrame = 0;
            color = gelColor;
            delay = 50;
            delayCounter=0;

            colorMap = new Dictionary<string, List<Rectangle>>
            {
                { "green", GetFrames(77, 11, 2)},
                { "blkgold", GetFrames(111, 11, 2)},
                { "lime", GetFrames(145, 11, 2)},
                { "brown", GetFrames(77, 28, 2)},
                { "grey", GetFrames(111, 28, 2)},
                { "blkwhite", GetFrames(145, 28, 2)},
            };
        }


        //Adds source frames to a list
        private List<Rectangle> GetFrames(int xPos, int yPos, int numFrames) {
            List<Rectangle> sources = new List<Rectangle>();
            int width =16;
            int height =16;
            for (int i = 0; i < numFrames; i++) {
                sources.Add(new Rectangle(xPos,yPos,width,height));
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
            currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);

            switch (direction){
                case Direction.left:
                    //moves sprite left but in a halting manner
                    if (delayCounter == delay)
                    {
                        Location += new Vector2(-40, 0);
                        delayCounter = 0;
                    }

                    if (Location.X <= 50 * Game1.Scale)
                    {
                        direction = Direction.down;

                    }
                    break;
                case Direction.right:
                    if (delayCounter == delay)
                    {
                        Location += new Vector2(40, 0);
                        delayCounter = 0;
                    }

                    if (Location.X >= (Game1.Width - 50) * Game1.Scale)
                    {
                        direction = Direction.up;

                    }
                    break;
                case Direction.down:
                    if (delayCounter == delay)
                    {
                        Location += new Vector2(0, 40);
                        delayCounter = 0;
                    }
                    if (Location.Y >= (Game1.HUDHeight + Game1.MapHeight - 50) * Game1.Scale)
                    {
                        direction = Direction.right;

                    }
                    break;
                case Direction.up:
                    if (delayCounter == delay)
                    {
                        Location += new Vector2(0, -40);
                        delayCounter = 0;
                    }
                    if (Location.Y <= (Game1.HUDHeight + 50) * Game1.Scale)
                    {
                        direction = Direction.left;

                    }
                    break;

            };
            delayCounter++;
        }
    }
}
