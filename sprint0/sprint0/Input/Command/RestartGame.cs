// Author: Jacob Urick
/*
 *  Note well: this class serves a different, albeit similar, purpose to ResetCommand. 
 */
namespace sprint0
{
    class RestartCommand : ICommand
    {
        private readonly Game1 game;

        public RestartCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.stateMachine.HandleRunItBack();
        }
    }
}
