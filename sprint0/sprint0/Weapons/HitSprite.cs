using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class HitSprite : ISprite
    {
        private readonly Rectangle source;
        private readonly int xLoc = 53, yLoc = 189, width = 8, height = 8;
        private Texture2D texture;
        private readonly int lifespan = 4;
        private int age = 0;

        public Rectangle Location { get ; set ; }

        public HitSprite(Texture2D texture, Vector2 location)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            source = new Rectangle(xLoc, yLoc, width, height);
            this.texture = texture;
        }
        public bool IsAlive()
        {
            return age <= lifespan;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(IsAlive()) spriteBatch.Draw(texture, Location, source, Color.White);
        }

        public void Update()
        {
            age++;
        }
    }
}
