using System;
namespace sprint0
{
    public class Note2Command : ICommand
    {
        private readonly Game1 game;
        public Note2Command(Game1 game) => this.game = game;
        public void Execute()
        {
            game.Room.RoomSound.AddSoundEffect(SoundEnum.Note2);
        }
    }
}
