using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
namespace sprint0
{
    public class Manhandla : IEnemy
    {
        private readonly Game1 game;
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int size = 16;
        private Rectangle source;
        private readonly List<IEnemy> limbs;
        private int speed; // TODO faster as limbs die
        private Vector2 destination;
        private readonly Random rand;
        
        public Manhandla(Texture2D texture, Vector2 location, Game1 game)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(size * Game1.Scale), (int)(size * Game1.Scale));
            Texture = texture;
            this.game = game;
            source = new Rectangle(69, 89, size, size); //center
            speed = 1;
            
            limbs = new List<IEnemy>
            {
                new ManhandlaLimb(Texture, this, Direction.n, game),
                new ManhandlaLimb(Texture, this, Direction.s, game),
                new ManhandlaLimb(Texture, this, Direction.w, game),
                new ManhandlaLimb(Texture, this, Direction.e, game)
            };
            //register limbs as enemies for collision handling
            game.RegisterEnemies(limbs);
           
            rand = new Random();
            GenerateDest();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, source, Color.White);
        }

        public void Update()
        {
           
            CheckHealth();
            Vector2 dist = destination - Location.Location.ToVector2();
            if (dist.Length() < 5)
            {
                GenerateDest();
            }
            else
            {
                dist.Normalize();
                Rectangle loc = Location;
                loc.Offset(speed * dist.ApproxDirection().ToVector2());
                Location = loc;
            }

          
        }

        public void ChangeDirection()
        {
            GenerateDest();
        }

        private void CheckHealth()
        {
            int limbCount = 0;
            ManhandlaLimb toRemove=null;
            foreach (ManhandlaLimb limb in limbs)
            {
                limbCount++;
                if (limb.CheckHealth() < 0) toRemove=limb;
            }
            RemoveLimb(toRemove);
            if (limbCount == 0) Perish();
        }

        private void RemoveLimb(ManhandlaLimb limb) {
            limbs.Remove(limb);
        }

        public void TakeDamage(int damage)
        {
            //no-op
        }

        public void Perish()
        {
            game.RemoveEnemy(this);
        }

        // generates a new destination
        private void GenerateDest()
        {
            // TODO movement depends on where link is?
            destination = new Vector2(
                rand.Next((int)(Game1.BorderThickness * Game1.Scale), (int)((Game1.Width - Game1.BorderThickness) * Game1.Scale)),
                rand.Next((int)((Game1.HUDHeight + Game1.BorderThickness) * Game1.Scale), (int)((Game1.HUDHeight + Game1.MapHeight - Game1.BorderThickness) * Game1.Scale))
                );
        }
    }
}
