using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    class RightWoodSwordSprite : ISprite
    {

        private Rectangle source;
        public Texture2D Texture { get => texture; set => texture = value; }
        public Vector2 Location { get => location; set => location = value; }
        private List<Rectangle> sources;
        private Texture2D texture;
        private Vector2 location;
        private int currFrame;
        private int slow;
        private readonly int xOffset = 1, yOffset = 77;
        private int width = 16, height = 16;
        public RightWoodSwordSprite(Texture2D texture, Vector2 location)
        {

            this.texture = texture;
            this.location = location;
            sources = GetFrames(xOffset, yOffset);

        }

        private List<Rectangle> GetFrames(int xPos, int yPos)
        {
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