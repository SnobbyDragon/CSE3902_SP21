using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    class RightWoodSwordSprite : ISprite
    {

        public Texture2D Texture { get; set; }
        public Rectangle Location { get; set; }
        private readonly List<Rectangle> sources;

        private int currFrame;
        private int slow;
        private readonly int xOffset = 1, yOffset = 77;
        private int width = 16;
        private readonly int height = 16;

        public RightWoodSwordSprite(Texture2D texture, Vector2 location)
        {
            Texture = texture;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            sources = GetFrames();
        }

        private List<Rectangle> GetFrames()
        {
            int xPos, yPos;
            List<Rectangle> sources = new List<Rectangle>();
            xPos = xOffset;
            yPos = yOffset;
            sources.Add(new Rectangle(xPos, yPos, width, height));
            xPos += width + 1;
            width = 27;
            sources.Add(new Rectangle(xPos, yPos, width, height));
            xPos += width + 1;
            width = 16 + 7;
            sources.Add(new Rectangle(xPos, yPos, width, height));
            xPos += width + 1;
            width = 16 + 3;
            sources.Add(new Rectangle(xPos, yPos, width, height));
            return sources;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (currFrame < 4)
            {
                Location = new Rectangle(Location.X, Location.Y, (int)(sources[currFrame].Width * Game1.Scale), (int)(sources[currFrame].Height * Game1.Scale)); // changes size w/frame
                spriteBatch.Draw(Texture, Location, sources[currFrame], Color.White);
            }
        }

        public void Update()
        {
            slow++;
            if (slow % 8 == 0)
            {
                currFrame += 1;
            }
        }
    }
}