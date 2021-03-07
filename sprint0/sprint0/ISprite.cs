using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public interface ISprite : IEntity
    {
        public Rectangle Location { get; set; }

        public void Update();
        public void Draw(SpriteBatch spriteBatch);
    }
}
