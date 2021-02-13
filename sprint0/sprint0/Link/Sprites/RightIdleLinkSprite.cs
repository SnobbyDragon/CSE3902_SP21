using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    class RightIdleLinkSprite : ISprite
    {
        public Texture2D Texture { get => texture; set => texture = value; }
        public Vector2 Location { get => location; set => location = value; }

        private Texture2D texture;
        private Vector2 location;

        public RightIdleLinkSprite(Texture2D texture, Vector2 location)
        {
            this.texture = texture;
            this.location = location;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, location, new Rectangle(35, 11, 16, 16), Color.White);
        }

        public void Update() { }
    }
}