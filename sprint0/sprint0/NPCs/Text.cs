using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Text
    {
        public Vector2 Location { get; set; }
        public SpriteFont Text1 { get; set; }
        
       
        public Text(Game1 game)
        {
         
            Location = new Vector2(170,270);
            Text1 = game.Content.Load<SpriteFont>("Font");

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Text1, "EASTMOST PENINSULA IS THE SECRET.", Location, Color.White);
        }

        public void Update()
        {
            // does nothing for now
        }
    }
}
