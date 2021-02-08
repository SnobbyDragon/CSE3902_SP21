using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Gel:ISprite
    {

        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private List<Rectangle> sources;
        private int totalFrames;
        private int currentFrame;
        private int repeatedFrames = 10;
        private string color;
        private Dictionary<string, List<Rectangle>> colorMap;
   

        public Gel(Texture2D texture, Vector2 location, string gelColor)
        {
            Location = location;
            Texture = texture;
            totalFrames = 2;
            currentFrame = 0;
            color = gelColor;

            colorMap = new Dictionary<string, List<Rectangle>>
            {
                { "teal", GetFrames(1,11,2)},
                { "blue", GetFrames(19, 11, 2)},
                { "green", GetFrames(37, 11, 2)},
                { "blkgold", GetFrames(55, 11, 2)},
                { "lime", GetFrames(1, 28, 2)},
                { "brown", GetFrames(19, 28, 2)},
                { "grey", GetFrames(37, 28, 2)},
                { "blkwhite", GetFrames(55, 28, 2)},
            };
        }



        private List<Rectangle> GetFrames(int xPos, int yPos, int numFrames) {
            List<Rectangle> sources = new List<Rectangle>();
            int width =8;
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
        }
    }
}
