using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson
namespace sprint0
{
    public class Gel : AbstractEnemy
    {
        private readonly Dictionary<Color, List<Rectangle>> colorMap;
        public Color Color { get; }
        public new EnemyType Type { get => EnemyType.Gel; }

        public Gel(Texture2D texture, Vector2 location, Game1 gm, Color gelColor) : base(texture, location, gm)
        {
            width = 8;
            height = 16;
            repeatedFrames = 10;
            health = 1;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            totalFrames = 2;
            currentFrame = 0;
            Color = gelColor;
            damage = 1;

            colorMap = new Dictionary<Color, List<Rectangle>>
            {
                { Color.Teal, SpritesheetHelper.GetFramesH(1, 11, width, height, totalFrames) },
                { Color.Blue, SpritesheetHelper.GetFramesH(19, 11, width, height, totalFrames) },
                { Color.Green, SpritesheetHelper.GetFramesH(37, 11, width, height, totalFrames) },
                { Color.Gold, SpritesheetHelper.GetFramesH(55, 11, width, height, totalFrames) },
                { Color.Lime, SpritesheetHelper.GetFramesH(1, 28, width, height, totalFrames) },
                { Color.Brown, SpritesheetHelper.GetFramesH(19, 28, width, height, totalFrames) },
                { Color.Gray, SpritesheetHelper.GetFramesH(37, 28, width, height, totalFrames) },
                { Color.White, SpritesheetHelper.GetFramesH(55, 28, width, height, totalFrames) },
            };
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (damageTimer % 2 == 0) spriteBatch.Draw(Texture, Location, colorMap[Color][currentFrame / repeatedFrames], Color.White);
        }
    }
}
