using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Stuti Shah
//Updated: 04/12/21 by shah.1440
namespace sprint0
{
    public class StepLadder : AbstractItem, IItem
    {
        public new PlayerItems PlayerItems { get => PlayerItems.StepLadder; }
        private readonly int xOffset = 208, yOffset = 0;

        public StepLadder(Texture2D texture, Vector2 location)
        {
            width = 16;
            height = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            PickedUpDuration = -1;
            source = new Rectangle(xOffset, yOffset, width, height);
        }
    }
}