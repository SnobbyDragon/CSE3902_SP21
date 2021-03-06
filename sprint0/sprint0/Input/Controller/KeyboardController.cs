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
        private Keys[] previousPressedKeys;
        private HashSet<Keys> movementKeys;
        public KeyboardController(Game1 game)
        {
            this.game = game;
            controllerMappings = new Dictionary<Keys, ICommand>();
            movementKeys = new HashSet<Keys> { Keys.W, Keys.A, Keys.S, Keys.D, Keys.Up, Keys.Down, Keys.Left, Keys.Right };
            previousPressedKeys = Keyboard.GetState().GetPressedKeys();
            RegisterCommand(Keys.Q, new QuitCommand(game));
            RegisterCommand(Keys.R, new ResetCommand(game));
            RegisterCommand(Keys.W, new UpCommand(game));
            RegisterCommand(Keys.S, new DownCommand(game));
            RegisterCommand(Keys.A, new LeftCommand(game));
            RegisterCommand(Keys.D, new RightCommand(game));
            RegisterCommand(Keys.Up, new UpCommand(game));
            RegisterCommand(Keys.Down, new DownCommand(game));
            RegisterCommand(Keys.Left, new LeftCommand(game));
            RegisterCommand(Keys.Right, new RightCommand(game));
            RegisterCommand(Keys.U, new ItemPreviousSpriteCommand(game));
            RegisterCommand(Keys.I, new ItemNextSpriteCommand(game));
            //RegisterCommand(Keys.O, new EnemyNPCPreviousSpriteCommand(game)); not compatible with new IEnemy
            //RegisterCommand(Keys.P, new EnemyNPCNextSpriteCommand(game));
            RegisterCommand(Keys.T, new RoomElementPreviousSpriteCommand(game));
            RegisterCommand(Keys.Y, new RoomElementNextSpriteCommand(game));
            RegisterCommand(Keys.Z, new SwordCommand(game));
            RegisterCommand(Keys.N, new SwordCommand(game));
            RegisterCommand(Keys.E, new DamageCommand(game));
            RegisterCommand(Keys.D1, new OneCommand(game));
            RegisterCommand(Keys.D2, new TwoCommand(game));
            RegisterCommand(Keys.D3, new ThreeCommand(game));

            /* NOTE:
             * change room; commented out for now 
             * since the corresponding code in the game class is commented out
             */
            //RegisterCommand(Keys.X, new PreviousRoomCommand(game));
            //RegisterCommand(Keys.C, new NextRoomCommand(game));
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
                    game.Player.Stop();
            previousPressedKeys = pressedKeys;
        }
    }
}
