using System;
namespace sprint0
{
    public interface IItem : ISprite
    {
        public int PickedUpDuration { get; set; }
    }
}
