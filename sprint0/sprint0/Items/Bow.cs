
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Bow : IItem
    {
        public int PickedUpDuration { get; set; }
        private readonly int maxPickedUpDuration = 40;
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        public PlayerItems PlayerItems { get => PlayerItems.Bow; }
        private readonly int xOffset = 144, yOffset = 0, width = 8, height = 16;
        private Rectangle source;

        public Bow(Texture2D texture, Vector2 location)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            PickedUpDuration = -1;
            source = new Rectangle(xOffset, yOffset, width, height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (PickedUpDuration < maxPickedUpDuration)
                spriteBatch.Draw(Texture, Location, source, Color.White);
        }

        public void Update()
        {
            if (PickedUpDuration >= 0) PickedUpDuration++;
        }
    }
}