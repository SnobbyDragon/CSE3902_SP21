using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
/*
 * Last updated: 2/21/21 by urick.9
 */
namespace sprint0
{
    public class Ganon : ISprite
    {
        private readonly Game1 game; //TODO maybe have player bc static so we don't need this
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int xOffset = 40, yOffset = 154, size = 32;
        private readonly List<Rectangle> sources;
        private int currFrame, counter; // counts the time
        private readonly int totalFrames, invisibleTime = 200, visibleTime = 100, teleportTime = 50; //TODO currently arbitrary times
        private bool isVisible;
        private readonly Random rand;
        private readonly GanonFireball fireball; // main fireball
        private readonly List<GanonFireball> fireballExplosion; // TODO upon death; currently shoots w/main fireball as demonstration
        private Vector2 centerOffset; // fireball shoots from center of ganon
        public Ganon(Texture2D texture, Vector2 location, Game1 game)
        {
            Location = location;
            Texture = texture;
            this.game = game;
            currFrame = 0;
            totalFrames = 5;
            sources = new List<Rectangle>();
            for (int frame = 0; frame < totalFrames; frame++)
            {
                sources.Add(new Rectangle(xOffset + frame * (size + 1), yOffset, size, size));
            };
            rand = new Random();

            isVisible = true;
            counter = 0;

            fireball = new GanonFireball(texture, "none");
            centerOffset = new Vector2(size / 2 - 4, size / 2 - 5); // ganon size / 2 - fireball size / 2
            fireballExplosion = new List<GanonFireball>()
            {
                new GanonFireball(texture, "up"),
                new GanonFireball(texture, "up left"),
                new GanonFireball(texture, "left"),
                new GanonFireball(texture, "down left"),
                new GanonFireball(texture, "down"),
                new GanonFireball(texture, "down right"),
                new GanonFireball(texture, "right"),
                new GanonFireball(texture, "up right")
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible) // TODO also add if dead
                spriteBatch.Draw(Texture, Location, sources[currFrame], Color.White);

            // fireball draws regardless
            fireball.Draw(spriteBatch);

            // fireballs should draw after death TODO maybe just move to game??
            foreach (GanonFireball fireball in fireballExplosion)
            {
                fireball.Draw(spriteBatch);
            }
        }

        public void Update()
        {
            // TODO change his color to red when vulnerable (hit by link many times)
            if (isVisible) // TODO actually only visible if hit by link
            {
                if (counter == visibleTime)
                {
                    // turn invisible
                    isVisible = false;
                    counter = 0;
                }
            } else
            {
                if (counter == invisibleTime)
                {
                    // turn visible
                    isVisible = true;
                    counter = 0;
                    currFrame = (currFrame + 1) % totalFrames; //TODO frame depends on location?
                } else if (counter == teleportTime)
                {
                    // teleport somewhere
                    Teleport();
                }
            }
            counter++;

            // fireballs move and animate regardless
            if (CanShoot())
            {
                ShootFireball();
                FireballExplosion(); // TODO move this to when ganon dies
            }
            else
            {
                fireball.Update();
                foreach (GanonFireball fireball in fireballExplosion)
                {
                    fireball.Update();
                }
            }
        }

        private bool CanShoot() // shoot fireball if fireball is dead
        {
            return fireball.IsDead;
        }

        private void ShootFireball()
        {
            Vector2 dir = game.Player.Pos - (Location + centerOffset);
            dir.Normalize();
            fireball.Direction = dir;
            fireball.Location = Location + centerOffset;
            fireball.IsDead = false;
        }

        private void FireballExplosion()
        {
            // shoots 8 fireballs in all directions
            foreach (GanonFireball fireball in fireballExplosion)
            {
                fireball.Location = Location + centerOffset;
                fireball.IsDead = false;
            }
        }

        public void Teleport()
        {
            // currently picks a random place to appear TODO change location bounds
            // TODO depends on where link is?
            Location = new Vector2(
                rand.Next((int)(32 * Game1.Scale), (int)((Game1.Width - 32 - size) * Game1.Scale)),
                rand.Next((int)((Game1.HUDHeight + 32) * Game1.Scale), (int)((Game1.HUDHeight + Game1.MapHeight - 32 - size) * Game1.Scale))
                );
        }
    }
}
