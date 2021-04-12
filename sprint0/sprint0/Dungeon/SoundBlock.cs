using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson

namespace sprint0
{
    public class SoundBlock : IBlock
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        public const int DefaultSound = 1;
        private Rectangle source;
        private readonly int width, height;
        private Game1 game;
        private int sound;
        private readonly List<SoundEnum> Sounds= new List<SoundEnum>{ SoundEnum.Note1, SoundEnum.Note2, SoundEnum.Note3 , SoundEnum.Note4 , SoundEnum.Note5, SoundEnum.Note6 };

        public SoundBlock(Texture2D texture, Vector2 location, Game1 game, int sound)
        {
            width = height = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            source = new Rectangle(1001, 11, width, height);
            this.game = game;
            this.sound = sound;
        }

        public void Draw(SpriteBatch spriteBatch)
            => spriteBatch.Draw(Texture, Location, source, Color.White);
        public void Update() { }
        public bool IsWalkable() => false;
        public bool IsMovable() => false;
        public void SetIsMovable() => throw new NotImplementedException();

        public void MakeSound()
         {
            game.Room.RoomSound.AddSoundEffect(Sounds[sound+1]);
          
        }
    }
}
