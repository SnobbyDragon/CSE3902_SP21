using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class OldPerson : ISprite
    {
        public Vector2 Location { get; set;}
        public Texture2D Texture { get; set; }
        private Rectangle source;

        public OldPerson(Texture2D texture, Rectangle source)
        {
            Texture = texture;
            this.source = source;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, source, Color.White);
        }

        public void Update()
        {
            // does nothing for now
        }
    }
}
