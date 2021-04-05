using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
/*
 * Last updated: 3/14/21 by li.10011
 */
namespace sprint0
{
    public class Digdogger : IEnemy
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        public EnemyType Type { get => EnemyType.None; }
        private readonly int bigSize = 32, smallSize = 16;
        private readonly List<Rectangle> smallSources;
        private readonly Dictionary<Spikes, List<Rectangle>> dirToBigSource;
        private int currFrame, spikeDelay, spikeCounter;
        private readonly int bigTotalFrames, repeatedFrames, smallTotalFrames;
        private readonly bool isBig;
        private enum Spikes { none, left, right };
        private Spikes currSpikes;
        private readonly Random rand;
        private Vector2 destination;
        private int moveCounter;
        private readonly int moveDelay;
        private readonly Game1 game;
        private int health;
        public int Damage { get => 2; }
        private ItemSpawner itemSpawner;

        public Digdogger(Texture2D texture, Vector2 location, Game1 game)
        {
            health = 25;
            this.game = game;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(bigSize * Game1.Scale), (int)(bigSize * Game1.Scale));
            Texture = texture;
            currFrame = 0;
            bigTotalFrames = 5;
            smallTotalFrames = 2;
            repeatedFrames = 5;
            List<Rectangle> bigSources = SpritesheetHelper.GetFramesH(196, 58, bigSize, bigSize, bigTotalFrames);
            dirToBigSource = new Dictionary<Spikes, List<Rectangle>>
            {
                { Spikes.none, new List<Rectangle> { bigSources[0] } },
                { Spikes.left, new List<Rectangle> { bigSources[1], bigSources[3] } },
                { Spikes.right, new List<Rectangle> { bigSources[2], bigSources[4] } },
            };
            smallSources = SpritesheetHelper.GetFramesH(361, 58, smallSize, smallSize, smallTotalFrames);
            isBig = true;
            rand = new Random();
            currSpikes = Spikes.none;
            SwitchSpikeDir();
            GenerateDest();
            moveCounter = 0;
            moveDelay = 4;
            itemSpawner = new ItemSpawner(game.Room.LoadLevel.RoomItems);
        }

        public void SwitchSpikeDir()
        {
            spikeDelay = rand.Next(repeatedFrames * smallTotalFrames, repeatedFrames * smallTotalFrames * 2);
            spikeCounter = 0;
            if (rand.Next(0, 2) == 0)
            {
                currSpikes = Spikes.left;
            }
            else
            {
                currSpikes = Spikes.right;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isBig)
                spriteBatch.Draw(Texture, Location, dirToBigSource[currSpikes][currFrame / repeatedFrames], Color.White);
            else
                spriteBatch.Draw(Texture, Location, smallSources[currFrame / repeatedFrames], Color.White);
        }

        public void Update()
        {
            CheckHealth();
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
            }
            currFrame = (currFrame + 1) % (smallTotalFrames * repeatedFrames);
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
            itemSpawner.SpawnItem(ParseEnemy(this.GetType().Name), this.Location.Location.ToVector2());
            game.Room.LoadLevel.RoomEnemies.RemoveEnemy(this);

            game.Room.LoadLevel.RoomEffect.AddEffect(Location.Location.ToVector2(), EffectEnum.Death);
            game.Room.RoomSound.AddSoundEffect("enemy death");
        }

        private void GenerateDest()
        {
            game.Room.RoomSound.AddSoundEffect(GetType().Name.ToLower());
            destination = new Vector2(
                rand.Next((int)(Game1.BorderThickness * Game1.Scale), (int)((Game1.Width - Game1.BorderThickness) * Game1.Scale)),
                rand.Next((int)((Game1.HUDHeight + Game1.BorderThickness) * Game1.Scale), (int)((Game1.HUDHeight + Game1.MapHeight - Game1.BorderThickness) * Game1.Scale))
                );
        }
        public EnemyEnum ParseEnemy(string enemy)
             => (EnemyEnum)Enum.Parse(typeof(EnemyEnum), enemy, true);
    }
}
