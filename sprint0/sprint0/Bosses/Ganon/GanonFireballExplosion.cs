using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class GanonFireballExplosion
    {
        public GanonFireballExplosion(Texture2D texture, Ganon ganon, Game1 game)
        {
            Vector2 location = ganon.Location.Center.ToVector2();
            List<IProjectile> fireballExplosion = new List<IProjectile>();
            foreach (Direction dir in Enum.GetValues(typeof(Direction)))
                fireballExplosion.Add(new GanonFireball(texture, location, dir, ganon));
            game.Room.LoadLevel.RoomProjectile.RegisterProjectiles(fireballExplosion);
        }
    }
}
