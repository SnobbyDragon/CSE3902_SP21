using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson

namespace sprint0
{
    public class Fairy:ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private List<Rectangle> sources;
        private int totalFrames;
        private int currentFrame;
        private int repeatedFrames;
        //private int moveCounter;

        private Vector2 destination;
        private readonly Random rand;



        public Fairy(Texture2D texture, Vector2 location)
        {
           
            Location = location;
            Texture = texture;
            totalFrames = 2;
            currentFrame = 0; repeatedFrames = 10; //moveCounter = 0;
            sources = new List<Rectangle>();
            int xPos = 40, yPos = 0, width = 7, height =16;
            sources.Add(new Rectangle(xPos, yPos, width, height));
            sources.Add(new Rectangle(xPos+width+1, yPos, width, height));

            rand = new Random();
            generateDest();


        }

        

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, sources[currentFrame/repeatedFrames], Color.White);
        }

        public void Update()
        {
            currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);

            Vector2 dist = destination - Location;
            if (dist.Length() < 5)
            {
                // reached destination, generate new destination;
                generateDest();
            }
            else 
            {
                // has not reached destination, move towards it
                dist.Normalize();
                Location += dist; 
               
            }
        
        }

        // generates a new destination
        public void generateDest()
        {
            int xlowerBound =(int) Location.X - 200;
            int ylowerBound = (int)Location.Y - 200;
            int xupperBound = (int)Location.X + 200;
            int yupperBound = (int)Location.X + 200;

            //if destination is off screen resets to screen bounds
            if (xlowerBound< 32*Game1.Scale) {
                xlowerBound = (int) (32 * Game1.Scale);
            }
            if (xupperBound > (Game1.Width - 32) * Game1.Scale)
            {
                xupperBound = (int)((Game1.Width - 32) * Game1.Scale);
            }
            if (ylowerBound < (Game1.HUDHeight + 32) * Game1.Scale)
            {
                ylowerBound = (int)((Game1.HUDHeight + 32) * Game1.Scale);
            }
            if (yupperBound > (Game1.HUDHeight + Game1.MapHeight - 32) * Game1.Scale)
            {
                yupperBound = (int)((Game1.HUDHeight + Game1.MapHeight - 32) * Game1.Scale);
            }
            // picks a random destination 

            destination = new Vector2(
                rand.Next(xlowerBound,xupperBound),
                rand.Next(ylowerBound, yupperBound)
                );
        }
    }
}
