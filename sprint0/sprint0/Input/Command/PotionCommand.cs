﻿// Author: Stuti Shah
namespace sprint0
{
    class PotionCommand : ICommand
    {
        private readonly Game1 game;
        private HUDManager HUD;
        private readonly PlayerItems item = PlayerItems.RedPotion;
        private readonly int health = 2;

        public PotionCommand(Game1 game) => this.game = game;

        public void Execute()
        {
            HUD = game.hudManager;
            HUD.RemoveBItem(item);
            HUD.GainHealth(health);
        }
    }
}