using System;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class LinkNpcCollisionHandler
    {

        private readonly int linkSize = (int)(16 * Game1.Scale);
        public LinkNpcCollisionHandler()
        {
        }

        public void HandleCollision(IPlayer link, INpc npc, Direction side)
        {
            switch (side)
            {
                case Direction.n: // if collide above, then move down
                    link.Pos += new Vector2(0, npc.Location.Bottom - link.Pos.Y);
                    break;
                case Direction.s: // if collide below, then move up
                    link.Pos += new Vector2(0, npc.Location.Top - (link.Pos.Y + linkSize));
                    break;
                case Direction.e: // if collide right, then move left
                    link.Pos += new Vector2(npc.Location.Left - (link.Pos.X + linkSize), 0);
                    break;
                case Direction.w: // if collide left, then move right
                    link.Pos += new Vector2(npc.Location.Right - link.Pos.X, 0);
                    break;
            }
        }
    }
}
