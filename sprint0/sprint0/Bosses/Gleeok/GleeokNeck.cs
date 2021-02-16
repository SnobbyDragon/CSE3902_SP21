using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class GleeokNeck : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;
        private ISprite head;
        private int segmentNumber; // 0 = anchor to body, 3 = closest to head
        private Vector2 anchor;
        private Random rand;
        private readonly int xWiggleLimit = 2, yWiggleLimit = 1, wiggleDelay = 20;
        private int xWiggle, yWiggle, wiggleCount;

        public GleeokNeck(Texture2D texture, Vector2 anchor, ISprite head, int segmentNumber)
        {
            Texture = texture;
            source = new Rectangle(271, 13, 8, 12);
            this.head = head;
            this.segmentNumber = segmentNumber;
            this.anchor = anchor;
            rand = new Random();
            wiggleCount = rand.Next(0, 20);
            xWiggle = yWiggle = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, source, Color.White);
        }

        public void Update()
        {
            Vector2 dist = head.Location - anchor;
            Location = anchor + dist / 4 * segmentNumber;
            if (segmentNumber > 0)
            {
                Location += new Vector2(xWiggle, yWiggle);
                if (wiggleCount == wiggleDelay)
                {
                    xWiggle = rand.Next(-xWiggleLimit, xWiggleLimit);
                    yWiggle = rand.Next(-yWiggleLimit, yWiggleLimit);
                    wiggleCount = 0;
                }
                else
                {
                    wiggleCount++;
                }
            }
        }
    }
}
