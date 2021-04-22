using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: hannah johnson
namespace sprint0
{
    public class FairyEnemy : AbstractEnemy
    {

        private readonly List<Rectangle> sprites;
        private readonly int fireballRate = 100;
        private int fireballCounter = 0;
        private readonly int xPos = 40, yPos = 0;

        public FairyEnemy(Texture2D texture, Vector2 location, Game1 game) : base(texture, location, game)
        {
            width = 7;
            height = 16;
            dirChangeDelay = 20;
            health = 16 ;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            totalFrames = 2;
            currentFrame = 0;
            repeatedFrames = 10;
            direction = Direction.North;
            damage = 1;
            sprites = SpritesheetHelper.GetFramesH(xPos, yPos, width, height, totalFrames);
           

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (damageTimer % 2 == 0) spriteBatch.Draw(Texture, Location, sprites[currentFrame / repeatedFrames], Color.White);
        }

        public void MakeFairyLarge()
        {
            Location = new Rectangle((int)Location.X, (int)Location.Y, (int)(width * Game1.Scale*2), (int)(height * Game1.Scale*2));
        }
        public override void Update()
        {
            if (damageTimer > 0) damageTimer--;
            CheckHealth();
            if (!game.Room.FreezeEnemies)
            {
                moveCounter++;
                if (moveCounter == dirChangeDelay) ArbitraryDirection(30, 50);
                currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);
                Rectangle loc = Location;
                loc.Offset(direction.ToVector2());
                Location = loc;
                if (CanShoot()) ShootFireball();
            }
        }
        private bool CanShoot()
        {
            fireballCounter++;
            fireballCounter %= fireballRate;
            return fireballCounter == 0;
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