using System;
namespace sprint0
{
    public interface IItem : ISprite
    {
        public bool PickedUp { get; set; }
    }
}
