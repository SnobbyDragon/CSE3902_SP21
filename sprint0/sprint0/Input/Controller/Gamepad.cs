using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;


namespace sprint0
{
    class GamepadController : IController
    {
        Game1 game;
        private Dictionary<Buttons, ICommand> controllerMappings;
        private List<Buttons> previousPressedButtons;
        private HashSet<Buttons> movementButtons;
        public GamepadController(Game1 game)
        {
            this.game = game;
            controllerMappings = new Dictionary<Buttons, ICommand>();
            movementButtons = new HashSet<Buttons> { Buttons.RightThumbstickUp, Buttons.RightThumbstickDown, Buttons.RightThumbstickLeft, Buttons.RightThumbstickRight };
            previousPressedButtons = getPressedButtons(GamePad.GetState(Microsoft.Xna.Framework.PlayerIndex.One));

            RegisterCommand(Buttons.Back, new QuitCommand(game));
            RegisterCommand(Buttons.Start, new ResetCommand(game));
            RegisterCommand(Buttons.RightThumbstickUp, new UpCommand(game));
            RegisterCommand(Buttons.RightThumbstickDown, new DownCommand(game));
            RegisterCommand(Buttons.RightThumbstickLeft, new LeftCommand(game));
            RegisterCommand(Buttons.RightThumbstickRight, new RightCommand(game));
            RegisterCommand(Buttons.X, new SwordCommand(game));
            RegisterCommand(Buttons.RightTrigger, new OneCommand(game));
            RegisterCommand(Buttons.LeftTrigger, new TwoCommand(game));
            RegisterCommand(Buttons.RightShoulder, new ThreeCommand(game));

        }

        public List<Buttons> getPressedButtons(GamePadState state)
        {
            List<Buttons> pressedButtons = new List<Buttons>();
            foreach (Buttons button in Enum.GetValues(typeof(Buttons)))
            {
                if (state.IsButtonDown(button))
                {
                    pressedButtons[pressedButtons.Count] = button;
                }
            }
            return pressedButtons;
        }

        public void RegisterCommand(Buttons button, ICommand command)
        {
            controllerMappings.Add(button, command);
        }

        public void Update()
        {
            List<Buttons> pressedButtons = getPressedButtons(GamePad.GetState(Microsoft.Xna.Framework.PlayerIndex.One));

            foreach (Buttons button in pressedButtons)
                if (controllerMappings.ContainsKey(button) && (previousPressedButtons.IndexOf(button) == -1) || movementButtons.Contains(button))
                    controllerMappings[button].Execute();
            foreach (Buttons button in movementButtons)
                if (previousPressedButtons.IndexOf(button) > -1 && pressedButtons.IndexOf(button) == -1)
                    game.Room.Player.Stop();
            previousPressedButtons = pressedButtons;
        }
    }
}
