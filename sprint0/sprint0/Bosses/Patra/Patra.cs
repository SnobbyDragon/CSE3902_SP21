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
        private readonly List<IEnemy> minions;
        private readonly int totalMinions = 8;
        private Vector2 destination; //TODO depends on link. i think it keeps optimal distance so minions can hit link
        private readonly Random rand;
        private int moveCounter;
        private readonly int moveDelay; // delay to make slower bc floats mess up drawings; must be < totalFrames*repeatedFrames
        private readonly int width = 16, height = 11;
        private int health;
        private readonly Game1 game;
        public int Damage { get => 4; }

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
                GenerateDest();
            }
            else if (moveCounter == moveDelay)
            {
                dist.Normalize();
                Rectangle loc = Location;
                loc.Offset(dist.ApproxDirection().ToVector2());
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
            game.Room.RoomSound.AddSoundEffect("enemy damaged");
        }

        public void Perish()
        {
            game.Room.LoadLevel.RoomEnemies.RemoveEnemy(this);
            game.Room.RoomSound.AddSoundEffect("enemy death");
        }

        // generates a new destination
        private void GenerateDest()
        {
            game.Room.RoomSound.AddSoundEffect(GetType().Name.ToLower());
            destination = new Vector2(
                rand.Next((int)(Game1.BorderThickness * Game1.Scale), (int)((Game1.Width - Game1.BorderThickness) * Game1.Scale)),
                rand.Next((int)((Game1.HUDHeight + Game1.BorderThickness) * Game1.Scale), (int)((Game1.HUDHeight + Game1.MapHeight - Game1.BorderThickness) * Game1.Scale))
                );
        }
    }
}
