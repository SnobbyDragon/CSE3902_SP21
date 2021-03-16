using System;
namespace sprint0
{
    public interface IBlock : ISprite
    {
        public bool IsWalkable();
        public bool IsMovable();
        public void SetIsMovable();
    }
}
