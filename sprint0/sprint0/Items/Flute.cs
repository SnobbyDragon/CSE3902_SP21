using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//Author: Stuti Shah
namespace sprint0
{
    public class Flute : AbstractItem
    {
        public new PlayerItems PlayerItems { get => PlayerItems.Flute; }
        private readonly int xOffset = 187, yOffset = 0;

        public Flute(Texture2D texture, Vector2 location)
        {
            width = 3;
            height = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            PickedUpDuration = -1;
            source = new Rectangle(xOffset, yOffset, width, height);
        }
    }
}