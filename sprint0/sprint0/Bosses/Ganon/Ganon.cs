using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
/*
 * Last updated: 3/13/21 by johnson.7510
 */
namespace sprint0
{
    public class Ganon : IEnemy
    {
        private readonly Game1 game; //TODO maybe have player bc static so we don't need this
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int xOffset = 40, yOffset = 154, width, height;
        private readonly List<Rectangle> sources;
        private int currFrame, counter; // counts the time
        private readonly int totalFrames, invisibleTime = 200, visibleTime = 100, teleportTime = 50; //TODO currently arbitrary times
        private bool isVisible, isDead;
        private int deathCounter;
        private readonly Random rand;
        private readonly List<GanonFireball> fireballExplosion; 
        private Vector2 centerOffset; // fireball shoots from center of ganon
        private readonly int fireballRate = 100; //TODO currently arbitrary
        private int fireballCounter = 0;
        private int health;

        public Ganon(Texture2D texture, Vector2 location, Game1 game)
        {
            health = 25;
            width = height = 32;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            this.game = game;
            currFrame = 0;
            totalFrames = 6;
            sources = new List<Rectangle>();
            for (int frame = 0; frame < totalFrames; frame++)
            {
                sources.Add(new Rectangle(xOffset + frame * (width + 1), yOffset, width, height));
            };
            rand = new Random();

            isVisible = true;
            isDead = false;
            counter = 0;
            deathCounter = 0;

            centerOffset = new Vector2(width / 2 - 4, height / 2 - 5); // ganon size / 2 - fireball size / 2
            fireballExplosion = new List<GanonFireball>() 
            {
                new GanonFireball(texture,location, "up", this),
                new GanonFireball(texture,location, "up left", this),
                new GanonFireball(texture,location, "left", this),
                new GanonFireball(texture,location, "down left", this),
                new GanonFireball(texture,location, "down", this),
                new GanonFireball(texture,location, "down right", this),
                new GanonFireball(texture,location, "right", this),
                new GanonFireball(texture, location,"up right", this)
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible && !isDead) 
                spriteBatch.Draw(Texture, Location, sources[currFrame], Color.White);

            //fireballs should draw after death 
            foreach (GanonFireball fireball in fireballExplosion)
            {
                fireball.Draw(spriteBatch);
            }
        }

        public void Update()
        {
           
            // TODO change his color to red when vulnerable (hit by link many times)
            if (isDead) {

                if (deathCounter==0) FireballExplosion();
               deathCounter++;
               if (deathCounter == 70 ) Perish();

            }
            else if (isVisible) // TODO actually only visible if hit by link
            {
                CheckHealth();
                if (counter == visibleTime)
                {
                    // turn invisible
                    isVisible = false;
                    counter = 0;
                }
            }
            else
            {
                if (counter == invisibleTime)
                {
                    // turn visible
                    isVisible = true;
                    counter = 0;
                    currFrame = (currFrame + 1) % (totalFrames-1); //TODO frame depends on location?
                    CheckHealth();
                }
                else if (counter == teleportTime)
                {
                    // teleport somewhere
                    Teleport();
                    CheckHealth();
                }
            }
            counter++;

            // fireballs move and animate regardless
            if (CanShoot())
            {
                ShootFireball();
              
            }
            else
            {
                foreach (GanonFireball fireball in fireballExplosion)
                {
                    fireball.Update();
                }
            }
        }

        public void ChangeDirection()
        {
            // not necessary
        }

        private void CheckHealth()
        {
           if (health < 0) isDead=true;
            if (health < 20) currFrame = 5;
        }
        public void TakeDamage(int damage)
        {
            health -= damage;
            isVisible = true;
        }

        public void Perish()
        {
            
            game.RemoveEnemy(this);
        }

        private bool CanShoot()
        {
            fireballCounter++;
            fireballCounter %= fireballRate;
            return fireballCounter == 0;
        }

        private void ShootFireball()
        {
            Vector2 dir = game.Player.Pos - (Location.Location.ToVector2() + centerOffset);
            dir.Normalize();
            game.AddFireball(Location.Location.ToVector2(), dir, this);
        }

        private void FireballExplosion()
        {
            // shoots 8 fireballs in all directions
            foreach (GanonFireball fireball in fireballExplosion)
            {
                Vector2 recLoc = Location.Location.ToVector2() + centerOffset;
                fireball.Location = new Rectangle((int)recLoc.X, (int)recLoc.Y, (int)(8 * Game1.Scale), (int)(10 * Game1.Scale));
                fireball.IsDead = false;
            }
            
        }

        public void Teleport()
        {
            // currently picks a random place to appear 
            // TODO depends on where link is?
            Vector2 loc = new Vector2(
                rand.Next((int)(32 * Game1.Scale), (int)((Game1.Width - 32 - width) * Game1.Scale)),
                rand.Next((int)((Game1.HUDHeight + 32) * Game1.Scale), (int)((Game1.HUDHeight + Game1.MapHeight - 32 - height) * Game1.Scale))
                );
            Location = new Rectangle((int)loc.X, (int)loc.Y, Location.Width, Location.Height);
        }
    }
}
