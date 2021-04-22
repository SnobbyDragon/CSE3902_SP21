using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
namespace sprint0
{
    public class Gohma : IEnemy
    {
        private readonly Game1 game;
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly Dictionary<Color, List<Rectangle>> colorToLegMap, colorToHeadMap;
        private readonly List<SpriteEffects> leftLegEffects, rightLegEffects;
        private readonly Color color;
        private readonly int headTotalFrames, headRepeatedFrames, legTotalFrames, legRepeatedFrames, size = 16, moveDelay, fireballRate = 100, damageTime = 10;
        private readonly List<Vector2> destinations;
        private Vector2 centerOffset;
        private int fireballCounter = 0, health, damageTimer = 0, currDest, headCurrFrame, legCurrFrame;
        public int Damage { get => 2; }
        public EnemyType Type { get => EnemyType.None; }
        private readonly ItemSpawner itemSpawner;
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
        public Gohma(Texture2D texture, Vector2 location, Color color, Game1 game)
        {
            health = 25;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(size * Game1.Scale), (int)(size * Game1.Scale));
            Texture = texture;
            this.game = game;
            this.color = color;
            headCurrFrame = 0;
            legCurrFrame = 0;
            headTotalFrames = 4;
            headRepeatedFrames = 12;
            legTotalFrames = 2;
            legRepeatedFrames = 14;

            colorToLegMap = new Dictionary<Color, List<Rectangle>>
            {
                { Color.Orange, SpritesheetHelper.GetFramesH(196, 105, size, size, legTotalFrames) },
                { Color.Blue, SpritesheetHelper.GetFramesH(196, 122, size, size, legTotalFrames) }
            };
            leftLegEffects = new List<SpriteEffects>
            {
                SpriteEffects.None,
                SpriteEffects.FlipHorizontally
            };
            rightLegEffects = new List<SpriteEffects>
            {
                SpriteEffects.FlipHorizontally,
                SpriteEffects.None
            };
            colorToHeadMap = new Dictionary<Color, List<Rectangle>>
            {
                { Color.Orange, SpritesheetHelper.GetFramesH(230, 105, size, size, headTotalFrames) },
                { Color.Blue, SpritesheetHelper.GetFramesH(230, 122, size, size, headTotalFrames) }
            };

            currDest = 0;
            moveDelay = 2;
            destinations = new List<Vector2>
            {
                location,
                location + new Vector2(100,0),
                location,
                location + new Vector2(0,100)
            };

            centerOffset = new Vector2(size / 2 - 4, size / 2 - 5);
            itemSpawner = new ItemSpawner(game.Room.LoadLevel.RoomItems);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (damageTimer % 2 == 0)
            {
                spriteBatch.Draw(
                    Texture, new Rectangle(Location.X - (int)(size * Game1.Scale), Location.Y, (int)(size * Game1.Scale), (int)(size * Game1.Scale)),
                    colorToLegMap[color][legCurrFrame / legRepeatedFrames],
                    Color.White, 0, new Vector2(0, 0),
                    leftLegEffects[legCurrFrame / legRepeatedFrames], 0);
                spriteBatch.Draw(
                    Texture, new Rectangle(Location.X + (int)(size * Game1.Scale), Location.Y, (int)(size * Game1.Scale), (int)(size * Game1.Scale)),
                    colorToLegMap[color][(legCurrFrame / legRepeatedFrames + 1) % legTotalFrames], // TODO refator: this is probably overly complicated
                    Color.White, 0, new Vector2(0, 0),
                    rightLegEffects[(legCurrFrame / legRepeatedFrames + 1) % legTotalFrames], 0);
                spriteBatch.Draw(Texture, Location, colorToHeadMap[color][headCurrFrame / headRepeatedFrames], Color.White);
            }
        }

        public void Update()
        {
            if (damageTimer > 0) damageTimer--;
            CheckHealth();
            if (!game.Room.FreezeEnemies)
            {
                Vector2 dist = destinations[currDest] - Location.Location.ToVector2();
                if (dist.Length() == 0) currDest = (currDest + 1) % destinations.Count;
                else if (legCurrFrame % moveDelay == 0)
                {
                    dist.Normalize();
                    Rectangle loc = Location;
                    loc.Offset(dist.ApproxDirection().ToVector2());
                    Location = loc;
                }
                headCurrFrame = (headCurrFrame + 1) % (headTotalFrames * headRepeatedFrames);
                legCurrFrame = (legCurrFrame + 1) % (legTotalFrames * legRepeatedFrames);
                if (CanShoot()) ShootFireball();
            }
        }

        public void ChangeDirection() { }
        private void CheckHealth()
        {
            if (health < 0) Perish();
        }

        public void TakeDamage(int damage)
        {
            if (damageTimer == 0)
            {
                damageTimer = damageTime;
                health -= damage;
                game.Room.RoomSound.AddSoundEffect(SoundEnum.EnemyDamaged);
            }
        }

        public void Perish()
        {
            itemSpawner.SpawnItem(ParseEnemy(GetType().Name), Location.Location.ToVector2());
            game.Room.LoadLevel.RoomEnemies.RemoveEnemy(this);
            game.Room.LoadLevel.RoomEffect.AddEffect(Location.Location.ToVector2(), EffectEnum.Death);
            game.Room.RoomSound.AddSoundEffect(SoundEnum.EnemyDeath);
        }

        private bool CanShoot()
        {
            fireballCounter++;
            fireballCounter %= fireballRate;
            return fireballCounter == 0;
        }

        private void ShootFireball()
        {
            game.Room.RoomSound.AddSoundEffect(ParseSound(GetType().Name));
            Vector2 dir = game.Room.Player.Pos - (Location.Location.ToVector2() + centerOffset);
            dir.Normalize();
            game.Room.LoadLevel.RoomProjectile.AddFireball(Location.Center.ToVector2(), dir, this);
        }
        public EnemyEnum ParseEnemy(string enemy)
             => (EnemyEnum)Enum.Parse(typeof(EnemyEnum), enemy, true);
        private SoundEnum ParseSound(string sound)
             => (SoundEnum)Enum.Parse(typeof(SoundEnum), sound, true);
    }
}
