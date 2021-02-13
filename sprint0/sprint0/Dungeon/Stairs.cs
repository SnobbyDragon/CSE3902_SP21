using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Stairs:ISprite
    {

        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;

        public Stairs(Texture2D texture, Vector2 location)
        {
            Location = location;
            Texture = texture;
            source = new Rectangle(1035, 28, 16, 16);
          

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, source, Color.White);
        }

        public void Update()
        {
            //No movement for now
        }
    }
}
