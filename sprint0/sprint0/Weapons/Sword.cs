using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint0
{
    class Sword : IWeapon
    {
        private IPlayer player;

        public Rectangle Location { get; set; }

        private readonly int width, height;

        public int Damage { get; }

        public Sword(Vector2 location, Direction dir, IPlayer player)
        {
            this.player = player;
            Damage = player.WeaponDamage;
            if (dir == Direction.n || dir == Direction.s)
            {
                width = 7;
                height = 16;
            }
            else
            {
                width = 16;
                height = 7;
            }
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            // no-op: the sword is drawn by the Link sprite
        }

        public bool IsAlive()
        {
            return player.State is UpWoodSwordState || player.State is DownWoodSwordState || player.State is LeftWoodSwordState || player.State is RightWoodSwordState;
        }

        public void Update()
        {
            // no-op
        }
    }
}
