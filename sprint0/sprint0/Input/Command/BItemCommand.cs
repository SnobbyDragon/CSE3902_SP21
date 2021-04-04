// Author: Stuti Shah
using System.Collections.Generic;

namespace sprint0
{
    class BItemCommand : ICommand
    {
        private readonly Game1 game;
        private readonly Dictionary<PlayerItems, ICommand> commands;
        private PlayerItems BItem;

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
                { PlayerItems.RedPotion, new PotionCommand(this.game) },
                //{ PlayerItems.BluePotion, new PotionCommand(this.game) },
                { PlayerItems.Food, new FoodCommand(this.game) },
                { PlayerItems.BlueCandle, new FourCommand(this.game) },
                //{ PlayerItems.RedCandle, new FourCommand(this.game) },
                /*rings*/
                /*magical rod*/
                /*flute*/
            };
        }

        public void Execute()
        {
            BItem = game.hudManager.CurrentItem;
            if (PlayOrPause() && Contains())
                commands[BItem].Execute();
        }
        private bool PlayOrPause()
        {
            return game.stateMachine.GetState() != GameStateMachine.State.play || game.stateMachine.GetState() != GameStateMachine.State.test;
        }
        private bool Contains()
        {
            return commands.ContainsKey(BItem);
        }
    }
}
