using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Stuti Shah
//Movemnet added by Hannah Johnson
namespace sprint0
{
    public class Trap : IEnemy
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;
        private readonly int width = 16, height = 16;
        private Direction direction;

        public Trap(Texture2D texture, Vector2 location)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;

            direction = Direction.n;

            //load sprite
            source = new Rectangle(164, 59, width, height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, source, Color.White);
        }

        public void Update()
        {
            if (direction == Direction.s)
            {
                //moves sprite down
                Location = new Rectangle(Location.X, Location.Y + 1, Location.Width, Location.Height);

            }
            else
            {   //direction == Direction.n
                //moves sprite up
                Location = new Rectangle(Location.X, Location.Y - 1, Location.Width, Location.Height);

            }
        }

        public void ChangeDirection()
        {
            Random random = new Random();
            direction = (Direction)random.Next(0, 2);
        }

        public void TakeDamage()
        {
            // not necessary; unkillable
        }
    }
}
