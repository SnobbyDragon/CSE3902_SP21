using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Stuti Shah
namespace sprint0
{
    public class Stalfos : IEnemy
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;
        private int totalFrames;
        private int currentFrame;
        private int repeatedFrames;
        private readonly int width = 16, height = 16;

        //direction that stalfos is moving/'facing'
        Direction dir;
        private List<SpriteEffects> spriteEffects;

        public Stalfos(Texture2D texture, Vector2 location)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, width, height);
            Texture = texture;
            totalFrames = 2;
            currentFrame = 0;
            repeatedFrames = 7;

            //adds sprite
            source = new Rectangle(1, 59, width, height);

            //initializes direction
            dir = Direction.n;

            //Creates sprite effect list
            spriteEffects = new List<SpriteEffects> {
                SpriteEffects.None,
                SpriteEffects.FlipHorizontally
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, source, Color.White, 0, new Vector2(0, 0), spriteEffects[currentFrame / repeatedFrames], 0);
        }

        public void Update()
        {
            currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);

            //switch stalfos direction if needed; moving in rectangle
            //todo: move in 'random' directions, avoid obstacles
            switch (dir)
            {
                case Direction.s: //move down; if y limit reached, turn right
                    if (Location.Y < 300)
                    {
                        Location = new Rectangle(Location.X, Location.Y + 1, Location.Width, Location.Height);
                    }
                    else
                    {
                        dir = Direction.e;
                    }
                    break;
                case Direction.e: //move right; if x limit reached, turn up
                    if (Location.X < 400)
                    {
                        Location = new Rectangle(Location.X + 1, Location.Y, Location.Width, Location.Height);
                    }
                    else
                    {
                        dir = Direction.n;
                    }
                    break;
                case Direction.n: //move up; if y limit reached, turn left
                    if (Location.Y > 250)
                    {
                        Location = new Rectangle(Location.X, Location.Y - 1, Location.Width, Location.Height);
                    }
                    else
                    {
                        dir = Direction.w;
                    }
                    break;
                case Direction.w: //move left; if y limit reached, turn down
                    if (Location.X > 200)
                    {
                        Location = new Rectangle(Location.X - 1, Location.Y, Location.Width, Location.Height);
                    }
                    else
                    {
                        dir = Direction.s;
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid direction! Stalfos movement failed.");
            }
        }

        public Collision GetCollision(ISprite other)
        {   //TODO get collision
            return Collision.None;
        }
    }
}
