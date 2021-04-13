using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class GanonTriforceAshes : IItem
    {
        public int PickedUpDuration { get; set; }
        private readonly int maxPickedUpDuration = 40;
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly List<Rectangle> sources;
        private readonly int width, height;
        private int currFrame;

        private readonly int xOffset = 312, yOffset = 171, size = 16, totalFrames = 2, repeatedFrames = 16;

        private readonly Game1 game;
        public PlayerItems PlayerItems { get => PlayerItems.Triforce; }
        public PlayerItems SecondaryType { get => PlayerItems.None; }
        public GanonTriforceAshes(Texture2D texture, Vector2 location, Game1 gm)
        {
            this.game = gm;
            width = height = 10;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            PickedUpDuration = -1;
            sources = SpritesheetHelper.GetFramesV(xOffset, yOffset, size, size, totalFrames);
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