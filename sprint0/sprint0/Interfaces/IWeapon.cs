using System;
using System.Collections.Generic;
using System.Text;

namespace sprint0
{
    public interface IWeapon : ISprite
    {
        public int Damage { get; }
        public bool IsAlive();
    }
}
