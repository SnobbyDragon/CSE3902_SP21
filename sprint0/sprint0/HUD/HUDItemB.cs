﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class HUDItemB : ISprite
    {

        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;
        public string Item { get; set; }
        private readonly Dictionary<string, Rectangle> itemMap;
        private readonly int width = 8;
        private readonly int height = 16;

        public HUDItemB(Texture2D texture, Vector2 location, string itemName)
        {
            Location = location;
            Texture = texture;
            Item = itemName;
            int yPos = 137;

            itemMap = new Dictionary<string, Rectangle>
            {
                { "sword", GetSource(555, yPos)},
                { "white sword", GetSource(564, yPos)},
                { "magical sword", GetSource(573, yPos)},
                { "boomerang", GetSource(584, yPos)},
                { "magical boomerang", GetSource(593, yPos)},
                { "bomb", GetSource(604, yPos)},
                { "arrow", GetSource(615, yPos)},
                { "silver arrow", GetSource(624, yPos)},
                { "bow", GetSource(633, yPos)},
                { "blue candle", GetSource(644, yPos)},
                { "red candle", GetSource(653, yPos)},
                { "flute", GetSource(664, yPos)},
                { "food", GetSource(675, yPos)},
                { "letter", GetSource(686, yPos)},
                { "life potion", GetSource(695, yPos)},
                { "2nd potion", GetSource(704, yPos)},
                { "magical rod", GetSource(715, yPos)},
                { "book of magic", GetSource(538, 118)},
                { "red ring", GetSource(549, 118)},
                { "magical key", GetSource(579, 118)},
                { "power bracelet", GetSource(590, 118)},
            };
        }

        private Rectangle GetSource(int xPos, int yPos)
        {
            source = new Rectangle();
            source = new Rectangle(xPos, yPos, width, height);
            return source;
        }



        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)Location.X, (int)Location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale)), itemMap[Item], Color.White);
        }

        public void Update()
        {
            //Do Nothing
        }
    }
}