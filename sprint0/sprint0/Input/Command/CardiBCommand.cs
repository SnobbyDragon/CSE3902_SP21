using System;
namespace sprint0
{
    public class CardiBCommand : ICommand
    {
        private readonly Game1 game;
        public CardiBCommand(Game1 game) => this.game = game;
        public void Execute()
        {
            game.SoundFactory.RunLikeCardiO();
            game.Room.RoomSound.AddSoundEffect(SoundEnum.LinkDamaged);
        }
    }
}
