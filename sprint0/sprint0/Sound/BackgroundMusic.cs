using System;
using Microsoft.Xna.Framework.Media;

namespace sprint0
{
    public class BackgroundMusic
    {
        private readonly Song song;

        public BackgroundMusic(Song song)
        {
            this.song = song;
            MediaPlayer.IsRepeating = true;
            Play();
        }

        public void Toggle()
        {
            if (MediaPlayer.State.Equals(MediaState.Playing))
                Stop();
            else
                Play();
        }

        private void Play()
        {
            if (MediaPlayer.State.Equals(MediaState.Paused))
                MediaPlayer.Resume();
            else
                MediaPlayer.Play(song);
        }

        private void Stop()
        {
            MediaPlayer.Pause();
        }
    }
}
