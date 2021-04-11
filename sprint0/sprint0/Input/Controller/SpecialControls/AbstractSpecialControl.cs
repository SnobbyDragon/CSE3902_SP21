using System;
using Microsoft.Xna.Framework.Input;

namespace sprint0
{
    public abstract class AbstractSpecialControl
    {
        protected Keys[] keySequence;
        protected ICommand command;
        protected int currKey;

        public AbstractSpecialControl(ICommand command)
        {
            currKey = 0;
            this.command = command;
        }

        public void CheckKey(Keys key)
        {
            if (key == keySequence[currKey])
            {
                currKey++;
                if (currKey == keySequence.Length)
                {
                    currKey = 0;
                    command.Execute();
                }
            }
            else if (currKey > 0 && Keyboard.GetState().IsKeyUp(keySequence[currKey - 1]))
            {
                currKey = 0;
            }
        }
    }
}
