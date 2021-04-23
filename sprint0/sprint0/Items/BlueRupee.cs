using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Angela Li
//Updated: 04/12/21 by shah.1440
namespace sprint0
{
    public class BlueRupee : AbstractItem
    {
        public static int Value { get; } = 5;
        private readonly List<Rectangle> sources;
        private readonly int xOffset = 72, yOffset = 0;
        private int currFrame;
        private readonly int totalFrames = 2, repeatedFrames = 8;
        public override PlayerItems PlayerItems { get => PlayerItems.BlueRupee; }

        public BlueRupee(Texture2D texture, Vector2 location)
        {
            width = 8;
            height = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            sources = SpritesheetHelper.GetFramesV(xOffset, yOffset, width, height, totalFrames);
            PickedUpDuration = -2;
            currFrame = 0;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (PickedUpDuration < maxPickedUpDuration)
                spriteBatch.Draw(Texture, Location, sources[currFrame / repeatedFrames], Color.White);
        }

        public override void Update()
        {
            currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
            if (PickedUpDuration >= 0) PickedUpDuration++;
        }
    }
}
