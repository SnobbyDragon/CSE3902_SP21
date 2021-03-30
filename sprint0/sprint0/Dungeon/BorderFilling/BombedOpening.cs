using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class BombedOpening : AbstractBorderFilling
    {
        public BombedOpening(Texture2D texture, Vector2 location, Direction dir, Game1 game) : base(texture, location, dir, game)
        {
            xOffset = 947;
            yOffset = 11;
            GetSource();
            game.Room.Overlay.AddOverlay(new BorderFillingOverlay(this));
        }
    }
}
