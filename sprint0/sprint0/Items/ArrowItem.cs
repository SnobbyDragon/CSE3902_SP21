using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Updated: 04/12/21 by shah.1440
namespace sprint0
{
    class ArrowItem : AbstractItem
    {
        public override PlayerItems PlayerItems { get => PlayerItems.Arrow; }
        public override PlayerItems SecondaryType { get => PlayerItems.ArrowType; }
        private readonly int xOffset = 154, yOffset = 0;

        public ArrowItem(Texture2D texture, Vector2 location)
        {
            width = 5;
            height = 16;
            PickedUpDuration = -2;
            Texture = texture;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            source = new Rectangle(xOffset, yOffset, width, height);
        }
    }
}
