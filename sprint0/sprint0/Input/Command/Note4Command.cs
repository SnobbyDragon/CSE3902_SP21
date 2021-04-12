using System;
namespace sprint0
{
    public class Note4Command : ICommand
    {
        private readonly Game1 game;
        public Note4Command(Game1 game) => this.game = game;
        public void Execute()
        {
            
            game.Room.RoomSound.AddSoundEffect(SoundEnum.Note4);
        }
    }
}
