using System;
namespace sprint0
{
    public interface IItem : ISprite
    {
        public PlayerItems PlayerItems { get; }
        public int PickedUpDuration { get; set; }
    }
}
