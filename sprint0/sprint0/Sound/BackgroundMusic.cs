using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Media;

namespace sprint0
{
    public class BackgroundMusic
    {
        private readonly List<Song> songs;
        private int currSong;

        public BackgroundMusic(List<Song> songs)
        {
            this.songs = songs;
            currSong = 1;
            Play();
        }

        public void Toggle()
        {
            if (MediaPlayer.State.Equals(MediaState.Playing))
                Stop();
            else
                Play();
        }

        public void SkipSong() => MediaPlayer.Stop();

        public void Update()
        {
            if (MediaPlayer.State.Equals(MediaState.Stopped))
                Play();
        }

        private void Play()
        {
            if (MediaPlayer.State.Equals(MediaState.Paused))
                MediaPlayer.Resume();
            else if (MediaPlayer.State.Equals(MediaState.Stopped))
            {
                MediaPlayer.Play(songs[currSong]);
                currSong = (currSong + 1) % songs.Count;
            }
        }

        private void Stop() => MediaPlayer.Pause();
    }
}
