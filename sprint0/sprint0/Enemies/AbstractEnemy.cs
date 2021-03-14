using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Enemy : IEnemy
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        protected int currentFrame;
        protected string color;
        protected int totalFrames;
        protected int repeatedFrames;
        private Dictionary<string, List<Rectangle>> colorMap;
        private readonly SpriteEffects s = SpriteEffects.FlipHorizontally;
        protected Direction direction;
        protected int width, height;
        protected int health;
        protected int moveCounter, dirChangeDelay;
        protected readonly Random rand;
        protected readonly Game1 game;
        

        public Enemy(Texture2D texture, Vector2 location, Game1 game)
        {
            rand = new Random();
            this.game = game;
            health = 50;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            colorMap = new Dictionary<string, List<Rectangle>>
            {
                { "red", GetFrames(222, 11, 4)},
                { "blue", GetFrames(222, 28, 4)}
            };
        }

        private List<Rectangle> GetFrames(int xPos, int yPos, int numFrames)
        {
            List<Rectangle> sources = new List<Rectangle>();
            for (int i = 0; i < numFrames; i++)
            {
                sources.Add(new Rectangle(xPos, yPos, width, height));
                xPos += width + 1;
            }
            return sources;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (direction == Direction.w)
            {
                spriteBatch.Draw(Texture, Location, colorMap[color][(currentFrame / repeatedFrames) % 2 + 2], Color.White, 0, new Vector2(0, 0), s, 0);
            }
            else if (direction == Direction.e)
            {
                spriteBatch.Draw(Texture, Location, colorMap[color][(currentFrame / repeatedFrames) % 2 + 2], Color.White);
            }
            else if (direction == Direction.s)
            {
                spriteBatch.Draw(Texture, Location, colorMap[color][0], Color.White);
            }
            else
            {
                spriteBatch.Draw(Texture, Location, colorMap[color][1], Color.White);
            }

        }

        public void Update()
        {
            moveCounter++;
            if (moveCounter == dirChangeDelay)
            {
                ArbitraryDirection(30,50);
                
            }
            CheckHealth();

            currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);
            if (direction == Direction.w)
            {
                //moves sprite left
                Location = new Rectangle(Location.X - 1, Location.Y, Location.Width, Location.Height);
            }
            else if (direction == Direction.e)
            {

                //moves sprite right
                Location = new Rectangle(Location.X + 1, Location.Y, Location.Width, Location.Height);

            }
            else if (direction == Direction.s)
            {
                //moves sprite down
                Location = new Rectangle(Location.X, Location.Y + 1, Location.Width, Location.Height); ;

            }
            else
            {
                //moves sprite up
                Location = new Rectangle(Location.X, Location.Y - 1, Location.Width, Location.Height); ;

            }
        }
        protected void ArbitraryDirection(int low, int high)
        {
            // changes to an arbitrary direction; if in wall, go into room, else random direction
            // TODO 32 is a magic number for room border / wall width... make static variable in Game1?
            moveCounter = 0;

            
                direction = (Direction)rand.Next(0, 4);
            
            dirChangeDelay = rand.Next(low, high); //TODO may still go into the wall... not sure if that's okay?
        }

        public void ChangeDirection()
        {
            ArbitraryDirection(30,50);
        }

        public void CheckHealth()
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