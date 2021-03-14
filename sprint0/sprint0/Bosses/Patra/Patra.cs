using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
namespace sprint0
{
    public class Patra : IEnemy
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;
        private List<SpriteEffects> effects;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;
        private List<IEnemy> minions;
        private readonly int totalMinions = 8;
        private Vector2 destination; //TODO depends on link. i think it keeps optimal distance so minions can hit link
        private readonly Random rand;
        private int moveCounter;
        private readonly int moveDelay; // delay to make slower bc floats mess up drawings; must be < totalFrames*repeatedFrames
        private readonly int width = 16, height = 11;
        private int health;
        private readonly Game1 game;
        public Patra(Texture2D texture, Vector2 location, Game1 game)
        {
            this.game = game;
            health = 25;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            source = new Rectangle(1, 157, width, height);
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
            minions = new List<IEnemy>();
            for (int i = 0; i < totalMinions; i++)
            {
                minions.Add(new PatraMinion(Texture, this, 360 / totalMinions * i, game));
            }

            rand = new Random();
            GenerateDest();

            moveCounter = 0;
            moveDelay = 5; // slow
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, source, Color.White, 0, new Vector2(0, 0), effects[currFrame / repeatedFrames], 0);
            foreach (IEnemy minion in minions)
                minion.Draw(spriteBatch);
        }

        public void Update()
        {
            CheckHealth();
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
                loc.Offset(ApproximateDirection(dist));
                Location = loc;
                moveCounter = 0;
            }
            moveCounter++;

            currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
            foreach (IEnemy minion in minions) //TODO maybe move to game
                minion.Update();
        }

        public void ChangeDirection()
        {
            GenerateDest();
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

        // generates a new destination
        private void GenerateDest()
        {
            // currently picks a random destination TODO change location bounds
            // TODO movement depends on where link is?
            destination = new Vector2(
                rand.Next((int)(32 * Game1.Scale), (int)((Game1.Width - 32) * Game1.Scale)),
                rand.Next((int)((Game1.HUDHeight + 32) * Game1.Scale), (int)((Game1.HUDHeight + Game1.MapHeight - 32) * Game1.Scale))
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
