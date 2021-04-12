using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Angela Li
namespace sprint0
{
    public class HeartContainer : AbstractItem
    {
        public new PlayerItems PlayerItems { get => PlayerItems.HeartContainer; }

        public HeartContainer(Texture2D texture, Vector2 location)
        {
            width = height = 13;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            PickedUpDuration = -2;
            source = new Rectangle(25, 0, width, height);
        }
    }
}
