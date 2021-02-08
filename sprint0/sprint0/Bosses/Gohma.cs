using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Gohma : ISprite
    {
        public Vector2 Location { get; set; } // location of the head
        public Texture2D Texture { get; set; }
        private readonly int size = 16;
        private Dictionary<string, List<Rectangle>> colorToLegMap, colorToHeadMap;
        private List<SpriteEffects> leftLegEffects, rightLegEffects;
        private string color;
        private int headCurrFrame, legCurrFrame;
        private readonly int headTotalFrames, headRepeatedFrames, legTotalFrames, legRepeatedFrames;

        public Gohma(Texture2D texture, Vector2 location, string color)
        {
            Location = location;
            Texture = texture;
            this.color = color;
            headCurrFrame = 0;
            legCurrFrame = 0;
            headTotalFrames = 4;
            headRepeatedFrames = 8;
            legTotalFrames = 2;
            legRepeatedFrames = 4;

            colorToLegMap = new Dictionary<string, List<Rectangle>>
            {
                { "orange", GetFrames(196, 105, legTotalFrames) },
                { "blue", GetFrames(196, 122, legTotalFrames) }
            };
            leftLegEffects = new List<SpriteEffects>
            {
                SpriteEffects.None,
                SpriteEffects.FlipHorizontally
            };
            rightLegEffects = new List<SpriteEffects>
            {
                SpriteEffects.FlipHorizontally,
                SpriteEffects.None
            };
            colorToHeadMap = new Dictionary<string, List<Rectangle>>
            {
                { "orange", GetFrames(230, 105, headTotalFrames) },
                { "blue", GetFrames(230, 122, headTotalFrames) }
            };
        }

        //TODO make a utility class so we can reuse this code??? this is in a lot of places rn
        public List<Rectangle> GetFrames(int xOffset, int yOffset, int totalFrames)
        {
            List<Rectangle> sources = new List<Rectangle>();
            for (int frame = 0; frame < totalFrames; frame++)
            {
                sources.Add(new Rectangle(xOffset + frame * (size + 1), yOffset, size, size));
            };
            return sources;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // draws the left leg
            spriteBatch.Draw(
                Texture, Location + new Vector2(-size, 0),
                colorToLegMap[color][legCurrFrame / legRepeatedFrames],
                Color.White, 0, new Vector2(0,0), 1,
                leftLegEffects[legCurrFrame / legRepeatedFrames], 0);

            // draws the head
            spriteBatch.Draw(Texture, Location, colorToHeadMap[color][headCurrFrame / headRepeatedFrames], Color.White);

            // draws the right leg
            spriteBatch.Draw(
                Texture, Location + new Vector2(size, 0),
                colorToLegMap[color][legCurrFrame / legRepeatedFrames],
                Color.White, 0, new Vector2(0, 0), 1,
                rightLegEffects[legCurrFrame / legRepeatedFrames], 0);
        }

        public void Update()
        {
            // animates all the time for now
            headCurrFrame = (headCurrFrame + 1) % (headTotalFrames * headRepeatedFrames);
            legCurrFrame = (legCurrFrame + 1) % (legTotalFrames * legRepeatedFrames);
        }
    }
}
