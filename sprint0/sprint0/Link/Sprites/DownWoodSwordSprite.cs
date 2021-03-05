using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    class DownWoodSwordSprite : ISprite
    {

        public Texture2D Texture { get => texture; set => texture = value; }
        public Rectangle Location { get; set; }
        private readonly List<Rectangle> sources;
        private Texture2D texture;
        
        private int currFrame;
        private int slow;
        private readonly int xOffset = 1, yOffset = 47;
        private readonly int width = 16;
        private readonly int height = 30;

        public DownWoodSwordSprite(Texture2D texture, Vector2 location)
        {

            this.texture = texture;
            Location = new Rectangle((int)location.X, (int)location.Y, width, height);
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
            sources.Add(new Rectangle(xPos, yPos, width, height));
            xPos += width + 1;
            sources.Add(new Rectangle(xPos, yPos, width, height));
            xPos += width + 1;
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

        public Collision GetCollision(ISprite other)
        {
            return Collision.None;
        }
    }
}