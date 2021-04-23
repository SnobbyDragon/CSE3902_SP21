using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Updated: 04/12/21 by shah.1440
namespace sprint0
{
    public class Bow : AbstractItem
    {
        public override PlayerItems PlayerItems { get => PlayerItems.Bow; }
        private readonly int xOffset = 144, yOffset = 0;

        public Bow(Texture2D texture, Vector2 location)
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