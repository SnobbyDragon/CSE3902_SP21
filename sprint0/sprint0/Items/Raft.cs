using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//Author: Stuti Shah
namespace sprint0
{
    public class Raft : AbstractItem
    {
        public new PlayerItems PlayerItems { get => PlayerItems.Raft; }
        private readonly int xOffset = 193, yOffset = 0;

        public Raft(Texture2D texture, Vector2 location)
        {
            width = 14;
            height = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            PickedUpDuration = -1;
            source = new Rectangle(xOffset, yOffset, width, height);
        }
    }
}