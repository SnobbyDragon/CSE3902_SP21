using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Gleeok : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int xOffset = 196, yOffset = 11, width = 24, height = 32;
        private List<Rectangle> sources;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;
        private List<ISprite> head1, head2;

        public Gleeok(Texture2D texture, Vector2 location)
        {
            Location = location;
            Texture = texture;
            currFrame = 0;
            totalFrames = 3;
            repeatedFrames = 8;
            sources = new List<Rectangle>();
            for (int frame = 0; frame < totalFrames; frame++)
            {
                sources.Add(new Rectangle(xOffset + frame * (width + 1), yOffset, width, height));
            };
            sources.Add(new Rectangle(xOffset + width + 1, yOffset, width, height)); // animation = left middle right middle ...

            head1 = new List<ISprite>
            {
                new GleeokNeck(Texture, Location), //TODO change location and make more necks segments
                new GleeokHead(Texture, Location)
            };
            head2 = new List<ISprite>
            {
                new GleeokNeck(Texture, Location), //TODO change location and make more necks segments
                new GleeokHead(Texture, Location)
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, sources[currFrame / repeatedFrames], Color.White);
            foreach (ISprite sprite in head1)
                sprite.Draw(spriteBatch);
            foreach (ISprite sprite in head2)
                sprite.Draw(spriteBatch);
        }

        public void Update()
        {
            // animates all the time for now
            currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
            foreach (ISprite sprite in head1)
                sprite.Update();
            foreach (ISprite sprite in head2)
                sprite.Update();
        }
    }
}
