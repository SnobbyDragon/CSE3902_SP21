using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Stuti Shah
//Updated: 04/12/21 by shah.1440
namespace sprint0
{
    public class MagicalKey : AbstractItem, IItem
    {
        public new PlayerItems PlayerItems { get => PlayerItems.MagicalKey; }
        private readonly int xOffset = 248, yOffset = 0;

        public MagicalKey(Texture2D texture, Vector2 location)
        {
            width = 8;
            height = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            PickedUpDuration = -1;
            source = new Rectangle(xOffset, yOffset, width, height);
        }
    }
}