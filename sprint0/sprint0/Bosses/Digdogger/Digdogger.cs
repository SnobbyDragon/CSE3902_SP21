using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
/*
 * Last updated: 3/4/21 by li.10011
 */
namespace sprint0
{
    public class Digdogger : IEnemy
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int bigSize = 32, smallSize = 16;
        private readonly List<Rectangle> smallSources;
        private readonly Dictionary<string, List<Rectangle>> dirToBigSource;
        private int currFrame, spikeDelay, spikeCounter; // randomly switch spike direction after a delay
        private readonly int bigTotalFrames, repeatedFrames, totalFrames;
        private readonly bool isBig;
        private string spikes;
        private readonly Random rand;
        private Vector2 destination; //TODO depends on link; runs away?
        private int moveCounter;
        private readonly int moveDelay; // delay to make slower bc floats mess up drawings; must be < totalFrames*repeatedFrames

        public Digdogger(Texture2D texture, Vector2 location)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, bigSize, bigSize); //TODO size is variable
            Texture = texture;
            currFrame = 0;
            bigTotalFrames = 5;
            totalFrames = 2;
            repeatedFrames = 5;
            List<Rectangle> bigSources = GetFrames(196, 58, bigTotalFrames, bigSize);
            dirToBigSource = new Dictionary<string, List<Rectangle>>
            {
                { "none", new List<Rectangle> { bigSources[0] } }, // no spikes; not used I think?
                { "left", new List<Rectangle> { bigSources[1], bigSources[3] } }, // spikes on the left
                { "right", new List<Rectangle> { bigSources[2], bigSources[4] } }, // spikes on the right
            };
            smallSources = GetFrames(361, 58, totalFrames, smallSize);
            isBig = true;
            rand = new Random();
            spikes = "none";
            SwitchSpikeDir();
            GenerateDest();
            moveCounter = 0;
            moveDelay = 4; // slow
        }

        public void SwitchSpikeDir()
        {
            spikeDelay = rand.Next(repeatedFrames * totalFrames, repeatedFrames * totalFrames * 2);
            spikeCounter = 0;
            if (rand.Next(0, 2) == 0) // 50% chance to switch; 0 <= rand integer < 2
            {
                spikes = "left";
            }
            else
            {
                spikes = "right";
            }
        }

        public List<Rectangle> GetFrames(int xOffset, int yOffset, int totalFrames, int size)
        {
            List<Rectangle> sources = new List<Rectangle>();
            for (int frame = 0; frame < totalFrames; frame++)
            {
                sources.Add(new Rectangle(xOffset + frame * (size + 1), yOffset, size, size));
            };
            return sources;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isBig)
                spriteBatch.Draw(Texture, Location, dirToBigSource[spikes][currFrame / repeatedFrames], Color.White);
            else
                spriteBatch.Draw(Texture, Location, smallSources[currFrame / repeatedFrames], Color.White);
        }

        public void Update()
        {
            if (isBig)
            {
                if (spikeCounter == spikeDelay)
                {
                    SwitchSpikeDir();
                }
                spikeCounter++;

                Vector2 dist = destination - Location.Location.ToVector2();
                if (dist.Length() < 5)
                {
                    // reached destination, generate new destination; TODO change dir bc of link position
                    GenerateDest();
                }
                else if (moveCounter == moveDelay)
                {
                    // has not reached destination, move towards it
                    dist.Normalize();
                    Rectangle loc = Location;
                    loc.Offset(ApproximateDirection(dist)); //TODO BUG: green background appears bc of floating point error; make a rounding method for vectors? or refactor movement
                    Location = loc;
                    moveCounter = 0;
                }
                moveCounter++;
            }
            else
            {
                // TODO bounce around the room; run away from link?

            }

            currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
        }

        // generates a new destination
        private void GenerateDest()
        {
            // currently picks a random destination TODO make 32 static variable? this is the wall width
            // TODO movement depends on where link is?
            destination = new Vector2(
                rand.Next((int)(32 * Game1.Scale), (int)((Game1.Width - 32) * Game1.Scale)),
                rand.Next((int)((Game1.HUDHeight + 32) * Game1.Scale), (int)((Game1.HUDHeight + Game1.MapHeight - 32)*Game1.Scale))
                );
        }

        private Vector2 ApproximateDirection(Vector2 dir)
        {
            //TODO currently using vectors; maybe make IDirection interface?
            //Direction closestApprox;
            //foreach (Direction d in Enum.GetValues(typeof(Direction))) {}
            List<Vector2> vectors = new List<Vector2>
            {
                new Vector2(1, 0),
                new Vector2(-1, 0),
                new Vector2(0, 1),
                new Vector2(0, -1),
                new Vector2(1, 1),
                new Vector2(1, -1),
                new Vector2(-1, 1),
                new Vector2(-1, -1),
            };
            Vector2 closestApprox = vectors[0];
            float closestDist = (closestApprox - dir).LengthSquared();
            foreach (Vector2 v in vectors)
            {
                float dist = (v - dir).LengthSquared();
                if (dist < closestDist)
                {
                    closestApprox = v;
                    closestDist = dist;
                }
            }
            return closestApprox;
        }
    }
}
