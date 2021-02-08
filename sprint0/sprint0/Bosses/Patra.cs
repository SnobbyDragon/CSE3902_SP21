using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Patra : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;
        private List<SpriteEffects> effects;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;

        public Patra(Texture2D texture, Vector2 location)
        {
            Location = location;
            Texture = texture;
            source = new Rectangle(1, 157, 16, 11);
            currFrame = 0;
            totalFrames = 2;
            repeatedFrames = 2;

            // flips to animate flying
            effects = new List<SpriteEffects>
            {
                SpriteEffects.None,
                SpriteEffects.FlipHorizontally
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, source, Color.White, 0, new Vector2(0, 0), 1, effects[currFrame / repeatedFrames], 0);
        }

        public void Update()
        {
            currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
        }
    }
}
