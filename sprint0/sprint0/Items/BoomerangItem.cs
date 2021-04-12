using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Angela Li
namespace sprint0
{
    public class BoomerangItem : AbstractItem
    {
        public new PlayerItems PlayerItems { get => PlayerItems.Boomerang; }
        private readonly int xOffset = 129, yOffset = 3;

        public BoomerangItem(Texture2D texture, Vector2 location)
        {
            width = 5;
            height = 8;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            PickedUpDuration = -1;
            source = new Rectangle(xOffset, yOffset, width, height);
        }
    }
}
