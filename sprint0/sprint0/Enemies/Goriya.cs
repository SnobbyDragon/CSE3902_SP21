using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Goriya : Enemy, IEnemy
    {
        private Room room;
        private int throwCounter;
        private readonly int throwMax = 100;
        public Goriya(Texture2D texture, Vector2 location, string goriyaColor, Game1 game) : base(texture, location, game)
        {
            health = 50;
            width = height = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            color = goriyaColor;
            currentFrame = 0;
            totalFrames = 4;
            repeatedFrames = 20;
            direction = Direction.n;
            damage = 2;
            room = game.Room;
            throwCounter = 0;

            colorMap = new Dictionary<string, List<Rectangle>>
            {
                { "red", SpritesheetHelper.GetFramesH(222, 11, width, height, totalFrames) },
                { "blue", SpritesheetHelper.GetFramesH(222, 28, width, height, totalFrames) }
            };
        }

        private void UseBoomerang()
        {
            Vector2 offsetPos = Location.Location.ToVector2();
            room.LoadLevel.RoomProjectile.AddProjectile(offsetPos, this.direction, "boomerang", this);
            room.RoomSound.AddSoundEffect("boomerang");
        }

        public new void Update()
        {
            moveCounter++;
            if (moveCounter == dirChangeDelay)
            {
                ArbitraryDirection(30, 50);
            }
            if (damageTimer > 0) damageTimer--;
            CheckHealth();
            currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);
            Rectangle loc = Location;
            loc.Offset(direction.ToVector2());
            Location = loc;

            if (throwCounter == throwMax) {
                throwCounter = 0;
                UseBoomerang();
            }
            throwCounter++;
            
        }
    }
}