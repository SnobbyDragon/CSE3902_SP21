using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
namespace sprint0
{
    public class Wallmaster : IEnemy
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int xOffset = 393, yOffset = 11, width = 16, height = 16;
        private List<Rectangle> sources;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;
        private SpriteEffects s; // could be flipped horizontally, vertically, or both
        private Direction direction; // wallmaster only moves n s e w (cannot move diagonal)
        private int moveCounter, dirChangeDelay;
        private Random rand;

        public Wallmaster(Texture2D texture, Vector2 location)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            sources = new List<Rectangle>
            {
                new Rectangle(xOffset, yOffset, width, height),
                new Rectangle(xOffset + width + 1, yOffset, width, height)
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

        private void ArbitraryDirection()
        {
            // changes to an arbitrary direction; if in wall, go into room, else random direction
            // TODO 32 is a magic number for room border / wall width... make static variable in Game1?
            moveCounter = 0;
            if (Location.X <= 32 * Game1.Scale) // in the left wall, move right
            {
                direction = Direction.e;
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
                direction = (Direction)rand.Next(0, 4);
            }
            dirChangeDelay = rand.Next(10, 50); //TODO may still go into the wall... not sure if that's okay?
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, sources[currFrame / repeatedFrames], Color.White, 0, new Vector2(0, 0), s, 0);
        }

        public void Update()
        {
            // animates all the time for now
            currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
            if (moveCounter == dirChangeDelay)
            {
                ArbitraryDirection();
            }
            moveCounter++;

            switch (direction)
            {
                case Direction.n:
                    Location = new Rectangle(Location.X, Location.Y - 1, Location.Width, Location.Height);
                    break;
                case Direction.s:
                    Location = new Rectangle(Location.X, Location.Y + 1, Location.Width, Location.Height);
                    break;
                case Direction.e:
                    Location = new Rectangle(Location.X + 1, Location.Y, Location.Width, Location.Height);
                    break;
                case Direction.w:
                    Location = new Rectangle(Location.X - 1, Location.Y, Location.Width, Location.Height);
                    break;
            }
        }

        public void ChangeDirection()
        {
            ArbitraryDirection();
        }
    }
}
