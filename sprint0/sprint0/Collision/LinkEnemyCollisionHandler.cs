using System;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class LinkEnemyCollisionHandler

    {
        private readonly int linkSize = (int)(16 * Game1.Scale);
        private readonly int offset = 4;
        public LinkEnemyCollisionHandler()
        {

        }

        public void HandleCollision(IPlayer link, IEnemy enemy, Direction side)
        {
            if (!(link is DamagedLink))
            {
                link.TakeDamage(side, enemy.Damage);
                switch (side)
                {
                    case Direction.n:
                        link.Pos += new Vector2(0, enemy.Location.Bottom - (link.Pos.Y + offset));
                        break;
                    case Direction.s:
                        link.Pos += new Vector2(0, enemy.Location.Top - (link.Pos.Y + linkSize - offset));
                        break;
                    case Direction.e:
                        link.Pos += new Vector2(enemy.Location.Left - (link.Pos.X + linkSize - offset), 0);
                        break;
                    case Direction.w:
                        link.Pos += new Vector2(enemy.Location.Right - (link.Pos.X + offset), 0);
                        break;
                }
            }
        }
    }
}
