using System;
using Microsoft.Xna.Framework.Audio;

namespace sprint0
{
    public enum SoundEnum
    {
        SwordSlash, SwordShoot, Arrow, Boomerang, Shield, UseBomb, BombExplode, Candle,
        EnemyDamaged, EnemyDeath, LinkDamaged, LinkDeath, LowHealth,
        NewItem, GetItem, GetHeart, GetKey, GetRupee,
        Aquamentus, Gleeok, Ganon, Dodongo, Gohma, Manhandla, Digdogger, Patra,
        MagicalRod, Flute, Refill, TextAppear, TextAppearSlow, KeyAppear, UnlockDoor,
        Stairs, Shore, Secret
    }
    public class SoundFactory
    {
        private readonly SoundLoader soundLoader;

        public SoundFactory(Game1 game) => soundLoader = new SoundLoader(game);;
        public BackgroundMusic MakeBackgroundMusic()
            => new BackgroundMusic(soundLoader.GetMusic());

        public AbstractSoundEffect MakeSoundEffect(SoundEnum soundEffectType)
        {
            SoundEffect soundEffect = soundLoader.GetSoundEffect(soundEffectType);
            return soundEffectType switch
            {
                SoundEnum.SwordSlash => new SwordSlashSoundEffect(soundEffect),
                SoundEnum.SwordShoot => new SwordShootSoundEffect(soundEffect),
                SoundEnum.Arrow => new ArrowSoundEffect(soundEffect),
                SoundEnum.Boomerang => new BoomerangSoundEffect(soundEffect),
                SoundEnum.Shield => new ShieldSoundEffect(soundEffect),
                SoundEnum.UseBomb => new UseBombSoundEffect(soundEffect),
                SoundEnum.BombExplode => new BombExplodeSoundEffect(soundEffect),
                SoundEnum.Candle => new CandleSoundEffect(soundEffect),
                SoundEnum.EnemyDamaged => new EnemyDamagedSoundEffect(soundEffect),
                SoundEnum.EnemyDeath => new EnemyDeathSoundEffect(soundEffect),
                SoundEnum.LinkDamaged => new LinkDamagedSoundEffect(soundEffect),
                SoundEnum.LinkDeath => new LinkDeathSoundEffect(soundEffect),
                SoundEnum.LowHealth => new LowHealthSoundEffect(soundEffect),
                SoundEnum.NewItem => new NewItemSoundEffect(soundEffect),
                SoundEnum.GetItem => new GetItemSoundEffect(soundEffect),
                SoundEnum.GetHeart => new GetHeartSoundEffect(soundEffect),
                SoundEnum.GetKey => new GetKeySoundEffect(soundEffect),
                SoundEnum.GetRupee => new GetRupeeSoundEffect(soundEffect),
                SoundEnum.Aquamentus => new AquamentusSoundEffect(soundEffect),
                SoundEnum.Gleeok => new GleeokSoundEffect(soundEffect),
                SoundEnum.Ganon => new GanonSoundEffect(soundEffect),
                SoundEnum.Dodongo => new DodongoSoundEffect(soundEffect),
                SoundEnum.Gohma => new GohmaSoundEffect(soundEffect),
                SoundEnum.Manhandla => new ManhandlaSoundEffect(soundEffect),
                SoundEnum.Digdogger => new DigdoggerSoundEffect(soundEffect),
                SoundEnum.Patra => new PatraSoundEffect(soundEffect),
                _ => throw new ArgumentException("Invalid sound effect! " + soundEffectType.ToString() + " Sound factory failed."),
            };
        }
    }
}
