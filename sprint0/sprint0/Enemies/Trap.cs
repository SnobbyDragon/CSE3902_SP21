using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Authors: Stuti Shah, Hannah Johnson, Angela Li
namespace sprint0
{
    public class Trap : AbstractEnemy
    {
        private Rectangle source;
        private Rectangle HomeLocation;
        public bool IsMoving { get; set; }
        private readonly double speed = 1.7;

        public Trap(Texture2D texture, Vector2 location, Game1 game) : base(texture, location, game)
        {
            width = 16;
            height = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            HomeLocation = Location;
            Texture = texture;
            damage = 2;

            source = new Rectangle(164, 59, width, height);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (frameSpawn >= totalFramesSpawn * repeatedFramesSpawn)
            {
                spriteBatch.Draw(Texture, Location, source, Color.White);
            }
        }

        public override void Update()
        {
            if (frameSpawn < totalFramesSpawn * repeatedFramesSpawn) {
                if (frameSpawn < totalFramesSpawn * repeatedFramesSpawn)
                {
                    frameSpawn++;
                }
            } else {
                if (IsMoving)
                    Move();
            }
        }

        private void Move()
        {
            Rectangle loc = Location;
            loc.Offset((int)(speed * direction.ToVector2().X), (int)(speed * direction.ToVector2().Y));
            float nextDistToHome = DistSquared(HomeLocation, loc);
            if (nextDistToHome <= speed && DistSquared(HomeLocation, Location) >= nextDistToHome)
            {
                Location = HomeLocation;
                IsMoving = false;
            }
            else
                Location = loc;
        }

        private float DistSquared(Rectangle one, Rectangle two)
        {
            return (one.Center.ToVector2() - two.Center.ToVector2()).LengthSquared();
        }

        public void SetDirection(Direction direction)
        {
            this.direction = direction;
        }

        public override void ChangeDirection()
        {
            direction = direction.OppositeDirection();
        }
    }
}
