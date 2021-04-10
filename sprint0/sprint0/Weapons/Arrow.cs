using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace sprint0
{
    public class Arrow : IProjectile
    {
        public IEntity Shooter { get; }
        public Rectangle Location { get; set; }
        public int Damage { get => 4; }
        public Texture2D Texture { get; set; }
        public Vector2 origin;
        private float rotation;
        private readonly float defaultAngle;
        private readonly Rectangle source;
        private readonly int xOffset = 154, yOffset = 0, width = 5, height = 16;
        private readonly int sourceAdjustX = 14, sourceAdjustY = 18;
        private readonly Direction dir;
        private readonly int speed = 5;
        private bool hit = false;
        private readonly Room room;
        private readonly Vector2 tipOffset;
        private Rectangle LocationDraw;
        public Arrow(Texture2D texture, Vector2 location, Direction dir, IEntity shooter, Room room)
        {
            Shooter = shooter;
            Vector2 loc = location;
            if (dir == Direction.North || dir == Direction.South)
                loc += new Vector2(sourceAdjustX, 0);
            else
                loc += new Vector2(0, sourceAdjustY);
            if (dir == Direction.South || dir == Direction.East)
                tipOffset = width * DirectionMethods.ToVector2(dir) + height * DirectionMethods.ToVector2(dir);

            Location = new Rectangle((int)loc.X, (int)loc.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            LocationDraw = new Rectangle((int)loc.X, (int)loc.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            this.dir = dir;
            this.room = room;
            source = new Rectangle(xOffset, yOffset, width, height);
            origin = new Vector2(width / 2, height / 2);
            rotation = 0;
            defaultAngle = (float)Math.PI / 2;
        }

        public bool IsAlive() => !hit;
        private void Move()
        {
            Rectangle loc = Location;
            loc.Offset(speed * dir.ToVector2());
            Location = loc;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            LocationDraw = new Rectangle((int)Location.X, (int)Location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            if (IsAlive())
                spriteBatch.Draw(Texture, LocationDraw, source, Color.White, rotation, origin, SpriteEffects.None, 0);
        }

        public void Update()
        {
            if (IsAlive())
            {
                rotation = defaultAngle - dir.ToRadians();
                if (dir == Direction.East || dir == Direction.West)
                    Location = new Rectangle((int)Location.X, (int)Location.Y, (int)(height * Game1.Scale), (int)(width * Game1.Scale));
                else
                    Location = new Rectangle((int)Location.X, (int)Location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
                Move();
            }
        }

        public void RegisterHit()
        {
            hit = true;
            room.LoadLevel.RoomEffect.AddEffect(new Vector2(Location.X, Location.Y) + tipOffset, EffectEnum.HitSprite);
        }
    }
}
