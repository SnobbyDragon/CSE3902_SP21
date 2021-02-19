using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
namespace sprint0
{
    public class Patra : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;
        private List<SpriteEffects> effects;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;
        private List<ISprite> minions;
        private readonly int totalMinions = 8;
        private Vector2 destination; //TODO depends on link. i think it keeps optimal distance so minions can hit link
        private readonly Random rand;
        private int moveCounter;
        private readonly int moveDelay; // delay to make slower bc floats mess up drawings; must be < totalFrames*repeatedFrames

        public Patra(Texture2D texture, Vector2 location)
        {
            Location = location;
            Texture = texture;
            source = new Rectangle(1, 157, 16, 11);
            currFrame = 0;
            totalFrames = 2;
            repeatedFrames = 2;

            // flips to animate flying
            effects = new List<SpriteEffects>
            {
                SpriteEffects.None,
                SpriteEffects.FlipHorizontally
            };

            // has 8 orange minions
            minions = new List<ISprite>();
            for (int i = 0; i < totalMinions; i++)
            {
                minions.Add(new PatraMinion(Texture, this, 360/totalMinions * i));
            }

            rand = new Random();
            generateDest();

            moveCounter = 0;
            moveDelay = 5; // slow
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, source, Color.White, 0, new Vector2(0, 0), 1, effects[currFrame / repeatedFrames], 0);
            foreach (ISprite minion in minions)
                minion.Draw(spriteBatch);
        }

        public void Update()
        {
            Vector2 dist = destination - Location;
            if (dist.Length() < 5)
            {
                // reached destination, generate new destination; TODO change dir bc of link position
                generateDest();
            }
            else if (moveCounter == moveDelay)
            {
                // has not reached destination, move towards it
                dist.Normalize();
                Location += dist; //TODO BUG: green background appears bc of floating point error; make a rounding method for vectors? or refactor movement
                moveCounter = 0;
            }
            moveCounter++;

            currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
            foreach (ISprite minion in minions) //TODO maybe move to game
                minion.Update();
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
