using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public abstract class AbstractEnemy : IEnemy
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        public int Damage { get => damage; }
        protected Direction direction;
        protected int width, height, health, moveCounter, dirChangeDelay, damageTimer = 0, currentFrame, totalFrames, repeatedFrames, damage = 0;
        protected Random rand;
        protected readonly Game1 game;
        protected ItemSpawner itemSpawner;
        public EnemyType Type { get => EnemyType.None; }

        public AbstractEnemy(Texture2D texture, Vector2 location, Game1 game)
        {
            rand = new Random();
            this.game = game;
            health = 50;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            itemSpawner = new ItemSpawner(game.Room.LoadLevel.RoomItems);
        }

        public abstract void Draw(SpriteBatch spriteBatch);

        public virtual void Update()
        {
            if (damageTimer > 0) damageTimer--;
            CheckHealth();
            if (!game.Room.FreezeEnemies)
            {
                moveCounter++;
                if (moveCounter == dirChangeDelay) ArbitraryDirection(30, 50);
                currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);
                Rectangle loc = Location;
                loc.Offset(direction.ToVector2());
                Location = loc;
            }
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
            protected void ArbitraryDirection(int low, int high)
        {
            moveCounter = 0;
            direction = (Direction)rand.Next(0, 4);
            dirChangeDelay = rand.Next(low, high);
        }

        public virtual void ChangeDirection()
            => ArbitraryDirection(30, 50);

        public virtual void CheckHealth()
        {
            if (health < 0) Perish();
        }

        public virtual void TakeDamage(int damage)
        {
            if (damageTimer == 0)
            {
                health -= damage;
                game.Room.RoomSound.AddSoundEffect(SoundEnum.EnemyDamaged);
                damageTimer = 15;
            }
        }

        public void Perish()
        {
            itemSpawner.SpawnItem(ParseEnemy(GetType().Name), Location.Location.ToVector2());
            game.Room.LoadLevel.RoomEnemies.RemoveEnemy(this);
            game.Room.LoadLevel.RoomEffect.AddEffect(Location.Location.ToVector2(), EffectEnum.Death);
            game.Room.RoomSound.AddSoundEffect(SoundEnum.EnemyDeath);
        }

        public EnemyEnum ParseEnemy(string enemy)
             => (EnemyEnum)Enum.Parse(typeof(EnemyEnum), enemy, true);
    }
}
