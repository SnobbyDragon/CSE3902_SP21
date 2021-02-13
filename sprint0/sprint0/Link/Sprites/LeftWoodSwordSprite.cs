using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    class LeftWoodSwordSprite : ISprite
    {
        public Texture2D Texture { get => texture; set => texture = value; }
        public Vector2 Location { get => location; set => location = value; }

        private Texture2D texture;
        private Vector2 location;

        public LeftWoodSwordSprite(Texture2D texture, Vector2 location)
        {
            this.texture = texture;
            this.location = location;
        }

        private List<Rectangle> GetFrames(int xPos, int yPos, int numFrames)
        {
            List<Rectangle> sources = new List<Rectangle>();
            int width = 8;
            int height = 16;
            for (int i = 0; i < numFrames; i++)
            {
                sources.Add(new Rectangle(xPos, yPos, width, height));
                xPos += width + 1;
            }
            return sources;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, location, new Rectangle(1, 11, 16, 16), Color.White);
        }

        public void Update() { }
    }
}