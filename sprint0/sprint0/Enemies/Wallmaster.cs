using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
namespace sprint0
{
    public class Wallmaster : AbstractEnemy
    {

        private readonly int xOffset = 393, yOffset = 11;
        private readonly List<Rectangle> sources;
        private readonly SpriteEffects s;

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
            damage = 1;

            if (Location.X <= Game1.Width / 2)
            {
                s = SpriteEffects.None;
            }
            else
            {
                s = SpriteEffects.FlipHorizontally;
            }
            if (Location.Y < Game1.MapHeight / 2 + Game1.HUDHeight)
            {
                s |= SpriteEffects.FlipVertically;
            }

            ChangeDirection();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
            if (frameSpawn >= totalFramesSpawn * repeatedFramesSpawn)
            {
                spriteBatch.Draw(Texture, Location, sources[currentFrame / repeatedFrames], Color.White, 0, new Vector2(0, 0), s, 0);
            }
            
        }
    }

}
