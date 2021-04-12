using System;
namespace sprint0
{
    public class Note6Command : ICommand
    {
        private readonly Game1 game;
        public Note6Command(Game1 game) => this.game = game;
        public void Execute()
        {
            
            game.Room.RoomSound.AddSoundEffect(SoundEnum.Note6);
        }
    }
}
