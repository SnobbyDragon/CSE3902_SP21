using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    class FlameProjectile : IProjectile
    {
        public IEntity Shooter { get; }

        public int Damage { get; set; }

        public Rectangle Location { get; set; }

        private readonly Texture2D texture;
        private readonly Rectangle source;
        private SpriteEffects s = SpriteEffects.FlipHorizontally;
        private int currentFrame;
        private readonly int repeatedFrames, totalFrames;
        private readonly int width, height;
        private int age = 0;
        private readonly int maxDistance = (int)(32 * Game1.Scale);
        private readonly int lifespan = 480;
        private readonly Direction direction;

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
            direction = dir;
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
        }

        public void Move()
        {
            Rectangle loc = Location;
            loc.Offset(direction.ToVector2());
            Location = loc;
        }

        public void Update()
        {
            age++;
            if (age < maxDistance) Move();
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
