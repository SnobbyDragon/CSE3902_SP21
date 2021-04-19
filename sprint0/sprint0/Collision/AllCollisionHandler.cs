using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class AllCollisionHandler
    {
        private readonly Room room;
        private readonly int linkSize = (int)(16 * Game1.Scale);
        private readonly int offset = 4;

        public AllCollisionHandler(Room room)
        {
            this.room = room;
        }

        public void HandleAllCollisions()
        {
            HandleLinkBorderCollision(room.Player, room.RoomSprites);
            HandleWeaponBorderCollision(room.Weapons, room.RoomSprites);
            HandleLinkProjectileCollisions(room.Player, room.Projectiles);
            HandleLinkBlockCollisions(room.Player, room.Blocks);
            HandleLinkEnemyCollisions(room.Player, room.Enemies);
            HandleLinkBlockCollisions(room.Player, room.Blocks);
            HandleLinkItemCollisions(room.Player, room.Items);
            HandleEnemyEnemyCollisions(room.Enemies);
            HandleEnemyBlockCollisions(room.Enemies, room.Blocks);
            HandleEnemyBorderCollisions(room.Enemies, room.RoomSprites);
            HandleEnemyWeaponCollisions(room.Enemies, room.Weapons);
            HandleEnemyProjectileCollisions(room.Enemies, room.Projectiles);
            HandleLinkNpcCollisions(room.Player, room.Npcs);
            HandleProjectileGameBorderCollision(room.Projectiles);
            HandleLinkOverlayCollision(room.Player, room.Overlays);
        }

        private void HandleLinkEnemyCollisions(IPlayer link, List<IEnemy> enemies)
        {
            LinkEnemyCollisionHandler collisionHandler = new LinkEnemyCollisionHandler();
            Rectangle linkHitbox = new Rectangle((int)link.Pos.X + offset, (int)link.Pos.Y + offset, linkSize - offset * 2, linkSize - offset * 2);
            foreach (IEnemy enemy in enemies)
            {
                Collision side = CollisionDetector.DetectCollision(linkHitbox, enemy);
                if (side != Collision.None) collisionHandler.HandleCollision(link, enemy, side.ToDirection());
            }
        }

        private void HandleLinkBlockCollisions(IPlayer link, List<IBlock> blocks)
        {
            LinkBlockCollisionHandler collisionHandler = new LinkBlockCollisionHandler(room.Game, room.Blocks);
            Rectangle linkHitbox = new Rectangle((int)link.Pos.X + offset, (int)link.Pos.Y + offset, linkSize - offset * 2, linkSize - offset * 2);
            foreach (IBlock block in blocks)
            {
                Collision side = CollisionDetector.DetectCollision(linkHitbox, block);
                if (side != Collision.None) collisionHandler.HandleCollision(link, block, side.ToDirection());
            }
        }

        private void HandleLinkProjectileCollisions(IPlayer link, List<IProjectile> projectiles)
        {
            LinkProjectileCollisionHandler collisionHandler = new LinkProjectileCollisionHandler();
            Rectangle linkHitbox = new Rectangle((int)link.Pos.X + offset, (int)link.Pos.Y + offset, linkSize - offset * 2, linkSize - offset * 2);
            foreach (IProjectile projectile in projectiles)
            {
                Collision side = CollisionDetector.DetectCollision(linkHitbox, projectile);
                if (side != Collision.None) collisionHandler.HandleCollision(link, projectile, side.ToDirection());
            }
        }

        private void HandleLinkNpcCollisions(IPlayer link, List<INpc> npcs)
        {
            LinkNpcCollisionHandler collisionHandler = new LinkNpcCollisionHandler();
            Rectangle linkHitbox = new Rectangle((int)link.Pos.X + offset, (int)link.Pos.Y + offset, linkSize - offset * 2, linkSize - offset * 2);
            foreach (INpc npc in npcs)
            {
                Collision side = CollisionDetector.DetectCollision(linkHitbox, npc);
                if (side != Collision.None) collisionHandler.HandleCollision(link, npc, side.ToDirection());
            }
        }

        private void HandleLinkItemCollisions(IPlayer link, List<IItem> items)
        {
            LinkItemCollisionHandler collisionHandler = new LinkItemCollisionHandler(room);
            Rectangle linkHitbox = new Rectangle((int)link.Pos.X + offset, (int)link.Pos.Y + offset, linkSize - offset * 2, linkSize - offset * 2);
            foreach (IItem item in items)
            {
                Collision side = CollisionDetector.DetectCollision(linkHitbox, item);
                if (side != Collision.None) collisionHandler.HandleCollision(link, item, side.ToDirection());
            }
        }

        private void HandleLinkOverlayCollision(IPlayer link, List<ISprite> overlays)
        {
            LinkOverlayCollisionHandler collisionHandler = new LinkOverlayCollisionHandler(room.Game);
            Rectangle linkHitbox = new Rectangle((int)link.Pos.X + offset, (int)link.Pos.Y + offset, linkSize - offset * 2, linkSize - offset * 2);
            foreach (ISprite overlay in overlays)
            {
                Collision side = CollisionDetector.DetectCollision(linkHitbox, overlay);
                if (side != Collision.None) collisionHandler.HandleCollision(link, overlay, side.ToDirection());
            }
        }

        private void HandleEnemyBlockCollisions(List<IEnemy> enemies, List<IBlock> blocks)
        {
            EnemyBlockCollisionHandler collisionHandler = new EnemyBlockCollisionHandler();
            foreach (IEnemy enemy in enemies)
            {
                foreach (IBlock block in blocks)
                {
                    Collision side = CollisionDetector.DetectCollision(enemy, block);
                    if (side != Collision.None) collisionHandler.HandleCollision(enemy, block, side.ToDirection());
                }
            }
        }

        private void HandleEnemyBorderCollisions(List<IEnemy> enemies, List<ISprite> borderSprites)
        {
            EnemyBorderCollisionHandler collisionHandler = new EnemyBorderCollisionHandler();
            foreach (IEnemy enemy in enemies)
            {
                foreach (ISprite border in borderSprites)
                {
                    Collision side = CollisionDetector.DetectCollision(enemy, border);
                    if (side != Collision.None) collisionHandler.HandleCollision(enemy, border, side.ToDirection());
                }
            }
        }

        private void HandleEnemyEnemyCollisions(List<IEnemy> enemies)
        {
            EnemyEnemyCollisionHandler collisionHandler = new EnemyEnemyCollisionHandler();
            for (int i = 0; i < enemies.Count; i++)
            {
                for (int j = i + 1; j < enemies.Count; j++)
                {
                    Collision side = CollisionDetector.DetectCollision(enemies[i], enemies[j]);
                    if (side != Collision.None) collisionHandler.HandleCollision(enemies[i], enemies[j], side.ToDirection());
                }
            }
        }

        private void HandleEnemyWeaponCollisions(List<IEnemy> enemies, List<IWeapon> weapons)
        {
            EnemyWeaponCollisionHandler collisionHandler = new EnemyWeaponCollisionHandler();
            foreach (IEnemy enemy in enemies)
            {
                foreach (IWeapon projectile in weapons)
                {
                    Collision side = CollisionDetector.DetectCollision(enemy, projectile);
                    if (side != Collision.None) collisionHandler.HandleCollision(enemy, projectile, side.ToDirection());
                }
            }
        }

        private void HandleEnemyProjectileCollisions(List<IEnemy> enemies, List<IProjectile> projectiles)
        {
            EnemyWeaponCollisionHandler collisionHandler = new EnemyWeaponCollisionHandler();
            foreach (IEnemy enemy in enemies)
            {
                foreach (IProjectile projectile in projectiles)
                {
                    Collision side = CollisionDetector.DetectCollision(enemy, projectile);
                    if (side != Collision.None) collisionHandler.HandleCollision(enemy, projectile, side.ToDirection());
                }
            }
        }

        private void HandleProjectileGameBorderCollision(List<IProjectile> projectiles)
        {
            foreach (IProjectile projectile in projectiles)
            {
                if (ProjectileBorder(projectile)) projectile.RegisterHit();
            }
        }

        private bool ProjectileBorder(IProjectile projectile) => projectile.Location.Y <= Game1.HUDHeight * Game1.Scale
                    || projectile.Location.Y >= (Game1.MapHeight + Game1.HUDHeight) * Game1.Scale
                    || projectile.Location.X <= 0 || projectile.Location.X >= Game1.Width * Game1.Scale;

        private void HandleLinkBorderCollision(IPlayer link, List<ISprite> borderSprites)
        {
            LinkBorderCollisionHandler collisionHandler = new LinkBorderCollisionHandler();
            Rectangle linkHitbox = new Rectangle((int)link.Pos.X + offset, (int)link.Pos.Y + offset, linkSize - offset * 2, linkSize - offset * 2);
            foreach (ISprite border in borderSprites)
            {
                Collision side = CollisionDetector.DetectCollision(linkHitbox, border);
                if (side != Collision.None) collisionHandler.HandleCollision(link, border, side.ToDirection(), room.Game);
            }
        }

        private void HandleWeaponBorderCollision(List<IWeapon> weapons, List<ISprite> borderSprites)
        {
            WeaponBorderCollisionHandler collisionHandler = new WeaponBorderCollisionHandler();
            foreach (ISprite border in borderSprites)
            {
                foreach (IWeapon weapon in weapons)
                {
                    Collision side = CollisionDetector.DetectCollision(weapon, border);
                    if (side != Collision.None) collisionHandler.HandleCollision(weapon, border, side.ToDirection(), room.Game);
                }
            }
        }
    }
}
