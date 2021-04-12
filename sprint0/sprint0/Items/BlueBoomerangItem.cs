using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

//Author: Angela Li
namespace sprint0
{
    public class BlueBoomerangItem : AbstractItem, IItem
    {
        private readonly int xOffset = 129, yOffset = 19;
        public new PlayerItems PlayerItems { get => PlayerItems.MagicalBoomerang; }

        public BlueBoomerangItem(Texture2D texture, Vector2 location)
        {
            width = 5;
            height = 8;
            Texture = texture;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            PickedUpDuration = -1;
            source = new Rectangle(xOffset, yOffset, width, height);
        }
    }
}
