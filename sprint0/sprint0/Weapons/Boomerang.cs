
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    /*
     * Last updated: 3/14/21 by he.1528
     */
    public class Boomerang : IProjectile
    {
        public IEntity Shooter { get; }
        public Rectangle Location { get; set; }
        public int Damage { get => 1; }
        public bool CanBeCaught { get => age > maxDistance || hit; }
        public Texture2D Texture { get; set; }
        private readonly int xOffset = 290, yOffset = 11, width = 8, height = 16;
        private readonly List<Rectangle> sources;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;
        private readonly int xa;
        private readonly int ya = 0;
        private readonly int maxDistance = 25;
        private int age = 0;
        private readonly SpriteEffects h = SpriteEffects.FlipHorizontally, v = SpriteEffects.FlipVertically;
        private Vector2 moveVector;
        private bool alive;
        private bool hit = false;
        public Boomerang(Texture2D texture, Vector2 location, Direction dir, IEntity shooter)
        {
            Shooter = shooter;
            alive = true;
            switch (dir)
            {
                case Direction.n:
                    ya = -6;
                    break;
                case Direction.s:
                    ya = 6;
                    break;
                case Direction.e:
                    xa = 6;
                    break;
                case Direction.w:
                    xa = -6;
                    break;
            }
            moveVector = new Vector2(xa, ya);
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            sources = new List<Rectangle>
            {
                new Rectangle(xOffset, yOffset, width, height),
                new Rectangle(xOffset + width + 1, yOffset, width, height),
                new Rectangle(xOffset + width*2 + 2, yOffset, width, height)
            };
            currFrame = 0;
            totalFrames = 8;
            repeatedFrames = 4;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (alive)
            {
                int tempFrame = currFrame / repeatedFrames;
                if (tempFrame == 3)
                {
                    spriteBatch.Draw(Texture, Location, sources[1], Color.White, 0, new Vector2(0, 0), h, 0);
                }
                else if (tempFrame == 4)
                {
                    spriteBatch.Draw(Texture, Location, sources[0], Color.White, 0, new Vector2(0, 0), h, 0);
                }
                else if (tempFrame == 5)
                {
                    spriteBatch.Draw(Texture, Location, sources[1], Color.White, 0, new Vector2(0, 0), v | h, 0);
                }
                else if (tempFrame == 6)
                {
                    spriteBatch.Draw(Texture, Location, sources[2], Color.White, 0, new Vector2(0, 0), v, 0);
                }
                else if (tempFrame == 7)
                {
                    spriteBatch.Draw(Texture, Location, sources[1], Color.White, 0, new Vector2(0, 0), v, 0);
                }
                else
                {
                    spriteBatch.Draw(Texture, Location, sources[currFrame / repeatedFrames], Color.White);
                }
            }
        }

        public bool IsAlive() => alive;
        public void Perish() => alive = false;
        public void Move()
        {
            //The plus six is required so the boomerang reaches link.
            if (age < (maxDistance * 2) + 6)
            {
                Rectangle loc = Location;
                loc.Offset(moveVector);
                Location = loc;
            }
            else
            {
                alive = false;
            }

        }

        public void Update()
        {
            if (alive)
            {
                if (age > maxDistance || hit)
                {
                    moveVector = Link.position - Location.Location.ToVector2();
                    moveVector.Normalize();
                    moveVector = 6 * moveVector;
                }
                Move();
                // animates all the time for now
                currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
                age++;
            }
        }
        public void RegisterHit()
        {
            hit = true;
        }
    }
}