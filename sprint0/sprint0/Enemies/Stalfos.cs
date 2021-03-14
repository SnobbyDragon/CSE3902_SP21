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
        private readonly int totalFrames;
        private int moveCounter;
        private int currentFrame;
        private readonly int repeatedFrames;
        private readonly int width = 16, height = 16;
        private readonly Game1 game;
        //direction that stalfos is moving/'facing'
        private Direction direction;
        private readonly List<SpriteEffects> spriteEffects;
        private int health;
        private readonly Random rand;
        private int dirChangeDelay;
        public Stalfos(Texture2D texture, Vector2 location, Game1 game)
        {
            dirChangeDelay = 20;
            rand = new Random();
            this.game = game;
            health = 100;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            totalFrames = 2;
            currentFrame = 0;
            repeatedFrames = 7;

            //adds sprite
            source = new Rectangle(1, 59, width, height);

            //initializes direction
            direction = Direction.n;

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
            moveCounter++;
            CheckHealth();
            currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);
            if (moveCounter == dirChangeDelay)
            {
                ArbitraryDirection();
            }
            //switch stalfos direction if needed; moving in rectangle
            //todo: move in 'random' directions, avoid obstacles
            switch (direction)
            {

                case Direction.s: //move down; if y limit reached, turn right
                    if (Location.Y < 300)
                    {
                        Location = new Rectangle(Location.X, Location.Y + 1, Location.Width, Location.Height);
                    }

                    break;
                case Direction.e: //move right; if x limit reached, turn up
                    if (Location.X < 400)
                    {
                        Location = new Rectangle(Location.X + 1, Location.Y, Location.Width, Location.Height);
                    }

                    break;
                case Direction.n: //move up; if y limit reached, turn left
                    if (Location.Y > 250)
                    {
                        Location = new Rectangle(Location.X, Location.Y - 1, Location.Width, Location.Height);
                    }
                    break;
                case Direction.w: //move left; if y limit reached, turn down
                    if (Location.X > 200)
                    {
                        Location = new Rectangle(Location.X - 1, Location.Y, Location.Width, Location.Height);
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid direction! Stalfos movement failed.");

            }
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
        public void ChangeDirection()
        {
            ArbitraryDirection();
        }

        private void CheckHealth()
        {
            if (health < 0) Perish();
        }
        public void TakeDamage(int damage)
        {
            health -= damage;
        }

        public void Perish()
        {
            game.RemoveEnemy(this);
        }
    }
}
