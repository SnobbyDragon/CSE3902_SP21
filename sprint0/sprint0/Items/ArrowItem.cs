using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace sprint0
{
    class ArrowItem : IItem
    {
        public int PickedUpDuration { get; set; }
        public Rectangle Location { get; set; }
        private readonly Texture2D texture;
        private readonly int width, height;
        private Rectangle source;
        private readonly int maxPickedUpDuration = 40;
        public PlayerItems PlayerItems { get => PlayerItems.Arrow; }

        public ArrowItem(Texture2D texture, Vector2 location)
        {
            this.texture = texture;
            width = 5;
            height = 16;
            PickedUpDuration = -2;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            source = new Rectangle(154, 0, width, height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (PickedUpDuration < maxPickedUpDuration)
                spriteBatch.Draw(texture, Location, source, Color.White);
        }

        public void Update()
        {
            if (PickedUpDuration >= 0) PickedUpDuration++;
        }
    }
}
