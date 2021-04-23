using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Keese : AbstractEnemy
    {
        private readonly Dictionary<Color, List<Rectangle>> colorMap;
        public Color Color { get; }

        public Keese(Texture2D texture, Vector2 location, Color keeseColor, Game1 game) : base(texture, location, game)
        {
            dirChangeDelay = 5;
            width = height = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            Color = keeseColor;
            currentFrame = 0;
            totalFrames = 2;
            repeatedFrames = 8;
            direction = Direction.North;
            damage = 1;
            health = 2;

            colorMap = new Dictionary<Color, List<Rectangle>>
            {
                { Color.Blue, SpritesheetHelper.GetFramesH(183, 11, width, height, totalFrames) },
                { Color.Red, SpritesheetHelper.GetFramesH(183, 28, width, height, totalFrames) }
            };
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (damageTimer % 2 == 0) spriteBatch.Draw(Texture, Location, colorMap[Color][currentFrame / repeatedFrames], Color.White);
        }
    }
}