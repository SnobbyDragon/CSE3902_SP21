using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
/*
 * Last updated: 04/19/21 by shah.1440
 */
namespace sprint0
{
    public class Digdogger : IEnemy
    {
        private enum Spikes { none, left, right };
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        public EnemyType Type { get => EnemyType.None; }
        public int Damage { get => 2; }
        public bool IsBig { get => isBig; set => isBig = value; }
        private readonly int bigSize = 32, smallSize = 16, bigTotalFrames, repeatedFrames, smallTotalFrames, moveDelay;
        private readonly List<Rectangle> smallSources;
        private readonly Dictionary<Spikes, List<Rectangle>> dirToBigSource;
        private readonly Game1 game;
        private readonly Random rand;
        private readonly ItemSpawner itemSpawner;
        private int currFrame, spikeDelay, spikeCounter, health, moveCounter;
        private bool isBig;
        private Spikes currSpikes;
        private Vector2 destination;

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
            if (rand.Next(0, 2) == 0) currSpikes = Spikes.left;
            else currSpikes = Spikes.right;
        }
        public void UpdateDifficulty(GameStateMachine.Mode mode)
        {
            if (game.stateMachine.GetMode() == GameStateMachine.Mode.easy && mode == GameStateMachine.Mode.hard)
            {
                health *= 2;
            }
            if (game.stateMachine.GetMode() == GameStateMachine.Mode.hard && mode == GameStateMachine.Mode.easy)
            {
                health /= 2;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (isBig)
                spriteBatch.Draw(Texture, Location, dirToBigSource[currSpikes][currFrame / repeatedFrames], Color.White);
            else
                spriteBatch.Draw(Texture, new Rectangle(Location.X, Location.Y, (int)(smallSize * Game1.Scale), (int)(smallSize * Game1.Scale)), smallSources[currFrame / repeatedFrames], Color.White);
        }

        public void Update()
        {
            CheckHealth();
            if (isBig && ! game.Room.FreezeEnemies)
            {
                if (spikeCounter == spikeDelay)
                {
                    SwitchSpikeDir();
                    game.Room.RoomSound.AddSoundEffect(ParseSound(GetType().Name));
                }
                spikeCounter++;

                Vector2 dist = destination - Location.Location.ToVector2();
                if (dist.Length() < 5) GenerateDest();
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

        public void ChangeDirection() => GenerateDest();

        private void CheckHealth()
        {
            if (health < 0) Perish();
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            game.Room.RoomSound.AddSoundEffect(SoundEnum.EnemyDamaged);
        }

        public void Perish()
        {
            itemSpawner.SpawnItem(ParseEnemy(GetType().Name), Location.Location.ToVector2());
            game.Room.LoadLevel.RoomEnemies.RemoveEnemy(this);

            game.Room.LoadLevel.RoomEffect.AddEffect(Location.Location.ToVector2(), EffectEnum.Death);
            game.Room.RoomSound.AddSoundEffect(SoundEnum.EnemyDeath);
        }

        private void GenerateDest()
        {
            destination = new Vector2(
                rand.Next((int)(Game1.BorderThickness * Game1.Scale), (int)((Game1.Width - Game1.BorderThickness) * Game1.Scale)),
                rand.Next((int)((Game1.HUDHeight + Game1.BorderThickness) * Game1.Scale), (int)((Game1.HUDHeight + Game1.MapHeight - Game1.BorderThickness) * Game1.Scale)));
        }

        public EnemyEnum ParseEnemy(string enemy)
             => (EnemyEnum)Enum.Parse(typeof(EnemyEnum), enemy, true);
        private SoundEnum ParseSound(string sound)
             => (SoundEnum)Enum.Parse(typeof(SoundEnum), sound, true);
    }
}
