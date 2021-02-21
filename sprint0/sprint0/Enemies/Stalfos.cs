using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Stuti Shah
namespace sprint0
{
    public class Stalfos : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;
        private int totalFrames;
        private int currentFrame;
        private int repeatedFrames;

        //direction that stalfos is moving/'facing'
        enum Direction { Up, Down, Left, Right }
        Direction dir;
        private List<SpriteEffects> spriteEffects;

        public Stalfos(Texture2D texture, Vector2 location)
        {
            Location = location;
            Texture = texture;
            totalFrames = 2;
            currentFrame = 0;
            repeatedFrames = 7;

            //adds sprite
            source = new Rectangle(1, 59, 16, 16);

            //initializes direction
            dir = Direction.Up;

            //Creates sprite effect list
            spriteEffects = new List<SpriteEffects> {
                SpriteEffects.None,
                SpriteEffects.FlipHorizontally
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, source, Color.White, 0, new Vector2(0, 0), new Vector2(1, 1), spriteEffects[currentFrame / repeatedFrames], 0);
        }

        public void Update()
        {
            currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);

            //switch stalfos direction if needed; moving in rectangle
            //todo: move in 'random' directions, avoid obstacles
            switch (dir)
            {
                case Direction.Down: //move down; if y limit reached, turn right
                    if (Location.Y < 300)
                    {
                        Location = new Vector2(Location.X, Location.Y + 1);
                    }
                    else
                    {
                        dir = Direction.Right;
                    }
                    break;
                case Direction.Right: //move right; if x limit reached, turn up
                    if (Location.X < 400)
                    {
                        Location = new Vector2(Location.X + 1, Location.Y);
                    }
                    else
                    {
                        dir = Direction.Up;
                    }
                    break;
                case Direction.Up: //move up; if y limit reached, turn left
                    if (Location.Y > 250)
                    {
                        Location = new Vector2(Location.X, Location.Y - 1);
                    }
                    else
                    {
                        dir = Direction.Left;
                    }
                    break;
                case Direction.Left: //move left; if y limit reached, turn down
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
