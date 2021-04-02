using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Stuti Shah
namespace sprint0
{
    public class Stalfos : AbstractEnemy
    {

        private readonly Rectangle source;
        private readonly List<SpriteEffects> spriteEffects;

        public Stalfos(Texture2D texture, Vector2 location, Game1 game) : base(texture, location, game)
        {           
            width = 16;
            height = 16;
            dirChangeDelay = 20;
            health = 20;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            totalFrames = 2;
            currentFrame = 0;
            repeatedFrames = 7;
            source = new Rectangle(1, 59, width, height);
            direction = Direction.n;
            damage = 1;
            spriteEffects = new List<SpriteEffects> {
                SpriteEffects.None,
                SpriteEffects.FlipHorizontally
            };
        }
         
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (frameSpawn >= totalFramesSpawn * repeatedFramesSpawn)
            {
                if (damageTimer % 2 == 0)
                    spriteBatch.Draw(Texture, Location, source, Color.White, 0, new Vector2(0, 0), spriteEffects[currentFrame / repeatedFrames], 0);

            }
            
        }
    }
}
