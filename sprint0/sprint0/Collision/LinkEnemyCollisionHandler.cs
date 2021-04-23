using System;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class LinkEnemyCollisionHandler
    {
        private readonly int linkSize = (int)(16 * Game1.Scale);
        private readonly int offset = 4;
        public LinkEnemyCollisionHandler() { }

        public void HandleCollision(IPlayer link, IEnemy enemy, Direction side)
        {
            if (!(link is DamagedLink || link.IsJumping()) && !(enemy is Trapparatus))
            {
                link.TakeDamage(side, enemy.Damage);
                switch (side)
                {
                    case Direction.North:
                        link.Pos += new Vector2(0, enemy.Location.Bottom - (link.Pos.Y + offset));
                        break;
                    case Direction.South:
                        link.Pos += new Vector2(0, enemy.Location.Top - (link.Pos.Y + linkSize - offset));
                        break;
                    case Direction.East:
                        link.Pos += new Vector2(enemy.Location.Left - (link.Pos.X + linkSize - offset), 0);
                        break;
                    case Direction.West:
                        link.Pos += new Vector2(enemy.Location.Right - (link.Pos.X + offset), 0);
                        break;
                }
            }
        }
    }
}
