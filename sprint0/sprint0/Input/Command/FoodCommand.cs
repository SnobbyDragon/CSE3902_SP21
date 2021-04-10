// Author: Stuti Shah
namespace sprint0
{
    class FoodCommand : ICommand
    {
        private readonly Game1 game;
        private HUDManager HUD;
        private readonly PlayerItems item = PlayerItems.Food;
        private readonly int health = 5;

        public FoodCommand(Game1 game) => this.game = game;

        public void Execute()
        {
            HUD = game.hudManager;
            HUD.RemoveBItem(item);
            HUD.GainHealth(health);
        }
    }
}
