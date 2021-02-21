using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    class LeftWoodSwordSprite : ISprite
    {
        public Texture2D Texture { get => texture; set => texture = value; }
        public Vector2 Location { get => location; set => location = value; }
        private readonly List<Rectangle> sources;
        private Texture2D texture;
        private Vector2 location;
        private int currFrame;
        private int slow;
        private readonly int xOffset = 1, yOffset = 77;
        private int width = 16;
        private readonly int height = 16;

        public LeftWoodSwordSprite(Texture2D texture, Vector2 location)
        {

            this.texture = texture;
            this.location = location;
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
                Rectangle destination = new Rectangle((int)location.X, (int)location.Y, 16, 16);
                spriteBatch.Draw(Texture, destination, sources[currFrame], Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);
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