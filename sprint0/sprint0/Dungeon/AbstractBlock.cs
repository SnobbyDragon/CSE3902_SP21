using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace sprint0
{
    public abstract class AbstractBlock : IBlock
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        protected Rectangle source;
        protected int width, height;

        public AbstractBlock() => width = height = 16;
        public virtual void Draw(SpriteBatch spriteBatch)
            => spriteBatch.Draw(Texture, Location, source, Color.White);
        public virtual void Update() { }
        public virtual bool IsWalkable() => false;
        public virtual bool IsMovable(Direction dir) => false;
        public virtual void SetIsMovable() => throw new NotImplementedException();
    }
}
