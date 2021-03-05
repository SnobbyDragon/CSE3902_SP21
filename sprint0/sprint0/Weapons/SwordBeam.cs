using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace sprint0
{
    class SwordBeam : ISprite
    {
        public Vector2 Location { get; set; }
        private readonly Texture2D texture;
        private readonly List<Rectangle> sources;
        private readonly Direction dir;
        private int xa, ya = 0;
        private int xSize, ySize;
        private readonly int lifespan = 120;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;
        private int age = 0;

        public SwordBeam(Texture2D texture, Vector2 location, Direction dir, int lifespan)
        {
            this.dir = dir;
            this.texture = texture;
            Location = location;
            currFrame = 0;
            totalFrames = 2;
            repeatedFrames = 8;
            switch (dir)
            {
                case Direction.n:
                    ya = -2;
                    break;
                case Direction.s:
                    ya = 2;
                    break;
                case Direction.e:
                    xa = 2;
                    break;
                case Direction.w:
                    xa = -2;
                    break;
            }
            if (dir == Direction.n || dir == Direction.s)
            {
                xSize = 7;
                ySize = 16;
                sources = new List<Rectangle>
                {
                    new Rectangle(1, 154, xSize, ySize),
                    new Rectangle(36, 154, xSize, ySize),
                    new Rectangle(71, 154, xSize, ySize),
                    new Rectangle(106, 154, xSize, ySize)
                };
            }
            else
            {
                xSize = 16;
                ySize = 7;
                sources = new List<Rectangle>
                {
                    new Rectangle(10, 159, xSize, ySize),
                    new Rectangle(45, 159, xSize, ySize),
                    new Rectangle(80, 159, xSize, ySize),
                    new Rectangle(115, 159, xSize, ySize)
                };
            }
            
        }

        private Boolean Alive()
        {
            return age < lifespan || lifespan < 0;
        }

        private void Move()
        {
            Location = new Vector2(Location.X + xa, Location.Y + ya);
        }

        private void Break()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Alive())
            {
                Rectangle destination = new Rectangle((int)Location.X, (int)Location.Y, xSize, ySize);
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
        }

        public void Update()
        {
            age++;
            if (Alive())
            {
                Move();
                currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
            }
            else
            {
                Break();
            }
        }
    }
}
