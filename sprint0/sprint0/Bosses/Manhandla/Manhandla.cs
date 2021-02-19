using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
namespace sprint0
{
    public class Manhandla : ISprite
    {
        private Game1 game;
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int size = 16;
        private Rectangle source;
        private List<ISprite> limbs;
        private int speed; // TODO faster as limbs die
        //private int fireballRate; // TODO faster as limbs die; use this, currently shooting s.t. only 1 fireball on map at a time
        private Vector2 destination;
        private readonly Random rand;

        public Manhandla(Texture2D texture, Vector2 location, Game1 game)
        {
            Location = location;
            Texture = texture;
            this.game = game;
            source = new Rectangle(69, 89, size, size); //center
            speed = 1; // starting speed; TODO might actually need to be slower...
            //fireballRate = 100; // TODO currently arbitrary
            limbs = new List<ISprite>
            {
                new ManhandlaLimb(Texture, this, "up", game),
                new ManhandlaLimb(Texture, this, "down", game),
                new ManhandlaLimb(Texture, this, "left", game),
                new ManhandlaLimb(Texture, this, "right", game)
            };
            rand = new Random();
            generateDest();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, source, Color.White);
            foreach (ManhandlaLimb limb in limbs)
                limb.Draw(spriteBatch);
        }

        public void Update()
        {
            Vector2 dist = destination - Location;
            if (dist.Length() < 5) // floating point errors
            {
                // reached destination, so pick a new destination
                generateDest();
            }
            else
            {
                // has not reached destination, move towards it
                dist.Normalize();
                Location += speed * dist; //TODO BUG: green background appears bc of floating point error; make a rounding method for vectors? or refactor movement
            }

            foreach (ISprite limb in limbs)
                limb.Update();
        }

        // generates a new destination
        public void generateDest()
        {
            // currently picks a random destination TODO change location bounds
            // TODO movement depends on where link is?
            destination = new Vector2(
                rand.Next((int)(32 * Game1.Scale), (int)((Game1.Width - 32) * Game1.Scale)),
                rand.Next((int)((Game1.HUDHeight + 32) * Game1.Scale), (int)((Game1.HUDHeight + Game1.MapHeight - 32) * Game1.Scale))
                );
        }
    }
}
