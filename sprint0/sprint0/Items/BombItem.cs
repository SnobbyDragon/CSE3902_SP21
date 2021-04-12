using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Updated: 04/12/21 by shah.1440
namespace sprint0
{
    class BombItem : AbstractItem, IItem
    {
        public new PlayerItems PlayerItems { get => PlayerItems.Bomb; }
        private readonly int xOffset = 136, yOffset = 0;
        public BombItem(Texture2D texture, Vector2 location)
        {
            Texture = texture;
            width = 8;
            height = 14;
            PickedUpDuration = -2;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            source = new Rectangle(xOffset, yOffset, width, height);
        }
    }
}
