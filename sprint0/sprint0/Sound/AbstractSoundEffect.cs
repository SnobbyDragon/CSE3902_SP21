using System;
using Microsoft.Xna.Framework.Audio;

namespace sprint0
{
    public abstract class AbstractSoundEffect
    {
        private static bool isMuted = false;
        public SoundEffectInstance SoundEffectInstance { get; }

        public AbstractSoundEffect(SoundEffect soundEffect)
        {
            SoundEffectInstance = soundEffect.CreateInstance();
            SoundEffectInstance.IsLooped = false;
            Play();
        }

        public void Play()
        {
            if (!isMuted && SoundEffectInstance.State != SoundState.Playing)
                SoundEffectInstance.Play();
        }

        public void Stop()
        {
            if (SoundEffectInstance.State == SoundState.Playing)
                SoundEffectInstance.Stop();
        }

        private void CheckMuted()
        {
            if (isMuted)
                Stop();
        }

        public bool IsDone()
        {
            CheckMuted();
            return SoundEffectInstance.State != SoundState.Playing;
        }

        public static void ToggleMute() => isMuted = !isMuted;
    }
}
