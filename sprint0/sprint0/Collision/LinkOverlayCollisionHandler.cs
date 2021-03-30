using System;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class LinkOverlayCollisionHandler
    {
        private readonly Game1 game;
        private readonly int linkSize = (int)(16 * Game1.Scale);

        public LinkOverlayCollisionHandler(Game1 game)
        {
            this.game = game;
        }

        public void HandleCollision(IPlayer link, ISprite overlay, Direction side)
        {
            if (overlay is BorderFillingOverlay borderFilling)
            {
                if (borderFilling.Location.Contains(new Rectangle((int)link.Pos.X, (int)link.Pos.Y, linkSize, linkSize)))
                {
                    int newRoom = AdjacentRooms.GetAdjacentRoom(game.RoomIndex, borderFilling.BorderFilling.Side);
                    game.RoomIndex = newRoom;
                    game.ChangeRoom = true;
                }
            }
        }
    }
}
