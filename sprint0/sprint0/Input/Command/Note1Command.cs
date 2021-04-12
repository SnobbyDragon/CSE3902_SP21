using System;
namespace sprint0
{
    public class Note1Command : ICommand
    {
        private readonly Game1 game;
        public Note1Command(Game1 game) => this.game = game;
        public void Execute()
        {
            
            game.Room.RoomSound.AddSoundEffect(SoundEnum.Note1);
        }
    }
}
