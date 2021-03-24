using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Angela Li
namespace sprint0
{
    public class BlueRupee : IItem
    {
        public static int Value { get; } = 5;
        public int PickedUpDuration { get; set; }
        private readonly int maxPickedUpDuration = 40;
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly List<Rectangle> sources;
        private readonly int xOffset = 72, yOffset = 0, width = 8, height = 16;
        private int currFrame;
        private readonly int totalFrames = 2, repeatedFrames = 8;

        public BlueRupee(Texture2D texture, Vector2 location)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            sources = SpritesheetHelper.GetFramesV(xOffset, yOffset, width, height, totalFrames);
            PickedUpDuration = -2;
            currFrame = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (PickedUpDuration < maxPickedUpDuration)
                spriteBatch.Draw(Texture, Location, sources[currFrame / repeatedFrames], Color.White);
        }

        public void Update()
        {
            currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
            if (PickedUpDuration >= 0) PickedUpDuration++;
        }
    }
}
