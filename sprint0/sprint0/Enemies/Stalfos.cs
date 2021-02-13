using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Stalfos : ISprite
    {
        SpriteEffects s = SpriteEffects.FlipHorizontally;
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;
        private int currFrame;

        public Stalfos(Texture2D texture, Vector2 location)
        {
            Location = location;
            Texture = texture;
            source = new Rectangle(1, 59, 16, 16);
            currFrame = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, source, Color.White, 0, new Vector2(0, 0), new Vector2(1, 1), s, 0);
        }

        public void Update()
        {
            if (currFrame % 14 < 7)
            {
                s = SpriteEffects.FlipHorizontally;
            }
            else
            {
                s = SpriteEffects.None;
            }
            currFrame++;
        }
    }
}
