using System;
using Microsoft.Xna.Framework.Input;

namespace sprint0
{
    public class FairyEnlargementControl : AbstractSpecialControl
    {
        public FairyEnlargementControl(ICommand command) : base(command)
            => keySequence = new Keys[] { Keys.D8, Keys.D7, Keys.D6, Keys.D5 };
    }
}
