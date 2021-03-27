using System;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class LinkEnemyCollisionHandler

    {
        private readonly int linkSize = (int)(16 * Game1.Scale);
        public LinkEnemyCollisionHandler()
        {

        }

        public void HandleCollision(IPlayer link, IEnemy enemy, Direction side)
        {
            link.TakeDamage(side, enemy.Damage);
            switch (side)
            {
                case Direction.n:
                    link.Pos += new Vector2(0, enemy.Location.Bottom - link.Pos.Y);
                    break;
                case Direction.s:
                    link.Pos += new Vector2(0, enemy.Location.Top - (link.Pos.Y + linkSize));
                    break;
                case Direction.e:
                    link.Pos += new Vector2(enemy.Location.Left - (link.Pos.X + linkSize), 0);
                    break;
                case Direction.w:
                    link.Pos += new Vector2(enemy.Location.Right - link.Pos.X, 0);
                    break;
            }
        }
    }
}
