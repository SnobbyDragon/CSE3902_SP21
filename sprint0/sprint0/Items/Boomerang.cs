
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    /*
     * Last updated: 2/22/21 by urick.9 and li.10011
     */
    public class Boomerang : ISprite
    {
        
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int xOffset = 290, yOffset = 11, sizeX = 8, sizeY = 16;
        private readonly List<Rectangle> sources;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;
        private readonly int xa;
        private readonly int ya = 0;
        private readonly int maxDistance = 25;
        private int age = 0;
        private Vector2 moveVector;
        private bool alive;
        private readonly int lifespan;
        public Boomerang(Texture2D texture, Vector2 location, Direction dir, int lfspn)
        {
            lifespan = lfspn;

            alive = true;
            if (lifespan >= 0)
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
            totalFrames = 3;
            repeatedFrames = 8;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (alive || lifespan < 0)
            {
                spriteBatch.Draw(Texture, Location, sources[currFrame / repeatedFrames], Color.White);
            }
        }


        public void Move()
        {
            //The plus six is required so the boomerang reaches link.
            if (age < (maxDistance * 2) + 6)
            {
                Location += moveVector;
            }else
            {
                alive = false;    
            }
            
        }


        public void Update()
        {
            if (alive)
            {
                if (age > maxDistance)
                {
                    moveVector = Link.position - Location;
                    moveVector.Normalize();
                    moveVector = 6 * moveVector;
                }
                Move();
                // animates all the time for now
                currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
                age++;
            }
            else if (lifespan  < 0 )
                currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
            }
        }
    }