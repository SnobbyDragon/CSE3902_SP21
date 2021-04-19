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
        private readonly int totalFrames = 4;

        public DownWoodSwordSprite(Texture2D texture, Vector2 location, PlayerItems sword)
        {
            if (sword == PlayerItems.WhiteSword) xOffset += 93;
            else if (sword == PlayerItems.MagicalSword) xOffset += 187;
            this.texture = texture;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            sources = SpritesheetHelper.GetFramesH(xOffset, yOffset, width, height, totalFrames);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (currFrame < totalFrames) spriteBatch.Draw(Texture, Location, sources[currFrame], Color.White);
        }

        public void Update()
        {
            slow++;
            if (slow % (totalFrames * 2) == 0) currFrame += 1;
        }
    }
}