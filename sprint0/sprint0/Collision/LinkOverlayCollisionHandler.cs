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
                if (borderFilling.Location.Intersects(new Rectangle((int)link.Pos.X, (int)link.Pos.Y, linkSize, linkSize)))
                {
                    Direction borderSide = borderFilling.BorderFilling.Side;
                    int newRoom = AdjacentRooms.GetAdjacentRoom(game.RoomIndex, borderSide);
                    game.stateMachine.HandleNewRoom(borderSide, newRoom);
                    switch (borderSide)
                    {
                        case Direction.n:
                            link.Pos = new Vector2(link.Pos.X, (Game1.HUDHeight + Game1.MapHeight - Game1.BorderThickness) * Game1.Scale - linkSize);
                            break;
                        case Direction.s:
                            link.Pos = new Vector2(link.Pos.X, (Game1.HUDHeight + Game1.BorderThickness) * Game1.Scale);
                            break;
                        case Direction.e:
                            link.Pos = new Vector2(Game1.BorderThickness * Game1.Scale, link.Pos.Y);
                            break;
                        case Direction.w:
                            link.Pos = new Vector2((Game1.Width - Game1.BorderThickness) * Game1.Scale - linkSize, link.Pos.Y);
                            break;
                    }
                }
            }
        }
    }
}
