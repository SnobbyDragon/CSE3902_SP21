using System;
using System.Collections.Generic;
using System.Text;

//Author: Stuti Shah
//Updated: 03/15/21 by shah.1440
namespace sprint0
{
    public interface IHUDInventory : ISprite
    {
        public int CurrentNum { get; }
        void ResetNum();
        void ChangeNum(int change);
        void Increment();
        void Decrement();
    }
}
