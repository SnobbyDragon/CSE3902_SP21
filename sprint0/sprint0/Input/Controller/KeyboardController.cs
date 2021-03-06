﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace sprint0
{
    class KeyboardController : IController
    {
        private readonly Game1 game;
        private readonly Dictionary<Keys, ICommand> controllerMappings;
        private Keys[] previousPressedKeys;
        private readonly AbstractSpecialControl[] specialControls;
        private readonly HashSet<Keys> movementKeys;

        public KeyboardController(Game1 game)
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
            RegisterCommand(Keys.T, new ToggleTestModeCommand(game));
            RegisterCommand(Keys.Up, new UpCommand(game));
            RegisterCommand(Keys.Down, new DownCommand(game));
            RegisterCommand(Keys.Left, new LeftCommand(game));
            RegisterCommand(Keys.Right, new RightCommand(game));
            RegisterCommand(Keys.Z, new SwordCommand(game));
            RegisterCommand(Keys.N, new SwordCommand(game));
            RegisterCommand(Keys.D1, new OneCommand(game));
            RegisterCommand(Keys.D2, new TwoCommand(game));
            RegisterCommand(Keys.D3, new ThreeCommand(game));
            RegisterCommand(Keys.O, new OptionsCommand(game));
            RegisterCommand(Keys.Enter, new EnterCommand(game));
            RegisterCommand(Keys.D4, new FourCommand(game));
            RegisterCommand(Keys.E, new PauseCommand(game));
            RegisterCommand(Keys.Space, new StartGameCommand(game));
            RegisterCommand(Keys.F, new ChangeSwordCommand(game));
            RegisterCommand(Keys.X, new BItemCommand(game));
            RegisterCommand(Keys.G, new LeftItemCommand(game));
            RegisterCommand(Keys.H, new RightItemCommand(game));
            RegisterCommand(Keys.M, new ToggleMusicCommand(game));
            RegisterCommand(Keys.OemPeriod, new SkipSongCommand(game));
            RegisterCommand(Keys.OemComma, new ToggleSoundEffectsCommand());
            RegisterCommand(Keys.D5, new Note1Command(game));
            RegisterCommand(Keys.D6, new Note2Command(game));
            RegisterCommand(Keys.D7, new Note3Command(game));
            RegisterCommand(Keys.D8, new Note4Command(game));
            RegisterCommand(Keys.D9, new Note5Command(game));
            RegisterCommand(Keys.D0, new Note6Command(game));
            RegisterCommand(Keys.LeftShift, new JumpCommand(game));
            RegisterCommand(Keys.OemSemicolon, new SaveCommand(game));
            RegisterCommand(Keys.L, new LoadCommand(game));
            RegisterCommand(Keys.Y, new OpeningCommand(game));
            RegisterCommand(Keys.I, new InstructionCommand(game));

            specialControls = new AbstractSpecialControl[] { new CardiBControl(new CardiBCommand(game)),
                new OwlDeathControl(new OwlDeathCommand(game)), new FairyEnlargementControl(new FairyEnlargementCommand(game)) };
        }

        public void RegisterCommand(Keys key, ICommand command)
            => controllerMappings.Add(key, command);

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                if ((controllerMappings.ContainsKey(key) && (Array.IndexOf(previousPressedKeys, key) == -1)) || movementKeys.Contains(key))
                    controllerMappings[key].Execute();
                foreach (AbstractSpecialControl specialControl in specialControls)
                    specialControl.CheckKey(key);
            }
            foreach (Keys key in movementKeys)
                if (Array.IndexOf(previousPressedKeys, key) > -1 && Array.IndexOf(pressedKeys, key) == -1)
                    game.Room.Player.Stop();
            previousPressedKeys = pressedKeys;
        }
    }
}
