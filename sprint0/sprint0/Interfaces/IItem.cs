using System;
namespace sprint0
{
    public interface IItem : ISprite
    {
        public int PickedUpDuration { get; set; } // starting -1 = special animation to pick up; starting -2 = no special animation
    }
}
