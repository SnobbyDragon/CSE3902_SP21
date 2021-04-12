using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//Author: Stuti Shah
namespace sprint0
{
    public class PowerBracelet : AbstractItem
    {
        public new PlayerItems PlayerItems { get => PlayerItems.PowerBracelet; }
        private readonly int xOffset = 176, yOffset = 1;

        public PowerBracelet(Texture2D texture, Vector2 location)
        {
            width = 9;
            height = 14;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            PickedUpDuration = -1;
            source = new Rectangle(xOffset, yOffset, width, height);
        }
    }
}