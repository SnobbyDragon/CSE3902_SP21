using System;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class LinkNpcCollisionHandler
    {
        private readonly int linkSize = (int)(16 * Game1.Scale);
        public LinkNpcCollisionHandler() { }

        public void HandleCollision(IPlayer link, INpc npc, Direction side)
        {
            if (!link.IsJumping())
            {
                switch (side)
                {
                    case Direction.North:
                        link.Pos += new Vector2(0, npc.Location.Bottom - link.Pos.Y);
                        break;
                    case Direction.South:
                        link.Pos += new Vector2(0, npc.Location.Top - (link.Pos.Y + linkSize));
                        break;
                    case Direction.East:
                        link.Pos += new Vector2(npc.Location.Left - (link.Pos.X + linkSize), 0);
                        break;
                    case Direction.West:
                        link.Pos += new Vector2(npc.Location.Right - link.Pos.X, 0);
                        break;
                }
            }
        }
    }
}
