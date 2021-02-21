using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson

namespace sprint0
{
    public class RoomBorder:ISprite
    {

        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;
        
        public RoomBorder(Texture2D texture, Vector2 location)
        {
            Location = location;
            Texture = texture;
            source = new Rectangle(521, 11, Game1.Width, Game1.MapHeight);
          
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)Location.X, (int)Location.Y, (int)(Game1.Width * Game1.Scale), (int)(Game1.MapHeight * Game1.Scale)), source, Color.White);
            
        }

        public void Update()
        {
            //N/A
        }
    }
}
