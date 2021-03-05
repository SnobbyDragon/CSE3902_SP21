using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    class DownIdleLinkSprite : ISprite
    {
        public Texture2D Texture { get => texture; set => texture = value; }
        public Rectangle Location { get; set; }

        private Texture2D texture;
        private Rectangle sourceRectangle;

        private readonly int size = 16;

        public DownIdleLinkSprite(Texture2D texture, Vector2 location)
        {
            this.texture = texture;
            Location = new Rectangle((int)location.X, (int)location.Y, size, size);
            sourceRectangle = new Rectangle(1, 11, size, size);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Location, sourceRectangle, Color.White);
        }

        public void Update() { }

        public Collision GetCollision(ISprite other)
        {
            return Collision.None;
        }
    }
}