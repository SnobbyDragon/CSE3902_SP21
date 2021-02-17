using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Aquamentus : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int xOffset = 1, yOffset = 11, width = 24, height = 32;
        private List<Rectangle> sources;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;
        private int currDest;
        private readonly int moveDelay; // delay to make slower bc floats mess up drawings; must be < totalFrames*repeatedFrames
        private List<Vector2> destinations; // aquamentus moves to predetermined destinations TODO depends on link actually

        public Aquamentus(Texture2D texture, Vector2 location)
        {
            Location = location;
            Texture = texture;
            currFrame = 0;
            totalFrames = 4;
            repeatedFrames = 14;
            sources = new List<Rectangle>();
            for (int frame = 0; frame < totalFrames; frame++)
            {
                sources.Add(new Rectangle(xOffset + frame * (width + 1), yOffset, width, height));
            };

            currDest = 0;
            moveDelay = 5; //slow dragoon
            destinations = new List<Vector2>
            {
                location,
                location + new Vector2(30,0)
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, sources[currFrame / repeatedFrames], Color.White);
        }

        public void Update()
        {
            Vector2 dist = destinations[currDest] - Location;
            if (dist.Length() == 0)
            {
                // reached destination, so pick a new destination
                currDest = (currDest + 1) % destinations.Count;
            }
            else if (currFrame % moveDelay == 0)
            {
                // has not reached destination, move towards it
                dist.Normalize();
                Location += dist;
            }
            currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
        }
    }
}
