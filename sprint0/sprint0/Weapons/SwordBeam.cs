using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace sprint0
{
    class SwordBeam : IProjectile
    {
        public IEntity Shooter { get; }
        public Rectangle Location { get; set; }
        private readonly Texture2D texture;
        private readonly List<Rectangle> sources;
        private readonly Direction dir;
        private int xa, ya = 0;
        private int width, height;
        private int lifespan = 15;
        private int currFrame, totalFrames;
        private readonly int repeatedFrames;
        private int age = 0;

        private readonly List<Rectangle> explodeSources;
        private bool hit = false;

        public SwordBeam(Texture2D texture, Vector2 location, Direction dir, int lifespan, IEntity source)
        {
            Shooter = source;
            this.dir = dir;
            this.texture = texture;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            currFrame = 0;
            totalFrames = 2;
            repeatedFrames = 8;
            switch (dir)
            {
                case Direction.n:
                    ya = (int)(-2 * Game1.Scale);
                    break;
                case Direction.s:
                    ya = (int)(2 * Game1.Scale);
                    break;
                case Direction.e:
                    xa = (int)(2 * Game1.Scale);
                    break;
                case Direction.w:
                    xa = (int)(-2 * Game1.Scale);
                    break;
            }
            if (dir == Direction.n || dir == Direction.s)
            {
                width = 7;
                height = 16;
                sources = new List<Rectangle>
                {
                    new Rectangle(1, 154, width, height),
                    new Rectangle(36, 154, width, height),
                    new Rectangle(71, 154, width, height),
                    new Rectangle(106, 154, width, height)
                };
            }
            else
            {
                width = 16;
                height = 7;
                sources = new List<Rectangle>
                {
                    new Rectangle(10, 159, width, height),
                    new Rectangle(45, 159, width, height),
                    new Rectangle(80, 159, width, height),
                    new Rectangle(115, 159, width, height)
                };
            }
            explodeSources = new List<Rectangle>
            {
                new Rectangle(27, 157, 8,10),
                new Rectangle(62, 157, 8,10),
                new Rectangle(97, 157, 8,10)
            };
        }

        public bool IsAlive()
        {
            return age < lifespan || lifespan < 0;
        }

        public void Perish() => Break();

        private void Move()
        {
            if (!hit) Location = new Rectangle(Location.X + xa, Location.Y + ya, Location.Width, Location.Height);
            else
            {
                xa += 2;
                ya += 2;
            }
        }

        private void Break()
        {
            hit = true;
            width = 8;
            height = 10;
            totalFrames = 3;
            xa = (int)(width * Game1.Scale);  // once broken, the beam no longer moves, so repurpose
            ya = (int)(height * Game1.Scale); // xa and ya to move each component of the explosion
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsAlive())
            {
                if (!hit)
                {
                    Rectangle destination = new Rectangle((int)Location.X, (int)Location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
                    switch (dir)
                    {
                        case Direction.n:
                            spriteBatch.Draw(texture, destination, sources[currFrame / repeatedFrames], Color.White);
                            break;
                        case Direction.s:
                            spriteBatch.Draw(texture, destination, sources[currFrame / repeatedFrames], Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipVertically, 0);
                            break;
                        case Direction.e:
                            spriteBatch.Draw(texture, destination, sources[currFrame / repeatedFrames], Color.White);
                            break;
                        case Direction.w:
                            spriteBatch.Draw(texture, destination, sources[currFrame / repeatedFrames], Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);
                            break;
                    }
                }
                else
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
        }

        public void Update()
        {
            if(hit) age++; // sword beams go until they hit something
            if (IsAlive())
            {
                Move();
                currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
            }
        }
    }
}
