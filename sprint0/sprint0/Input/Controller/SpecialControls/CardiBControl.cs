using System;
using Microsoft.Xna.Framework.Input;

namespace sprint0
{
    public class CardiBControl : AbstractSpecialControl
    {
        public CardiBControl(ICommand command) : base(command)
        {
            keySequence = new Keys[] { Keys.C, Keys.A, Keys.R, Keys.D, Keys.I, Keys.Space, Keys.B };
        }
    }
}
