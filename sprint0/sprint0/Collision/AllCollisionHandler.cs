using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class AllCollisionHandler
    {
        private readonly Game1 game;
        private readonly Room room;
        private readonly CollisionDetector collisionDetector;
        private readonly int linkSize = (int)(16 * Game1.Scale);
        private readonly int offset = 4;

        public AllCollisionHandler(Game1 game, Room room)
        {
            this.game = game;
            this.room = room;
            collisionDetector = new CollisionDetector();
        }

        public void HandleAllCollisions(IPlayer link, List<IEnemy> enemies, List<IWeapon> weapons, List<IProjectile> projectiles, List<IBlock> blocks, List<INpc> npcs, List<IItem> items, List<ISprite> overlays)
        {
            HandleLinkProjectileCollisions(link, projectiles);
            HandleLinkBlockCollisions(link, blocks);
            HandleLinkEnemyCollisions(link, enemies);
            HandleLinkItemCollisions(link, items);
            HandleEnemyEnemyCollisions(enemies);
            HandleEnemyBlockCollisions(enemies, blocks);
            HandleEnemyWeaponCollisions(enemies, weapons);
            HandleEnemyProjectileCollisions(enemies, projectiles);
            HandleBlockBlockCollisions(blocks);
            HandleLinkNpcCollisions(link, npcs);
            HandleProjectileGameBorderCollision(projectiles);
            HandleLinkOverlayCollision(link, overlays);
        }

        private void HandleLinkEnemyCollisions(IPlayer link, List<IEnemy> enemies)
        {
            LinkEnemyCollisionHandler collisionHandler = new LinkEnemyCollisionHandler();
            Rectangle linkHitbox = new Rectangle((int)link.Pos.X + offset, (int)link.Pos.Y + offset, linkSize - offset * 2, linkSize - offset * 2);
            foreach (IEnemy enemy in enemies)
            {
                Collision side = collisionDetector.DetectCollision(linkHitbox, enemy);
                if (side != Collision.None)
                {
                    collisionHandler.HandleCollision(link, enemy, side.ToDirection());
                }
            }
        }

        private void HandleLinkProjectileCollisions(IPlayer link, List<IProjectile> projectiles)
        {
            LinkProjectileCollisionHandler collisionHandler = new LinkProjectileCollisionHandler();
            Rectangle linkHitbox = new Rectangle((int)link.Pos.X + offset, (int)link.Pos.Y + offset, linkSize - offset * 2, linkSize - offset * 2);
            foreach (IProjectile projectile in projectiles)
            {
                Collision side = collisionDetector.DetectCollision(linkHitbox, projectile);
                if (side != Collision.None)
                {
                    collisionHandler.HandleCollision(link, projectile, side.ToDirection());
                }
            }
        }
        private void HandleLinkBlockCollisions(IPlayer link, List<IBlock> blocks)
        {
            LinkBlockCollisionHandler collisionHandler = new LinkBlockCollisionHandler();
            Rectangle linkHitbox = new Rectangle((int)link.Pos.X + offset, (int)link.Pos.Y + offset, linkSize - offset * 2, linkSize - offset * 2);
            foreach (IBlock block in blocks)
            {
                Collision side = collisionDetector.DetectCollision(linkHitbox, block);
                if (side != Collision.None)
                {
                    collisionHandler.HandleCollision(link, block, side.ToDirection());
                }
            }
        }
        private void HandleLinkNpcCollisions(IPlayer link, List<INpc> npcs)
        {
            LinkNpcCollisionHandler collisionHandler = new LinkNpcCollisionHandler();
            Rectangle linkHitbox = new Rectangle((int)link.Pos.X + offset, (int)link.Pos.Y + offset, linkSize - offset * 2, linkSize - offset * 2);
            foreach (INpc npc in npcs)
            {
                Collision side = collisionDetector.DetectCollision(linkHitbox, npc);
                if (side != Collision.None)
                {
                    collisionHandler.HandleCollision(link, npc, side.ToDirection());
                }
            }
        }

        private void HandleLinkItemCollisions(IPlayer link, List<IItem> items)
        {
            LinkItemCollisionHandler collisionHandler = new LinkItemCollisionHandler(room);
            Rectangle linkHitbox = new Rectangle((int)link.Pos.X + offset, (int)link.Pos.Y + offset, linkSize - offset * 2, linkSize - offset * 2);
            foreach (IItem item in items)
            {
                Collision side = collisionDetector.DetectCollision(linkHitbox, item);
                if (side != Collision.None)
                {
                    collisionHandler.HandleCollision(link, item, side.ToDirection());
                }
            }
        }

        private void HandleLinkOverlayCollision(IPlayer link, List<ISprite> overlays)
        {
            LinkOverlayCollisionHandler collisionHandler = new LinkOverlayCollisionHandler(game);
            Rectangle linkHitbox = new Rectangle((int)link.Pos.X + offset, (int)link.Pos.Y + offset, linkSize - offset * 2, linkSize - offset * 2);
            foreach (ISprite overlay in overlays)
            {
                Collision side = collisionDetector.DetectCollision(linkHitbox, overlay);
                if (side != Collision.None)
                {
                    collisionHandler.HandleCollision(link, overlay, side.ToDirection());
                }
            }
        }

        private void HandleEnemyBlockCollisions(List<IEnemy> enemies, List<IBlock> blocks)
        {
            EnemyBlockCollisionHandler collisionHandler = new EnemyBlockCollisionHandler();
            foreach (IEnemy enemy in enemies)
            {
                foreach (IBlock block in blocks)
                {
                    Collision side = collisionDetector.DetectCollision(enemy, block);
                    if (side != Collision.None)
                    {
                        collisionHandler.HandleCollision(enemy, block, side.ToDirection());
                    }
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
                    Collision side = collisionDetector.DetectCollision(enemies[i], enemies[j]);
                    if (side != Collision.None)
                    {
                        collisionHandler.HandleCollision(enemies[i], enemies[j], side.ToDirection());
                    }
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
                    Collision side = collisionDetector.DetectCollision(enemy, projectile);
                    if (side != Collision.None)
                    {
                        collisionHandler.HandleCollision(enemy, projectile, side.ToDirection());
                    }
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
                    Collision side = collisionDetector.DetectCollision(enemy, projectile);
                    if (side != Collision.None)
                    {
                        collisionHandler.HandleCollision(enemy, projectile, side.ToDirection());
                    }
                }
            }
        }

        private void HandleBlockBlockCollisions(List<IBlock> blocks)
        {
            BlockBlockCollisionHandler collisionHandler = new BlockBlockCollisionHandler();
            for (int i = 0; i < blocks.Count; i++)
            {
                for (int j = i + 1; j < blocks.Count; j++)
                {
                    Collision side = collisionDetector.DetectCollision(blocks[i], blocks[j]);
                    if (side != Collision.None)
                    {
                        collisionHandler.HandleCollision(blocks[i], blocks[j], side.ToDirection());
                    }
                }
            }
        }

        private void HandleProjectileGameBorderCollision(List<IProjectile> projectiles)
        {
            foreach (IProjectile projectile in projectiles)
            {
                if (projectile.Location.Y <= Game1.HUDHeight * Game1.Scale
                    || projectile.Location.Y >= (Game1.MapHeight + Game1.HUDHeight) * Game1.Scale
                    || projectile.Location.X <= 0 || projectile.Location.X >= Game1.Width * Game1.Scale)
                {
                    projectile.RegisterHit();
                }
            }
        }
    }
}
