using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint0
{
    class UpIdleLinkSprite : ISprite
    { 
        public Texture2D Texture { get => texture; set => texture = value; }
        public Vector2 Location { get => location; set => location = value; }

        private Texture2D texture;
        private Vector2 location;
        private Rectangle sourceRectangle;

        public UpIdleLinkSprite(Texture2D texture, Vector2 location)
        {
            this.texture = texture;
            this.location = location;
            sourceRectangle = new Rectangle(69, 11, 16, 16);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, location, sourceRectangle, Color.White);
        }

        public void Update() { }
    }
}
