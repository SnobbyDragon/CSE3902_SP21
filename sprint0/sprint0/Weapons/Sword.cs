using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace sprint0
{
    class Sword : IWeapon
    {
        private readonly IPlayer player;
        public Rectangle Location { get; set; }
        private readonly int width, height;
        public int Damage { get; }
        private bool hit = false;
        private readonly int shortSide = 7, longSide = 16;

        public Sword(Vector2 location, Direction dir, IPlayer player)
        {
            this.player = player;
            Damage = player.WeaponDamage;
            if (dir == Direction.North || dir == Direction.South)
            {
                width = shortSide;
                height = longSide;
            }
            else
            {
                width = shortSide;
                height = longSide;
            }
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
        }

        public void Draw(SpriteBatch spriteBatch) { }
        public bool IsAlive() => player.IsSword();
        public void Update() { }
        public void RegisterHit() => hit = true;
        public bool HitAlready() => hit;
    }
}
