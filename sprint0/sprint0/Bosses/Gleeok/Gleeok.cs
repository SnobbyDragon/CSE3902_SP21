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
        private List<Rectangle> sources;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;
        private List<IEnemy> neck1, neck2;

        public Gleeok(Texture2D texture, Vector2 location, Game1 game)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, width, height);
            Texture = texture;
            this.game = game;
            currFrame = 0;
            totalFrames = 3;
            repeatedFrames = 12;
            sources = new List<Rectangle>();
            for (int frame = 0; frame < totalFrames; frame++)
            {
                sources.Add(new Rectangle(xOffset + frame * (width + 1), yOffset, width, height));
            };
            sources.Add(new Rectangle(xOffset + width + 1, yOffset, width, height)); // animation = left middle right middle ...

            neck1 = generateNeck();
            neck2 = generateNeck();
        }

        public List<IEnemy> generateNeck()
        {
            List<IEnemy> neck = new List<IEnemy>();
            Vector2 anchor = Location.Location.ToVector2() + new Vector2(width / 2 - 4, height - 6);
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
            // animates all the time for now
            currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
            foreach (IEnemy sprite in neck1)
                sprite.Update();
            foreach (IEnemy sprite in neck2)
                sprite.Update();
        }

        public Collision GetCollision(ISprite other)
        {   //TODO
            return Collision.None;
        }
    }
}
