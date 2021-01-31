using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace sprint0
{
    class KeyboardController : IController
    {
        Game1 game;
        private Dictionary<Keys, ICommand> controllerMappings;
        public KeyboardController(Game1 game)
        {
            this.game = game;
            controllerMappings = new Dictionary<Keys, ICommand>();
            RegisterCommand(Keys.D0, new QuitCommand(game));
            RegisterCommand(Keys.D1, new NonMovingNonAnimatedCommand(game));
            RegisterCommand(Keys.D2, new NonMovingAnimatedCommand(game));
            RegisterCommand(Keys.D3, new MovingNonAnimatedCommand(game));
            RegisterCommand(Keys.D4, new MovingAnimatedCommand(game));
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                if (controllerMappings.ContainsKey(key))
                    controllerMappings[key].Execute();
            }
        }
    }
}
