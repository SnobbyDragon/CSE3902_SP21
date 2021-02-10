using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class HUD : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;


        public HUD(Texture2D texture, Vector2 location)
        {
            Location = location;
            Texture = texture;
            source = new Rectangle(257, 11, 256, 56);

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
