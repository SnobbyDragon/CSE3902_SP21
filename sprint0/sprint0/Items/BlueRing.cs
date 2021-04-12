using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Angela Li
//Updated: 04/12/21 by shah.1440
namespace sprint0
{
    public class BlueRing : AbstractItem, IItem
    {
        private readonly int xOffset = 169, yOffset = 19;
        public new PlayerItems PlayerItems { get => PlayerItems.BlueRing; }

        public BlueRing(Texture2D texture, Vector2 location)
        {
            width = 7;
            height = 9;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            PickedUpDuration = -1;
            source = new Rectangle(xOffset, yOffset, width, height);
        }
    }
}
