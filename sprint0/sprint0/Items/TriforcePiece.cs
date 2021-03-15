using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class TriforcePiece : IItem
    {
        public int PickedUpDuration { get; set; }
		private readonly int maxPickedUpDuration = 40;
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private string color;
        private Dictionary<string, Rectangle> colorMap;
        private readonly int width, height;

        public TriforcePiece(Texture2D texture, Vector2 location, string triforceColor)
        {
            width = height = 14;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
			PickedUpDuration = -1; // not picked up, special animation
            color = triforceColor;

            colorMap = new Dictionary<string, Rectangle>
            {
                { "gold", new Rectangle(271, 1, width, height) },
                { "blue", new Rectangle(271, 17, width, height) }
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (PickedUpDuration < maxPickedUpDuration)
                spriteBatch.Draw(Texture, Location, colorMap[color], Color.White);
        }

        public void Update()
        {
            if (PickedUpDuration >= 0) PickedUpDuration++;
        }
    }
}