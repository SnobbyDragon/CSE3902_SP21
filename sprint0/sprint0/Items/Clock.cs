using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson
//Updated: 04/12/21 by shah.1440
namespace sprint0
{
    public class Clock : AbstractItem
    {
        private readonly int xOffset = 58, yOffset = 0;
        public override PlayerItems PlayerItems { get => PlayerItems.Clock; }

        public Clock(Texture2D texture, Vector2 location)
        {
            width = 13;
            height = 17;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            PickedUpDuration = -2;
            source = new Rectangle(xOffset, yOffset, width, height);
        }
    }
}
