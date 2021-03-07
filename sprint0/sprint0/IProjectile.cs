using System;
namespace sprint0
{
    public interface IProjectile : ISprite
    {
        public IEntity Source { get; set; }
    }
}
