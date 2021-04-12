using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Angela Li
//Updated: 04/12/21 by shah.1440
namespace sprint0
{
    public class BlueMap : AbstractItem, IItem
    {
        private readonly int xOffset = 88, yOffset = 16;
        public new PlayerItems PlayerItems { get => PlayerItems.Letter; }

        public BlueMap(Texture2D texture, Vector2 location)
        {
            width = 8;
            Texture = texture;
            height = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            PickedUpDuration = -1;
            source = new Rectangle(xOffset, yOffset, width, height);
        }
    }
}
