
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    /*
     * Last updated: 2/21/21 by urick.9
     */
    public class Boomerang : ISprite
    {
        
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int xOffset = 290, yOffset = 11, sizeX = 7, sizeY = 15;
        private readonly List<Rectangle> sources;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;
        private readonly int xa;
        private readonly int ya = 0;
        private readonly int maxDistance = 25;
        private int age = 0;
        Vector2 moveVector = new Vector2();
        SpriteEffects h = SpriteEffects.FlipHorizontally;
        SpriteEffects v = SpriteEffects.FlipVertically;
        public Boomerang(Texture2D texture, Vector2 location, Direction dir)
        {
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
            Location = location;
            Texture = texture;
            sources = new List<Rectangle>
            {
                new Rectangle(xOffset, yOffset, sizeX, sizeY),
                new Rectangle(xOffset + sizeX + 1, yOffset, sizeX, sizeY),
                new Rectangle(xOffset + sizeX*2 + 2, yOffset, sizeX, sizeY)
            };
            currFrame = 0;
            totalFrames = 8;
            repeatedFrames = 4;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int tempFrame = currFrame / repeatedFrames;
            if (tempFrame == 3)
            {
                spriteBatch.Draw(Texture, Location, sources[1], Color.White, 0, new Vector2(0, 0), new Vector2(1, 1), h, 0);
            }
            else if (tempFrame == 4)
            {
                spriteBatch.Draw(Texture, Location, sources[0], Color.White, 0, new Vector2(0, 0), new Vector2(1, 1), h, 0);
            }
            else if (tempFrame == 5)
            {
                spriteBatch.Draw(Texture, Location, sources[1], Color.White, 0, new Vector2(0, 0), new Vector2(1, 1), v | h, 0);
            }
            else if (tempFrame == 6)
            {
                spriteBatch.Draw(Texture, Location, sources[2], Color.White, 0, new Vector2(0, 0), new Vector2(1, 1), v, 0);
            }
            else if (tempFrame == 7)
            {
                spriteBatch.Draw(Texture, Location, sources[1], Color.White, 0, new Vector2(0, 0), new Vector2(1, 1), v, 0);
            }
            else
            {
                spriteBatch.Draw(Texture, Location, sources[currFrame / repeatedFrames], Color.White);
            }
        }


        public void Move() {
            if (age < maxDistance * 2)
            {
                Location += moveVector;
            }
            
        }

        public void Update()
        {
            if (age > maxDistance)
            {
                moveVector = Location - Link.position;
                moveVector.Normalize();
                moveVector = 6 * moveVector;
            }
            Move();
            // animates all the time for now
            currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
            age++;
        }
    }
}