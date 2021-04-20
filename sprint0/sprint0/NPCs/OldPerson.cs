using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class OldPerson : INpc
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        public NPCEnum Type { get; set; }
        private readonly int xOffset = 1, yOffset = 11, width, height;
        private readonly Dictionary<NPCEnum, Rectangle> typeRectMap;

        public OldPerson(Texture2D texture, Vector2 location, NPCEnum type)
        {
            width = height = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            Type = type;
            List<Rectangle> sources = SpritesheetHelper.GetFramesH(xOffset, yOffset, width, height, 3);
            typeRectMap = new Dictionary<NPCEnum, Rectangle>
            {
                { NPCEnum.OldMan1, sources[0] },
                { NPCEnum.OldMan2, sources[1] },
                { NPCEnum.OldWoman, sources[2] }
            };
        }

        public void Draw(SpriteBatch spriteBatch)
            => spriteBatch.Draw(Texture, Location, typeRectMap[Type], Color.White);
        public void Update() { }
    }
}
