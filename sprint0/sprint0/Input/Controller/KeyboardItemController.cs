using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace sprint0
{
    class KeyboardItemController : IController
    {
        private readonly Game1 game;
        private readonly Dictionary<Keys, ICommand> controllerMappings;
        private Keys[] previousPressedKeys;
        private readonly HashSet<Keys> movementKeys;

        public KeyboardItemController(Game1 game)
        {
            this.game = game;
            controllerMappings = new Dictionary<Keys, ICommand>();
            movementKeys = new HashSet<Keys> { Keys.W, Keys.A, Keys.S, Keys.D, Keys.Up, Keys.Down, Keys.Left, Keys.Right };
            previousPressedKeys = Keyboard.GetState().GetPressedKeys();
            RegisterCommand(Keys.Q, new QuitCommand(game));
            RegisterCommand(Keys.R, new ResetCommand(game));
            RegisterCommand(Keys.C, new CreditsCommand(game));
            RegisterCommand(Keys.W, new UpCommand(game));
            RegisterCommand(Keys.S, new DownCommand(game));
            RegisterCommand(Keys.A, new LeftCommand(game));
            RegisterCommand(Keys.D, new RightCommand(game));
            RegisterCommand(Keys.Up, new UpCommand(game));
            RegisterCommand(Keys.Down, new DownCommand(game));
            RegisterCommand(Keys.Left, new LeftCommand(game));
            RegisterCommand(Keys.Right, new RightCommand(game));
            RegisterCommand(Keys.Z, new SwordCommand(game));
            RegisterCommand(Keys.N, new SwordCommand(game));
            RegisterCommand(Keys.D1, new OneCommand(game));
            RegisterCommand(Keys.D2, new TwoCommand(game));
            RegisterCommand(Keys.D3, new ThreeCommand(game));
            RegisterCommand(Keys.D4, new FourCommand(game));
            RegisterCommand(Keys.E, new PauseCommand(game));
            RegisterCommand(Keys.Space, new ToggleTestModeCommand(game));
            RegisterCommand(Keys.B, new BItemCommand(game));

            RegisterCommand(Keys.M, new ToggleMusicCommand(game));
            RegisterCommand(Keys.OemPeriod, new SkipSongCommand(game));
            RegisterCommand(Keys.OemComma, new ToggleSoundEffectsCommand());
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in pressedKeys)
                if (controllerMappings.ContainsKey(key) && (Array.IndexOf(previousPressedKeys, key) == -1) || movementKeys.Contains(key))
                    controllerMappings[key].Execute();
            foreach (Keys key in movementKeys)
                if (Array.IndexOf(previousPressedKeys, key) > -1 && Array.IndexOf(pressedKeys, key) == -1)
                    game.Room.Player.Stop();
            previousPressedKeys = pressedKeys;
        }
    }
}
