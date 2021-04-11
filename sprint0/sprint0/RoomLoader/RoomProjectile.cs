using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class RoomProjectile
    {
        private ProjectileSpriteFactory projectileFactory;
        public List<IProjectile> Projectiles { get => projectiles; set => projectiles = value; }
        public List<IProjectile> ProjectilesToDie { get => projectilesToDie; set => projectilesToDie = value; }
        private List<IProjectile> projectiles, projectilesToDie;
        public RoomProjectile(Game1 game)
        {
            projectileFactory = new ProjectileSpriteFactory(game);
            projectilesToDie = new List<IProjectile>();
            projectiles = new List<IProjectile>();
        }

        public void AddProjectile(Vector2 Location, Direction dir, ProjectileEnum item, IEntity source)
            => projectiles.Add(projectileFactory.MakeProjectile(item, Location, dir, source));

        public void AddFireball(Vector2 location, Vector2 dir, IEntity source)
            => projectiles.Add(projectileFactory.MakeFireball(location, dir, source));

        public void RegisterProjectiles(IEnumerable<IProjectile> unregProjectiles)
            => projectiles.AddRange(unregProjectiles);

        public void RemoveProjectile(IProjectile projectile) => projectilesToDie.Add(projectile);

        public void RemoveDead()
        {
            foreach (IProjectile projectile in projectiles)
                if (!projectile.IsAlive()) RemoveProjectile(projectile);
        }

        public void RemoveDeadTwo()
        {
            foreach (IProjectile projectile in projectilesToDie)
                projectiles.Remove(projectile);
        }

        public void Clear() => projectilesToDie.Clear();

        public void UpdateOffset(Vector2 Offset)
        {
            foreach (IProjectile item in projectiles)
                item.Location = new Rectangle(item.Location.X + (int)Offset.X, item.Location.Y + (int)Offset.Y, item.Location.Width, item.Location.Height);
        }

        public void Update()
        {
            foreach (IProjectile projectile in projectiles)
                projectile.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IProjectile projectile in projectiles)
                projectile.Draw(spriteBatch);
        }
    }
}
