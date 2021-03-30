using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class OpenDoor : AbstractBorderFilling
    {
        public OpenDoor(Texture2D texture, Vector2 location, Direction dir, Game1 game) : base(texture, location, dir, game)
        {
            xOffset = 848;
            yOffset = 11;
            GetSource();
        }
    }
}
