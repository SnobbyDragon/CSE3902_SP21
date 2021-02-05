using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class GleeokNeck : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;

        public GleeokNeck(Texture2D texture, Vector2 location)
        {
            Location = location;
            Texture = texture;
            source = new Rectangle(271, 13, 8, 12);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, source, Color.White);
        }

        public void Update()
        {
            // does nothing for now TODO movement
        }
    }
}
