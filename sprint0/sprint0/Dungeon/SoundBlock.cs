using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson

namespace sprint0
{
    public class SoundBlock : AbstractBlock, IBlock
    {
        public const int DefaultSound = 1;
        private readonly Game1 game;
        public int Sound { get; }
        private readonly List<SoundEnum> Sounds = new List<SoundEnum> { SoundEnum.Note1, SoundEnum.Note2, SoundEnum.Note3, SoundEnum.Note4, SoundEnum.Note5, SoundEnum.Note6 };

        public SoundBlock(Texture2D texture, Vector2 location, Game1 game, int sound)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            source = new Rectangle(1001, 11, width, height);
            this.game = game;
            Sound = sound;
        }
        public void MakeSound() => game.Room.RoomSound.AddSoundEffect(Sounds[Sound - 1]);
    }
}
