using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
namespace sprint0
{
    public class GleeokNeck : IEnemy
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;
        private IEnemy head;
        private int segmentNumber; // 0 = anchor to body, 3 = closest to head
        private Vector2 anchor;
        private Random rand;
        private readonly int xWiggleLimit = 2, yWiggleLimit = 1, wiggleDelay = 20;
        private int xWiggle, yWiggle, wiggleCount;
        private readonly int width = 8, height = 12;

        public GleeokNeck(Texture2D texture, Vector2 anchor, IEnemy head, int segmentNumber)
        {
            Texture = texture;
            source = new Rectangle(271, 13, width, height);
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
            Vector2 dist = head.Location.Location.ToVector2() - anchor; //TODO clean up?
            Vector2 loc = anchor + dist / 4 * segmentNumber;
            Location = new Rectangle((int)loc.X, (int)loc.Y, width, height);
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
                {
                    wiggleCount++;
                }
            }
        }
    }
}
