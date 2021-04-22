using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: hannah johnson
namespace sprint0
{
    public class Owl : AbstractEnemy
    {

        private readonly List<Rectangle> sprites;
        private readonly int fireballRate = 100;
        private int fireballCounter = 0;

        public Owl(Texture2D texture, Vector2 location, Game1 game) : base(texture, location, game)
        {
            width = 60;
            height = 80;
            dirChangeDelay = 20;
            health = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            totalFrames = 8;
            currentFrame = 0;
            repeatedFrames = 8;
            direction = Direction.North;
            damage = 1;
            int offset = 35;
            sprites = SpritesheetHelper.GetFramesH(18, 10, width, height, totalFrames, offset);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (damageTimer % 2 == 0) spriteBatch.Draw(Texture, Location, sprites[currentFrame / repeatedFrames], Color.White);
        }

        public override void TakeDamage(int damage)
        {

        }

        public override void Update()
        {
            base.Update();
            if (CanShoot()) ShootFireball();
        }
        private bool CanShoot()
        {
            fireballCounter++;
            fireballCounter %= fireballRate;
            return fireballCounter == 0 && !game.Room.FreezeEnemies;
        }

        private void ShootFireball()
        {
            game.Room.RoomSound.AddSoundEffect(SoundEnum.Owl);
            Vector2 dir = game.Room.Player.Pos - Location.Center.ToVector2();
            dir.Normalize();
            game.Room.LoadLevel.RoomProjectile.AddFireball(Location.Center.ToVector2(), dir, this);
        }


    }
}