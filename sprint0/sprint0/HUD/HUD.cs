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
            source = new Rectangle(258, 11, Game1.Width, Game1.HUDHeight);

        }



        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)Location.X, (int)Location.Y, (int)(Game1.Width * Game1.Scale), (int)(Game1.HUDHeight * Game1.Scale)), source, Color.White);
        }

        public void Update()
        {
            //Does nothing
        }
    }
}
