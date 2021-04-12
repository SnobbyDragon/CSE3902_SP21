using System;
using Microsoft.Xna.Framework.Input;

namespace sprint0
{
    public class OwlDeathControl : AbstractSpecialControl
    {
        public OwlDeathControl(ICommand command) : base(command)
            => keySequence = new Keys[] { Keys.D5, Keys.D6, Keys.D6, Keys.D7, Keys.D0, Keys.D8 };
    }
}
