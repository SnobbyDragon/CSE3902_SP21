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
            RegisterCommand(Keys.Q, new QuitCommand(game));

            RegisterCommand(Keys.W, new UpCommand(game));
            RegisterCommand(Keys.S, new DownCommand(game));
            RegisterCommand(Keys.A, new LeftCommand(game));
            RegisterCommand(Keys.D, new RightCommand(game));
            RegisterCommand(Keys.Up, new UpCommand(game));
            RegisterCommand(Keys.Down, new DownCommand(game));
            RegisterCommand(Keys.Left, new LeftCommand(game));
            RegisterCommand(Keys.Right, new RightCommand(game));
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
