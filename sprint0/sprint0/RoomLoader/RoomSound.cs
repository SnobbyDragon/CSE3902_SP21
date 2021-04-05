using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class RoomSound
    {
        private SoundFactory soundFactory;
        public List<AbstractSoundEffect> SoundEffects { get => soundEffects; set => soundEffects = value; }
        public List<AbstractSoundEffect> SoundEffectsToDie { get => soundEffectsToDie; set => soundEffectsToDie = value; }
        private List<AbstractSoundEffect> soundEffects, soundEffectsToDie;
        public RoomSound(Game1 game)
        {
            soundFactory = new SoundFactory(game);
            soundEffects = new List<AbstractSoundEffect>();
            soundEffectsToDie = new List<AbstractSoundEffect>();
        }

        public void AddSoundEffect(SoundEnum soundEffect)
            => soundEffects.Add(soundFactory.MakeSoundEffect(soundEffect));

        public void RemoveSoundEffect(AbstractSoundEffect soundEffect)
            => soundEffectsToDie.Add(soundEffect);

        public void RemoveDead()
        {
            foreach (AbstractSoundEffect soundEffect in soundEffects)
                if (soundEffect.IsDone()) RemoveSoundEffect(soundEffect);
            foreach (AbstractSoundEffect soundEffect in soundEffectsToDie)
                soundEffects.Remove(soundEffect);
        }

        public void Clear() => soundEffectsToDie.Clear();
    }
}