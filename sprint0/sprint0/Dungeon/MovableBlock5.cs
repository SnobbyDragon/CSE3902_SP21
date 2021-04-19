using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class MovableBlock5 : AbstractBlock, IBlock
    {
        private Vector2 homeLocation;
        private bool isMovable;

        public MovableBlock5(Texture2D texture, Vector2 location)
        {
            isMovable = true;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            homeLocation = Location.Location.ToVector2();
            Texture = texture;
            source = new Rectangle(1001, 11, width, height);
        }
        public override bool IsMovable() => isMovable;
        public override void SetIsMovable()
        {
            Vector2 changeLoc = Location.Location.ToVector2() - homeLocation;
            if (changeLoc.Length() >= Game1.Scale * width) isMovable = false;
        }
    }
}