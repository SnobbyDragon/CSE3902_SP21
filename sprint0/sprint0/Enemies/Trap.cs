using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Stuti Shah
namespace sprint0
{
    public class Trap : IEnemy
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;
        private readonly int width = 16, height = 16;

        public Trap(Texture2D texture, Vector2 location)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;

            //load sprite
            source = new Rectangle(164, 59, width, height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, source, Color.White);
        }

        public void Update()
        {
            // N/A
        }

        public Collision GetCollision(ISprite other)
        {   //TODO get collision
            return Collision.None;
        }
    }
}
