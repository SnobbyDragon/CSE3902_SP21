using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Hannah Johnson
namespace sprint0
{
    public class GleeokNeck : IEnemy
    {
        private Game1 game;
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private List<IEnemy> neck;
        public int Damage { get => 0; }
        private bool isDead;
        public EnemyType Type { get => EnemyType.Gleeok; }

        public GleeokNeck(Texture2D texture, Game1 game, Rectangle location)
        {
            isDead = false;
            Texture = texture;
            this.game = game;
            Location = location;
            neck = new List<IEnemy>();
            Vector2 anchor = Location.Location.ToVector2() + new Vector2(Location.Width / 3, (float)(Location.Height * 0.8));
            IEnemy head = new GleeokHead(Texture, anchor, game);
            for (int i = 0; i < 4; i++)
            {
                neck.Add(new GleeokNeckPiece(Texture, anchor, head, i, game));
            }
            neck.Add(head);
            game.Room.LoadLevel.RoomEnemies.RegisterEnemies(neck);
        }

        public void Draw(SpriteBatch spriteBatch) { }
        public void Update() => CheckHealth();

        public void ChangeDirection() { }

        private void CheckHealth()
        {
            int neckHealth = 0;
            foreach (IEnemy neckpeice1 in neck)
            {
                if (neckpeice1 is GleeokHead)
                {
                    GleeokHead head = (GleeokHead)neckpeice1;
                    neckHealth += head.CheckHealth();
                }
                else if (neckpeice1 is GleeokNeckPiece)
                {
                    GleeokNeckPiece neckpeice = (GleeokNeckPiece)neckpeice1;
                    neckHealth += neckpeice.CheckHealth();
                }


            }
            if (neckHealth < 0) Perish();
        }

        public void TakeDamage(int damage) { }

        public bool IsDead() => isDead;

        public void Perish()
        {
            while (neck.Count != 0)
            {
                IEnemy neckpeice = neck[0];
                neck.RemoveAt(0);
                game.Room.LoadLevel.RoomEnemies.RemoveEnemy(neckpeice);
            }
            isDead = true;
        }
        public EnemyEnum ParseEnemy(string enemy)
             => (EnemyEnum)Enum.Parse(typeof(EnemyEnum), enemy, true);
    }
}
