using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class BorderFillingOverlay : ISprite
    {
        public Rectangle Location { get; set; }
        private readonly Texture2D texture;
        private readonly Rectangle source;
        public AbstractBorderFilling BorderFilling { get; }

        public BorderFillingOverlay(AbstractBorderFilling borderFilling)
        {
            texture = borderFilling.Texture;
            BorderFilling = borderFilling;

            int locX = borderFilling.Location.X;
            int locY = borderFilling.Location.Y;
            int locSize = borderFilling.Location.Width;
            int srcX = borderFilling.Source.X;
            int srxY = borderFilling.Source.Y;
            int srcSize = borderFilling.Source.Width;

            switch (borderFilling.Side)
            {
                case Direction.n:
                    Location = new Rectangle(locX, locY, locSize, locSize / 2);
                    source = new Rectangle(srcX, srxY, srcSize, srcSize / 2);
                    break;
                case Direction.s:
                    Location = new Rectangle(locX, locY + locSize / 2, locSize, locSize / 2);
                    source = new Rectangle(srcX, srxY + srcSize / 2, srcSize, srcSize / 2);
                    break;
                case Direction.e:
                    Location = new Rectangle(locX + locSize / 2, locY, locSize / 2, locSize);
                    source = new Rectangle(srcX + srcSize / 2, srxY, srcSize / 2, srcSize);
                    break;
                case Direction.w:
                    Location = new Rectangle(locX, locY, locSize / 2, locSize);
                    source = new Rectangle(srcX, srxY, srcSize / 2, srcSize);
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Location, source, Color.White);
        }

        public void Update() { }
    }
}
