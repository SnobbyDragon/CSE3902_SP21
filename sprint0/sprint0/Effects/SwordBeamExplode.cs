using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace sprint0
{
    public class SwordBeamExplode : IEffect
    {

        private int lifespan = 20, age = 0;
        private readonly List<Rectangle> explodeSources;
        private int xa, ya;
        private int width = 8, height = 10;
        private int currFrame = 0, totalFrames = 3;
        private readonly int repeatedFrames = 8;
        private readonly Texture2D texture;
        public Rectangle Location { get ; set; }

        public SwordBeamExplode(Texture2D texture, Vector2 location)
        {
            this.texture = texture;
            Location = new Rectangle((int)location.X, (int)location.Y, width, height);
            xa = (int)(width * Game1.Scale);
            ya = (int)(height * Game1.Scale);
            explodeSources = new List<Rectangle>
            {
                new Rectangle(27, 157, width, height),
                new Rectangle(62, 157, width, height),
                new Rectangle(97, 157, width, height)
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsAlive())
            {
                Rectangle destinationNW = new Rectangle((int)Location.X - xa, (int)Location.Y - ya, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
                Rectangle destinationNE = new Rectangle((int)Location.X + xa, (int)Location.Y - ya, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
                Rectangle destinationSW = new Rectangle((int)Location.X - xa, (int)Location.Y + ya, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
                Rectangle destinationSE = new Rectangle((int)Location.X + xa, (int)Location.Y + ya, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
                spriteBatch.Draw(texture, destinationNW, explodeSources[currFrame / repeatedFrames], Color.White);
                spriteBatch.Draw(texture, destinationNE, explodeSources[currFrame / repeatedFrames], Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);
                spriteBatch.Draw(texture, destinationSW, explodeSources[currFrame / repeatedFrames], Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipVertically, 0);
                spriteBatch.Draw(texture, destinationSE, explodeSources[currFrame / repeatedFrames], Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipVertically | SpriteEffects.FlipHorizontally, 0);
            }
        }

        public void Update()
        {
            if(IsAlive()) {
                xa += 2;
                ya += 2;
                currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
                age++;
            }
        }

        public bool IsAlive()
        {
            return age <= lifespan;
        }
    }
}
