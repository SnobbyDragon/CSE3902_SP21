using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
namespace sprint0
{
    public class Wallmaster : Enemy, IEnemy
    {

        private readonly int xOffset = 393, yOffset = 11;
        private readonly List<Rectangle> sources;
        private readonly SpriteEffects s; // could be flipped horizontally, vertically, or both

        public Wallmaster(Texture2D texture, Vector2 location, Game1 game) : base(texture, location, game)
        {
            width = 16;
            height = 16;
            health = 50;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            sources = SpritesheetHelper.GetFramesH(xOffset, yOffset, width, height, 2);
            totalFrames = 2;
            repeatedFrames = 8;

            if (Location.X <= Game1.Width / 2) // if coming from the left, then faces right
            {
                s = SpriteEffects.None;
            }
            else // if coming from the right, then faces left
            {
                s = SpriteEffects.FlipHorizontally;
            }
            if (Location.Y < Game1.MapHeight / 2 + Game1.HUDHeight) // if coming from above, faces down
            {
                s |= SpriteEffects.FlipVertically;
            } // otherwise (coming from below), faces up

            ChangeDirection();
        }

        public new void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, sources[currentFrame / repeatedFrames], Color.White, 0, new Vector2(0, 0), s, 0);
        }
    }

}
