using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    class LeftIdleLinkSprite : ISprite
    {
        public Texture2D Texture { get => texture; set => texture = value; }
        public Vector2 Location { get => location; set => location = value; }

        private Texture2D texture;
        private Vector2 location;
        private Rectangle sourceRectangle;

        public LeftIdleLinkSprite(Texture2D texture, Vector2 location)
        {
            this.texture = texture;
            this.location = location;
            sourceRectangle = new Rectangle(35, 11, 16, 16);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destination = new Rectangle((int) location.X, (int) location.Y, 16, 16);
            spriteBatch.Draw(texture, destination, sourceRectangle, Color.White, 0, new Vector2(0,0), SpriteEffects.FlipHorizontally, 0);
        }

        public void Update() { }
    }
}
