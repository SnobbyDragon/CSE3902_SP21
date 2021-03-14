using System;
namespace sprint0
{
    public interface IBlock : ISprite
    {
        public bool IsWalkable(); // true => link can walk on it
        public bool IsMovable(); // true => link can push it
    }
}
