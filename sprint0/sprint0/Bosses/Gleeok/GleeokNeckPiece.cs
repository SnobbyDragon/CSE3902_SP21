using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
//Last updated 3/28 by Hannah
namespace sprint0
{
    public class GleeokNeckPiece : IEnemy
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;
        private readonly IEnemy head;
        private Vector2 anchor;
        private readonly Random rand;
        private readonly int xWiggleLimit = 2, yWiggleLimit = 1, wiggleDelay = 20, width = 8, height = 12, segmentNumber;
        private int xWiggle, yWiggle, wiggleCount, health;
        public int Damage { get => 0; }
        private readonly Game1 game;
        public EnemyType Type { get => EnemyType.Gleeok; }

        public GleeokNeckPiece(Texture2D texture, Vector2 anchor, IEnemy head, int segmentNumber, Game1 game)
        {
            this.game = game;
            Texture = texture;
            source = new Rectangle(271, 13, width, height);
            this.head = head;
            this.segmentNumber = segmentNumber;
            this.anchor = anchor;
            rand = new Random();
            wiggleCount = rand.Next(0, 20);
            xWiggle = yWiggle = 0;
            health = 10;
        }

        public void Draw(SpriteBatch spriteBatch)
            => spriteBatch.Draw(Texture, Location, source, Color.White);
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
        public void Update()
        {
            CheckHealth();
            Vector2 dist = head.Location.Location.ToVector2() - anchor;
            Vector2 loc = anchor + dist / 4 * segmentNumber;
            Location = new Rectangle((int)loc.X, (int)loc.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            if (segmentNumber > 0)
            {
                Rectangle loc2 = Location;
                loc2.Offset(xWiggle, yWiggle);
                Location = loc2;
                if (wiggleCount == wiggleDelay)
                {
                    xWiggle = rand.Next(-xWiggleLimit, xWiggleLimit);
                    yWiggle = rand.Next(-yWiggleLimit, yWiggleLimit);
                    wiggleCount = 0;
                }
                else
                    wiggleCount++;
            }
        }

        public void ChangeDirection() { }
        public int CheckHealth() => health;
        public void TakeDamage(int damage)
        {
            health -= damage;
            game.Room.RoomSound.AddSoundEffect(SoundEnum.EnemyDamaged);
        }

        public void Perish() { }
        public EnemyEnum ParseEnemy(string enemy)
             => (EnemyEnum)Enum.Parse(typeof(EnemyEnum), enemy, true);
    }
}
