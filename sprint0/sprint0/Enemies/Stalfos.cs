using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Stalfos : ISprite
    {
        SpriteEffects s = SpriteEffects.FlipHorizontally;
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;
        private int currFrame;
        enum Direction { Up, Down, Left, Right }
        Direction dir;

        public Stalfos(Texture2D texture, Vector2 location)
        {
            Location = location;
            Texture = texture;
            source = new Rectangle(1, 59, 16, 16);
            currFrame = 0;
            dir = Direction.Up;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, source, Color.White, 0, new Vector2(0, 0), new Vector2(1, 1), s, 0);
        }

        public void Update()
        {
            if (currFrame % 14 < 7)
            {
                s = SpriteEffects.FlipHorizontally;
            }
            else
            {
                s = SpriteEffects.None;
            }
            currFrame++;

            //switch stalfos direction if needed; moving in rectangle
            //todo: move in 'random' directions, avoid obstacles
            switch (dir)
            {
                case Direction.Down:
                    if (Location.Y < 300)
                    {
                        Location = new Vector2(Location.X, Location.Y + 1);
                    }
                    else
                    {
                        dir = Direction.Right;
                    }
                    break;
                case Direction.Right:
                    if (Location.X < 400)
                    {
                        Location = new Vector2(Location.X + 1, Location.Y);
                    }
                    else
                    {
                        dir = Direction.Up;
                    }
                    break;
                case Direction.Up:
                    if (Location.Y > 200)
                    {
                        Location = new Vector2(Location.X, Location.Y - 1);
                    }
                    else
                    {
                        dir = Direction.Left;
                    }
                    break;
                case Direction.Left:
                    if (Location.X > 200)
                    {
                        Location = new Vector2(Location.X - 1, Location.Y);
                    }
                    else
                    {
                        dir = Direction.Down;
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid direction! Stalfos movement failed.");
            }

        }
    }
}
