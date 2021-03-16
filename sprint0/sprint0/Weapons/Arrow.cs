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
        private readonly Direction dir;
        private readonly int speed = 5;
        private bool hit = false;

        public Arrow(Texture2D texture, Vector2 location, Direction dir, IEntity shooter)
        {
            Shooter = shooter;
            int sourceAdjustX = 0;
            int sourceAdjustY = 0;
            switch (dir)
            {
                case Direction.n:
                    sourceAdjustX += 14;
                    break;
                case Direction.s:
                    sourceAdjustX += 14;
                    sourceAdjustY += 3;
                    break;
                case Direction.e:
                    sourceAdjustY += 18;
                    break;
                case Direction.w:
                    sourceAdjustY += 18;
                    break;
            }

            Vector2 loc = location + new Vector2(sourceAdjustX, sourceAdjustY);
            Location = new Rectangle((int)loc.X, (int)loc.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            this.dir = dir;
            source = new Rectangle(xOffset, yOffset, width, height);
            origin = new Vector2(width / 2, height / 2);
            rotation = 0;
            defaultAngle = (float)Math.PI/2;
        }

        public bool IsAlive()
        {
            return !hit;
        }

        private void Move()
        {
            Rectangle loc = Location;
            loc.Offset(speed * dir.ToVector2());
            Location = loc;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsAlive())
                spriteBatch.Draw(Texture, Location, source, Color.White, rotation, origin, SpriteEffects.None, 0);
        }

        public void Update()
        {
            if (IsAlive())
            {
                rotation = defaultAngle - dir.ToRadians();
                Move();
            }
        }

        public void RegisterHit()
        {
            hit = true;
        }
    }
}
