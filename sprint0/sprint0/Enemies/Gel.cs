using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson

namespace sprint0
{
    public class Gel : IEnemy
    {

        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private int totalFrames;
        private int currentFrame;
        private int repeatedFrames = 10;
        private string color;
        private Dictionary<string, List<Rectangle>> colorMap;
        private readonly int width = 8, height = 16;
        private int health;
        private Direction direction = Direction.w;
        private int directionChangeCounter;
        private readonly Game1 game;

        public Gel(Texture2D texture, Vector2 location, Game1 game, string gelColor)
        {
            this.game = game;
            health = 10;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            totalFrames = 2;
            currentFrame = 0;
            color = gelColor;
            directionChangeCounter = 0;

            colorMap = new Dictionary<string, List<Rectangle>>
            {
                { "teal", GetFrames(1,11,2)},
                { "blue", GetFrames(19, 11, 2)},
                { "green", GetFrames(37, 11, 2)},
                { "blkgold", GetFrames(55, 11, 2)},
                { "lime", GetFrames(1, 28, 2)},
                { "brown", GetFrames(19, 28, 2)},
                { "grey", GetFrames(37, 28, 2)},
                { "blkwhite", GetFrames(55, 28, 2)},
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
            spriteBatch.Draw(Texture, Location, colorMap[color][currentFrame / repeatedFrames], Color.White);
        }

        public void Update()
        {
            CheckHealth();
            currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);

            if (directionChangeCounter== 100) { ChangeDirection(); directionChangeCounter = 0; }

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
                Location = new Rectangle(Location.X, Location.Y + 1, Location.Width, Location.Height);
                
            }
            else
            {   //direction == Direction.n
                //moves sprite up
                Location = new Rectangle(Location.X, Location.Y - 1, Location.Width, Location.Height);
                
            }

            directionChangeCounter++;

        }

        public void ChangeDirection()
        {
            Random random = new Random();
            direction = (Direction)random.Next(0, 4);
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
