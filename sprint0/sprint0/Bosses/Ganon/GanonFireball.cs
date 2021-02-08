using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class GanonFireball : ISprite // regular round fireball
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int width = 8, height = 10;
        private Dictionary<String, List<Rectangle>> dirToSourcesMap;
        private Dictionary<String, SpriteEffects> dirToEffectsMap;
        private String dir;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;

        public GanonFireball(Texture2D texture, Vector2 location, String dir)
        {
            Location = location;
            Texture = texture;
            this.dir = dir;
            currFrame = 0;
            totalFrames = 4;
            repeatedFrames = 2;
            dirToSourcesMap = new Dictionary<string, List<Rectangle>>
            {
                { "center",  GetFrames(238, 157) },
                { "up", GetFrames(276, 157) },
                { "up left", GetFrames(276, 174) },
                { "left", GetFrames(276, 192) },
                { "down left", GetFrames(276, 174) },
                { "down", GetFrames(276, 157) },
                { "down right", GetFrames(276, 174)},
                { "right",  GetFrames(276, 192) },
                { "up right", GetFrames(276, 174) }
            };
            dirToEffectsMap = new Dictionary<string, SpriteEffects>
            {
                { "center",  SpriteEffects.None },
                { "up", SpriteEffects.None },
                { "up left", SpriteEffects.None },
                { "left", SpriteEffects.None },
                { "down left", SpriteEffects.FlipVertically },
                { "down", SpriteEffects.FlipVertically },
                { "down right", SpriteEffects.FlipVertically | SpriteEffects.FlipHorizontally},
                { "right",  SpriteEffects.FlipHorizontally },
                { "up right", SpriteEffects.FlipHorizontally }
            };
        }

        //TODO make a utility class so we can reuse this code??? this is in a lot of places rn
        public List<Rectangle> GetFrames(int xOffset, int yOffset)
        {
            List<Rectangle> sources = new List<Rectangle>();
            for (int frame = 0; frame < totalFrames; frame++)
            {
                sources.Add(new Rectangle(xOffset + frame * (width + 1), yOffset, width, height));
            };
            return sources;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, dirToSourcesMap[dir][currFrame / repeatedFrames], Color.White, 0, new Vector2(0, 0), 1, dirToEffectsMap[dir], 0);
        }

        public void Update()
        {
            // animates all the time for now
            currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
        }
    }
}
