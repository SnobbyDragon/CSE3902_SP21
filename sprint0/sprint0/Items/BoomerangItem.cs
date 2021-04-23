using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Angela Li
//Updated: 04/12/21 by shah.1440
namespace sprint0
{
    public class BoomerangItem : AbstractItem
    {
        public override PlayerItems PlayerItems { get => PlayerItems.Boomerang; }
        public override PlayerItems SecondaryType { get => PlayerItems.BoomerangType; }
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
