using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//Author: Stuti Shah

namespace sprint0
{
    public class BookOfMagic : AbstractItem
    {
        public new PlayerItems PlayerItems { get => PlayerItems.BookOfMagic; }
        private readonly int xOffset = 232, yOffset = 0;

        public BookOfMagic(Texture2D texture, Vector2 location)
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