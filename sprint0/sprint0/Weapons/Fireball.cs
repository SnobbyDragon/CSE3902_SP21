using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
namespace sprint0
{
    public class Fireball : IProjectile
    {
        public IEntity Shooter { get; }
        public Rectangle Location { get; set; }
        private Vector2 preciseLocation;
        public Texture2D Texture { get; set; }
        public int Damage { get => 1; }

        private bool isDead;
        private readonly int width = 8, height = 10;
        private readonly List<Rectangle> sources;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames, speed = 3; // fast fireballs
        private readonly Vector2 direction; // direction fireball travels

        public Fireball(Texture2D texture, Vector2 location, Vector2 direction, IEntity shooter)
        {
            Shooter = shooter;
            Texture = texture;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            preciseLocation = location;
            this.direction = direction;

            currFrame = 0;
            totalFrames = 4;
            repeatedFrames = 2;
            sources = GetFrames(231, 62); // in enemies sprite sheet; all fireballs are the same

            isDead = false;
        }

        private List<Rectangle> GetFrames(int xOffset, int yOffset)
        {
            List<Rectangle> sources = new List<Rectangle>();
            for (int frame = 0; frame < totalFrames; frame++)
            {
                sources.Add(new Rectangle(xOffset + frame * (width + 1), yOffset, width, height));
            };
            return sources;
        }

        public bool IsAlive() => !isDead;
        public void Perish() => isDead = true;

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!isDead)
                spriteBatch.Draw(Texture, Location, sources[currFrame / repeatedFrames], Color.White);
        }

        public void Update()
        {
            if (!isDead)
            {   // alive and traveling
                currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
                preciseLocation += speed * direction;
                Location = new Rectangle((int)preciseLocation.X, (int)preciseLocation.Y, Location.Width, Location.Height);

                if (HitWall())
                {
                    isDead = true;
                }
            }
        }

        // checks if hit wall (left || right || up || down); TODO account for size of fireball?
        private bool HitWall()
        {
            return
                Location.X <= 0 || // left
                Location.X >= Game1.Width * Game1.Scale || // right
                Location.Y <= Game1.HUDHeight * Game1.Scale || // up
                Location.Y >= (Game1.HUDHeight + Game1.MapHeight) * Game1.Scale; // down
        }

        public bool HasRecentlyHit(IEnemy enemy)
        {
            //no-op
            return false;
        }
        public void RegisterHit(IEnemy enemy)
        {
            //no-op required
        }
    }

}
