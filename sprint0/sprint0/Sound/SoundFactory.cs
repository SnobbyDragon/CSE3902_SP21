using System;
using Microsoft.Xna.Framework.Audio;

namespace sprint0
{
    public class SoundFactory
    {
        private readonly SoundLoader soundLoader;

        public SoundFactory(Game1 game)
        {
            soundLoader = new SoundLoader(game);
        }

        public BackgroundMusic MakeBackgroundMusic()
        {
            return new BackgroundMusic(soundLoader.GetMusic());
        }

        public AbstractSoundEffect MakeSoundEffect(string soundEffectType)
        {
            SoundEffect soundEffect = soundLoader.GetSoundEffect(soundEffectType);
            return soundEffectType switch
            {
                "sword slash" => new SwordSlashSoundEffect(soundEffect),
                "sword shoot" => new SwordShootSoundEffect(soundEffect),
                "arrow" => new ArrowSoundEffect(soundEffect),
                "boomerang" => new BoomerangSoundEffect(soundEffect),
                "shield" => new ShieldSoundEffect(soundEffect),
                "use bomb" => new UseBombSoundEffect(soundEffect),
                "bomb explode" => new BombExplodeSoundEffect(soundEffect),
                "candle" => new CandleSoundEffect(soundEffect),
                "enemy damaged" => new EnemyDamagedSoundEffect(soundEffect),
                "enemy death" => new EnemyDeathSoundEffect(soundEffect),
                "link damaged" => new LinkDamagedSoundEffect(soundEffect),
                "link death" => new LinkDeathSoundEffect(soundEffect),
                "low health" => new LowHealthSoundEffect(soundEffect),
                "new item" => new NewItemSoundEffect(soundEffect),
                "get item" => new GetItemSoundEffect(soundEffect),
                "get heart" => new GetHeartSoundEffect(soundEffect),
                "get key" => new GetKeySoundEffect(soundEffect),
                "get rupee" => new GetRupeeSoundEffect(soundEffect),
                "aquamentus" => new AquamentusSoundEffect(soundEffect),
                "gleeok" => new GleeokSoundEffect(soundEffect),
                "ganon" => new GanonSoundEffect(soundEffect),
                "dodongo" => new DodongoSoundEffect(soundEffect),
                "gohma" => new GohmaSoundEffect(soundEffect),
                "manhandla" => new ManhandlaSoundEffect(soundEffect),
                "digdogger" => new DigdoggerSoundEffect(soundEffect),
                "patra" => new PatraSoundEffect(soundEffect),
                _ => throw new ArgumentException("Invalid sound effect! " + soundEffectType + " Sound factory failed."),
            };
        }
    }
}
