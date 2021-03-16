using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Stuti Shah
//Updated: 03/15/21 by shah.1440
namespace sprint0
{
    public class HUD : IHUD
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;


        public HUD(Texture2D texture, Vector2 location)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, 0, 0); // this rectangle is just a point
            Texture = texture;

            //load HUD sprite
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
        public void SetItem(String item)
        {
            //Does nothing
        }
    }
}
