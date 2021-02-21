﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
namespace sprint0
{
    public class Wallmaster : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int xOffset = 393, yOffset = 11, size = 16;
        private List<Rectangle> sources;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;
        private SpriteEffects s; // could be flipped horizontally, vertically, or both
        enum Direction { n, s, e, w } // TODO make a global public class bc a lot of sprites use this
        private Direction direction; // wallmaster only moves n s e w (cannot move diagonal)
        private int moveCounter, dirChangeDelay;
        private Random rand;

        public Wallmaster(Texture2D texture, Vector2 location)
        {
            Location = location;
            Texture = texture;
            sources = new List<Rectangle>
            {
                new Rectangle(xOffset, yOffset, size, size),
                new Rectangle(xOffset + size + 1, yOffset, size, size)
            };
            currFrame = 0;
            totalFrames = 2;
            repeatedFrames = 8;

            rand = new Random();

            if (Location.X <= Game1.Width / 2) // if coming from the left, then faces right
            {
                s = SpriteEffects.None;
            }
            else // if coming from the right, then faces left
            {
                s = SpriteEffects.FlipHorizontally;
            }
            if (Location.Y < Game1.MapHeight / 2 + Game1.HUDHeight) // if coming from above, faces down
            {
                s |= SpriteEffects.FlipVertically;
            } // otherwise (coming from below), faces up

            ArbitraryDirection();
        }

        public void ArbitraryDirection()
        {
            // changes to an arbitrary direction; if in wall, go into room, else random direction
            // TODO 32 is a magic number for room border / wall width... make static variable in Game1?
            moveCounter = 0;
            if (Location.X <= 32 * Game1.Scale) // in the left wall, move right
            {
                direction = Direction.e;
                Console.Write(Location.X);
            }
            else if (Location.X >= (Game1.Width - 32) * Game1.Scale) // in the right wall, move left
            {
                direction = Direction.w;
            }
            else if (Location.Y <= (Game1.HUDHeight + 32) * Game1.Scale) // in the top wall, move down
            {
                direction = Direction.s;
            }
            else if (Location.Y >= (Game1.HUDHeight + Game1.MapHeight - 32) * Game1.Scale) // in the bottom wall, move up
            {
                direction = Direction.n;
            }
            else // not in a wall, move in random direction
            {
                dirChangeDelay = rand.Next(10, 50);
                switch (rand.Next(0, 4)) // 0 <= rand integer < 4
                {
                    case 0:
                        direction = Direction.n;
                        break;
                    case 1:
                        direction = Direction.s;
                        break;
                    case 2:
                        direction = Direction.e;
                        break;
                    case 3:
                        direction = Direction.w;
                        break;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, sources[currFrame / repeatedFrames], Color.White, 0, new Vector2(0, 0), 1, s, 0);
        }

        public void Update()
        {
            // animates all the time for now
            currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
            if (moveCounter == dirChangeDelay) //TODO may still go into the wall... not sure if that's okay?
            {
                ArbitraryDirection();
            }
            moveCounter++;

            switch (direction)
            {
                case Direction.n:
                    Location += new Vector2(0, -1);
                    break;
                case Direction.s:
                    Location += new Vector2(0, 1);
                    break;
                case Direction.e:
                    Location += new Vector2(1, 0);
                    break;
                case Direction.w:
                    Location += new Vector2(-1, 0);
                    break;
            }
        }
    }
}
