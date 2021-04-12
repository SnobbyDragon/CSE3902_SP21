using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Angela Li
namespace sprint0
{
    public class Meat : AbstractItem
    {
        private readonly int xOffset = 96, yOffset = 0;
        public new PlayerItems PlayerItems { get => PlayerItems.Food; }

        public Meat(Texture2D texture, Vector2 location)
        {
            width = 8;
            height = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            PickedUpDuration = -2;
            source = new Rectangle(xOffset, yOffset, width, height);
        }
    }
}
