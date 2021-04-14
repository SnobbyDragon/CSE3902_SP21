// Author: Stuti Shah
using System.Collections.Generic;

namespace sprint0
{
    class BItemCommand : ICommand
    {
        private readonly Game1 game;
        private readonly Dictionary<PlayerItems, ICommand> commands;

        public BItemCommand(Game1 game)
        {
            this.game = game;
            commands = new Dictionary<PlayerItems, ICommand>
            {
                { PlayerItems.Arrow, new OneCommand(this.game) },
                { PlayerItems.SilverArrow, new OneCommand(this.game) },
                { PlayerItems.Bomb, new TwoCommand(this.game) },
                { PlayerItems.Boomerang, new ThreeCommand(this.game) },
                { PlayerItems.MagicalBoomerang, new ThreeCommand(this.game) },
                { PlayerItems.RedPotion, new PotionCommand(this.game, PlayerItems.RedPotion) },
                { PlayerItems.BluePotion, new PotionCommand(this.game, PlayerItems.BluePotion) },
                { PlayerItems.Food, new FoodCommand(this.game) },
                { PlayerItems.BlueCandle, new FourCommand(this.game) },
                { PlayerItems.RedCandle, new FourCommand(this.game) },
                { PlayerItems.MagicalRod, new RodCommand(this.game) }
            };
        }

        public void Execute()
        {
            if (game.stateMachine.GetState() == GameStateMachine.State.pause)
            {
                game.universalScreenManager.Update(GameStateMachine.State.pause);
                game.hudManager.SetBItem(game.universalScreenManager.PauseScreenManager.BItem());
                game.stateMachine.HandlePause();
            }
            else if (PlayOrTest() && Contains(game.hudManager.CurrentItem))
                commands[game.hudManager.CurrentItem].Execute();
        }
        private bool PlayOrTest()
            => game.stateMachine.GetState() != GameStateMachine.State.play || game.stateMachine.GetState() != GameStateMachine.State.test;
        private bool Contains(PlayerItems item) => commands.ContainsKey(item);
    }
}
