using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Stuti Shah
namespace sprint0
{
    public class Compass : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;


        public Compass(Texture2D texture, Vector2 location)
        {
            Location = location;
            Texture = texture;

            //get sprite
            source = new Rectangle(258, 1, 11, 12);

        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, source, Color.White);
        }

        public void Update()
        {
            //Does nothing
        }
    }
}
