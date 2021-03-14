﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson

namespace sprint0
{
    public class Snake : IEnemy
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly List<Rectangle> sources;
        private readonly int totalFrames;
        private int currentFrame;
        private readonly int repeatedFrames;
        private SpriteEffects spriteEffect;
        private readonly int width, height;
        private int moveCounter, dirChangeDelay;
        private readonly Random rand;
        private Direction direction = Direction.w;
        private readonly Game1 game;
        private int health;
        public Snake(Texture2D texture, Vector2 location, Game1 game)
        {
            rand = new Random();
            this.game = game;
            health = 25;
            width = height = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            spriteEffect = SpriteEffects.None;
            totalFrames = 2;
            currentFrame = 0;
            repeatedFrames = 10;
            sources = new List<Rectangle>();
            int xPos = 126, yPos = 59;
            //add frames to list
            for (int frame = 0; frame < totalFrames; frame++)
            {
                sources.Add(new Rectangle(xPos, yPos, width, height));
                xPos += width + 1;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(Texture, Location, sources[currentFrame / repeatedFrames],
                    Color.White, 0, new Vector2(0, 0), spriteEffect, 0);
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
        public void Update()
        {
            moveCounter++;
            if (moveCounter == dirChangeDelay)
            {
                ArbitraryDirection();
            }

            CheckHealth();
            currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);
            if (direction == Direction.w)
            {
                //sets sprite effect so snake faces left
                spriteEffect = SpriteEffects.FlipHorizontally;
                //moves sprite left
                Location = new Rectangle(Location.X - 1, Location.Y, Location.Width, Location.Height);
            }
            else if (direction == Direction.e)
            {
                //sets sprite effect so snake faces right
                spriteEffect = SpriteEffects.None;
                //moves sprite right
                Location = new Rectangle(Location.X + 1, Location.Y, Location.Width, Location.Height);
            }
            else if (direction == Direction.s)
            {
                //moves sprite down
                Location = new Rectangle(Location.X, Location.Y + 1, Location.Width, Location.Height);
            }
            else
            { //direction == Direction.n
                //moves sprite up
                Location = new Rectangle(Location.X, Location.Y - 1, Location.Width, Location.Height);
                if (Location.Y <= (Game1.HUDHeight + 50) * Game1.Scale)
                {
                    direction = Direction.w;
                }
            }
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
