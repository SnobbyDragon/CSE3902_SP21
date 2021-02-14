﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace sprint0
{
    class ResetCommand : ICommand
    {
        Game1 game;
        public ResetCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            // reset game timer
            game.ResetElapsedTime();

            //reset ItemIndex
            game.itemIndex = 0;

            //reset enemyNPCIndex
            game.enemyNPCIndex = 0;

            //reset roomElementsIndex
            game.roomElementsIndex = 0;

            //reset player state
            game.Player.Position = new Vector2(200, 250);
            game.Player.State = new UpIdleState(game.Player);
        }
    }
}