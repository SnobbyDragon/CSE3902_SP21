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
        public UpWoodSwordSprite(Texture2D texture, Vector2 location)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, width, height);
            this.texture = texture;
            sources = GetFrames();
            /*
             * Ugly pixel math is unavoidable with the current spritesheet
             */
            locations = new List<Vector2>
            {
                location,
                new Vector2(Location.X, Location.Y - 11),
                new Vector2(Location.X, Location.Y - 10),
                new Vector2(Location.X, Location.Y - 3)
            };

        }

        private List<Rectangle> GetFrames()
        {
            /*
             * Ugly pixel math is unavoidable with the current spritesheet
             */
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
            if (currFrame < 4) //TODO use Location rectangle
            {
                spriteBatch.Draw(Texture, locations[currFrame], sources[currFrame], Color.White);
            }
        }

        public void Update() {
            slow++;
            if (slow % 8 == 0)
            {
                currFrame += 1;
            }
        }
    }
}