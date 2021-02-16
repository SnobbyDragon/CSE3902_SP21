using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Manhandla : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int size = 16;
        private Rectangle source;
        private List<ISprite> limbs;
        private int speed; // TODO faster as limbs die
        private int fireballCounter, fireballRate; // TODO faster as limbs die
        private Vector2 destination;
        private readonly Random rand;

        public Manhandla(Texture2D texture, Vector2 location)
        {
            Location = location;
            Texture = texture;
            source = new Rectangle(69, 89, size, size); //center
            speed = 3; // starting speed
            fireballRate = 100; // TODO currently arbitrary
            limbs = new List<ISprite>
            {
                new ManhandlaLimb(Texture, this, "up"),
                new ManhandlaLimb(Texture, this, "down"),
                new ManhandlaLimb(Texture, this, "left"),
                new ManhandlaLimb(Texture, this, "right")
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

            if (fireballCounter == fireballRate)
            {
                // fire the fireballs
                fireballCounter = 0;
                // TODO create a fireball sprite moving in a certain direction
            }
            else
            {
                fireballCounter++;
            }

            foreach (ISprite limb in limbs)
                limb.Update();
        }

        // generates a new destination
        public void generateDest()
        {
            // currently picks a random destination TODO change location bounds
            // TODO movement depends on where link is?
            destination = new Vector2(rand.Next(0, 800), rand.Next(0, 500));
        }
    }
}
