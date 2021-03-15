using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    class FlameProjectile : IProjectile
    {
        public IEntity Shooter { get; }

        public int Damage { get; set; }

        public Rectangle Location { get; set; }

        private Texture2D texture;
        private Rectangle source;
        private SpriteEffects s = SpriteEffects.FlipHorizontally;
        private int currentFrame;
        private int repeatedFrames;
        private int totalFrames;
        private readonly int width, height;
        private int age = 0;
        private int maxDistance = (int)(32 * Game1.Scale);
        private int xOffset, yOffset = 0;
        private int lifespan = 480;

        public FlameProjectile(Texture2D texture, Vector2 location, Direction dir, IEntity shooter)
        {
            Shooter = shooter;
            width = height = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            this.texture = texture;
            source = new Rectangle(191, 185, width, height);
            currentFrame = 0;
            repeatedFrames = 8;
            totalFrames = 2;
            switch (dir)
            {
                case Direction.n:
                    yOffset = -1;
                    break;
                case Direction.s:
                    yOffset = 1;
                    break;
                case Direction.e:
                    xOffset = 1;
                    break;
                case Direction.w:
                    xOffset = -1;
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Location, source, Color.White, 0, new Vector2(0, 0), s, 0);
        }

        public bool IsAlive()
        {
            return age <= lifespan;
        }

        public void RegisterHit()
        {
            // no-op
        }
        public void Move()
        {
            Location = new Rectangle((int)Location.X + xOffset, (int)Location.Y + yOffset, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
        }

        public void Update()
        {
            age++;
            if(age < maxDistance) Move();
            if (currentFrame / repeatedFrames == 0)
            {
                s = SpriteEffects.FlipHorizontally;
            }
            else
            {
                s = SpriteEffects.None;
            }
            currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);
        }
    }
}
