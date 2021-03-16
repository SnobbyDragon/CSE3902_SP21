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
        private readonly int width = 8, height = 10;
        private readonly List<Rectangle> sources;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames, speed = 3;
        private readonly Vector2 direction;
        private bool hit = false;

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
            sources = SpritesheetHelper.GetFramesH(231, 62, width, height, totalFrames);
        }

        public bool IsAlive() => !hit;

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!hit)
                spriteBatch.Draw(Texture, Location, sources[currFrame / repeatedFrames], Color.White);

        }

        public void Update()
        {
            if (!hit)
            {
                currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
                preciseLocation += speed * direction;
                Location = new Rectangle((int)preciseLocation.X, (int)preciseLocation.Y, Location.Width, Location.Height);
            }
        }

        public void RegisterHit()
        {
            hit = true;
        }
    }

}
