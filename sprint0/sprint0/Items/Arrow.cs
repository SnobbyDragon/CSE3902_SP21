using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace sprint0
{
    public class Arrow : IProjectile
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        public Vector2 origin;
        private float rotation;
        private readonly float rotate180;
        private readonly List<Rectangle> sources;
        private readonly int xOffset = 154, yOffset = 0, width = 5, height = 16;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;
        private readonly Direction dir;
        //xa is x adjust, ya is y adjust
        private float xa, ya;
        //Lifespan is the number of updates before it dies. 
        //For now, it just stops rendering
        private readonly int lifespan;
        //Age is the current number of updates
        private int age;
        public Arrow(Texture2D texture, Vector2 location, Direction dir, int lifespan)
        {
            /*
             * Adjust the source location based on the direction 
             */
            int sourceAdjustX = 0;
            int sourceAdjustY = 0;
            switch (dir)
            {
                case Direction.n:
                    sourceAdjustX += 2;
                    break;
                case Direction.s:
                    sourceAdjustX += 2;
                    sourceAdjustY += 3;
                    break;
                case Direction.e:
                    sourceAdjustY += 10;
                    break;
                case Direction.w:
                    sourceAdjustY += 10;
                    break;
            }
            Vector2 loc = location + new Vector2(sourceAdjustX, sourceAdjustY);
            Location = new Rectangle((int)loc.X, (int)loc.Y, width, height);
            Texture = texture;
            this.dir = dir;
            this.lifespan = lifespan;
            sources = new List<Rectangle>
            {
                new Rectangle(xOffset, yOffset, width, height),
                new Rectangle(xOffset, yOffset+height+1, width, height)
            };
            currFrame = 0;
            totalFrames = 2;
            repeatedFrames = 8;
            origin = new Vector2(width / 2, height / 2);
            rotation = 0;
            rotate180 = (float)Math.PI;
        }

        private bool Alive()
        {
            if (age < lifespan || lifespan < 0)
            {
                age++;
                return true;
            }
            return false;
        }

        private void Move()
        {
            Rectangle loc = Location;
            loc.Offset(xa, ya);
            Location = loc;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Alive())
            {
                spriteBatch.Draw(Texture, Location, sources[currFrame / repeatedFrames], Color.White, rotation, origin, SpriteEffects.None, 0);
            }
        }

        public void Update()
        {
            if (Alive())
            {

                switch (dir)
                {
                    case Direction.n:
                        ya = -5;
                        // 0 degrees
                        rotation = 0;
                        break;
                    case Direction.s:
                        ya = 5;
                        // 180 degrees
                        rotation = rotate180;
                        break;
                    case Direction.e:
                        xa = 5;
                        // 90 degrees
                        rotation = rotate180 / 2.0f;
                        break;
                    case Direction.w:
                        xa = -5;
                        // 270 degrees
                        rotation = 1.5f * rotate180;
                        break;
                }
                Move();

                currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
            }
            currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
        }

        public Collision GetCollision(ISprite other)
        {   //TODO get collision
            return Collision.None;
        }
    }
}
