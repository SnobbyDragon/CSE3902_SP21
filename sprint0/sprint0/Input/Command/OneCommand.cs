﻿// Author: Jacob Urick
namespace sprint0
{
    class OneCommand : ICommand
    {
        private readonly Game1 game;

        public OneCommand(Game1 game) => this.game = game;

        public void Execute()
        {
            game.stateMachine.HandleLevelSelectOne();
            if (game.hudManager.HasBowAndArrow() || game.stateMachine.GetState().Equals(GameStateMachine.State.test))
            {
                game.Room.Player.CurrentItem = PlayerItems.Arrow;
                game.Room.Player.HandleItem();
            }
        }
    }
}
