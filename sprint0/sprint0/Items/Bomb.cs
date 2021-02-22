using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson

/*
 * Last updated: 2/21/21 by urick.9
 */
namespace sprint0
{
    public class Bomb : ISprite
    {
        public Vector2 Location { get; set; }
        private int age;
        public Texture2D Texture { get; set; }
        private Rectangle source;
        private readonly int lifespan = 30;
        private readonly int xa, ya;

        public Bomb(Texture2D texture, Vector2 location, Direction dir)
        {
            switch (dir)
            {
                case Direction.n:
                    ya = -4;
                    break;
                case Direction.s:
                    ya = 4;
                    break;
                case Direction.e:
                    xa = 4;
                    break;
                case Direction.w:
                    xa = -4;
                    break;
            }
            Location = location;
            Texture = texture;
            source=new Rectangle(136, 0, 7, 16);
            
        }

        public void Move()
        {
            Location = new Vector2(Location.X + xa, Location.Y + ya);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, source, Color.White);
        }

        public void Update()
        {
            if (age < lifespan)
            {
                Move();
            }
<<<<<<< Updated upstream
            age++;
=======
            else if(age<lifespan+3*repeatedFrames && age >= lifespan) { //age==lifespan so the bomb reached destination
                //animates bomb to explode
                currentSource = explosionSources[currentFrame/repeatedFrames];
                currentFrame = (currentFrame + 1) % (totalFrames*repeatedFrames);
            }
           
>>>>>>> Stashed changes
        }
    }
}
