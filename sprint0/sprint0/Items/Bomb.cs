using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson

/*
 * Last updated: 2/21/21 by urick.9
 */

//This code is not that pretty-if find extra time refactor

namespace sprint0
{
    public class Bomb : ISprite
    {
        public Vector2 Location { get; set; }
        //Age is the current number of updates
        private int age;
        public Texture2D Texture { get; set; }
        private Rectangle source;
        private List<Rectangle> explosionSources;
        //Lifespan is the number of updates before it dies. 
        //For now, it just stops rendering
        private readonly int lifespan;
        private readonly int xadd, yadd;
        private int repeatedFrames;
        private int totalFrames, currentFrame;
        private Rectangle currentSource;

        public Bomb(Texture2D texture, Vector2 location, Direction dir, int lifespan)
        {
            switch (dir)
            {
                //based on the direction link is facing the bomb is thrown 4 away
                case Direction.n:
                    yadd = -4;
                    break;
                case Direction.s:
                    yadd = 4;
                    break;
                case Direction.e:
                    xadd = 4;
                    break;
                case Direction.w:
                    xadd = -4;
                    break;
            }
            Location = location;
            Texture = texture;
            repeatedFrames = 5;
            this.lifespan = lifespan;
            source=new Rectangle(127, 184, 10, 17);
            //add frames to explosion sources
            totalFrames = 3; currentFrame=0;
            int xPos = 138, yPos = 184, width = 17, height = 18;
            explosionSources = new List<Rectangle>();
            for (int frame = 0; frame < totalFrames; frame++)
            {
                explosionSources.Add(new Rectangle(xPos, yPos, width, height));
                xPos += width + 1;
            }

        }

        public void Move()
        {
            Location = new Vector2(Location.X + xadd, Location.Y + yadd);
        }

        private Boolean Alive()
        {
            if (age <= lifespan + 3 * repeatedFrames || lifespan <= 0)
            {
                age++;
                return true;
            }
            return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Alive())
            {
                spriteBatch.Draw(Texture, Location, currentSource, Color.White);
            }
        }

        public void Update()
        {
            currentSource = source;
            //the bomb is being thrown
            if (age < lifespan)
            {
                Move();
            }
            else if(age<=lifespan+3*repeatedFrames && age >= lifespan) { //age==lifespan so the bomb reached destination
                //animates bomb to explode
                currentSource = explosionSources[currentFrame/repeatedFrames];
                currentFrame = (currentFrame + 1) % (totalFrames*repeatedFrames);
            }
           
        }
    }
}
