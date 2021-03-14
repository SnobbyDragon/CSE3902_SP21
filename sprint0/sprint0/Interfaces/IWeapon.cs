using System;
using System.Collections.Generic;
using System.Text;

namespace sprint0
{
    public interface IWeapon : ISprite
    {
        int Damage { get; }

        bool IsAlive();
    }
}
