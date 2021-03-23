using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
namespace sprint0
{
    public class Gleeok : IEnemy
    {
        private Game1 game;
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int xOffset = 196, yOffset = 11, width = 24, height = 32;
        private readonly List<Rectangle> sources;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;
        private List<IEnemy> neck1, neck2;
        private int health;
        public int Damage { get => 0; }

        public Gleeok(Texture2D texture, Vector2 location, Game1 game)
        {
            health = 25;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            this.game = game;
            currFrame = 0;
            totalFrames = 3;
            repeatedFrames = 12;
            sources = SpritesheetHelper.GetFramesH(xOffset, yOffset, width, height, totalFrames);
            sources.Add(new Rectangle(xOffset + width + 1, yOffset, width, height));

            neck1 = GenerateNeck();
            neck2 = GenerateNeck();
        }

        private List<IEnemy> GenerateNeck()
        {
            List<IEnemy> neck = new List<IEnemy>();
            Vector2 anchor = Location.Location.ToVector2() + new Vector2(Location.Width / 3, (float)(Location.Height * 0.8));
            IEnemy head = new GleeokHead(Texture, anchor, game);
            for (int i = 0; i < 4; i++)
            {
                neck.Add(new GleeokNeck(Texture, anchor, head, i));
            }
            neck.Add(head);
            return neck;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, sources[currFrame / repeatedFrames], Color.White);
            foreach (IEnemy sprite in neck1)
                sprite.Draw(spriteBatch);
            foreach (IEnemy sprite in neck2)
                sprite.Draw(spriteBatch);
        }

        public void Update()
        {
            CheckHealth();
            currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
            foreach (IEnemy sprite in neck1)
                sprite.Update();
            foreach (IEnemy sprite in neck2)
                sprite.Update();
        }

        public void ChangeDirection()
        {
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
            game.Room.RemoveEnemy(this);
        }
    }
}
