namespace sprint0
{
    public class ToggleSoundEffectsCommand : ICommand
    {
        public ToggleSoundEffectsCommand() { }
        public void Execute() => AbstractSoundEffect.ToggleMute();
    }
}
