using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/*
 * Last updated: 2/21/21 by urick.9
 */
namespace sprint0
{
    class UpWoodSwordSprite : ISprite
    {
        public Texture2D Texture { get => texture; set => texture = value; }
        public Rectangle Location { get; set; }
        private readonly List<Rectangle> sources;
        private Texture2D texture;
        private int currFrame;
        private int slow;
        private readonly int xOffset = 1, yOffset = 109;
        private int width = 0, height = 0;
        private readonly List<Vector2> locations;
        private readonly List<int> ySizes;

        public UpWoodSwordSprite(Texture2D texture, Vector2 location)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            sources = GetFrames();
            locations = new List<Vector2>
            {
                location,
                new Vector2(Location.X, Location.Y - 11 * Game1.Scale),
                new Vector2(Location.X, Location.Y - 10 * Game1.Scale),
                new Vector2(Location.X, Location.Y - 3 * Game1.Scale)
            };
            ySizes = new List<int>
            {
                16,
                16+11,
                16+10,
                16+3
            };

        }

        private List<Rectangle> GetFrames()
        {
            int xPos, yPos;
            List<Rectangle> sources = new List<Rectangle>();
            width = 16;
            height = 16;
            xPos = xOffset;
            yPos = yOffset;
            sources.Add(new Rectangle(xPos, yPos, width, height));
            xPos += width + 1;
            yPos = 97;
            height = 28;
            sources.Add(new Rectangle(xPos, yPos, width, height));
            xPos += width + 1;
            yPos = 98;
            height = 27;
            sources.Add(new Rectangle(xPos, yPos, width, height));
            xPos += width + 1;
            yPos = 106;
            height = 19;
            sources.Add(new Rectangle(xPos, yPos, width, height));
            return sources;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (currFrame < 4)
            {
                Location = new Rectangle((int)locations[currFrame].X, (int)locations[currFrame].Y, (int)(width * Game1.Scale), (int)(ySizes[currFrame] * Game1.Scale));
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