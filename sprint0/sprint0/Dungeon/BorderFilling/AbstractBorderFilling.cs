﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public abstract class AbstractBorderFilling : ISprite
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; }
        protected Rectangle source;
        public Rectangle Source { get => source; }
        protected readonly int size = Game1.BorderThickness;
        protected int xOffset, yOffset;
        public Direction Side { get; }
        public Game1 Game { get; }

        public AbstractBorderFilling(Texture2D texture, Vector2 location, Direction dir, Game1 game)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(size * Game1.Scale), (int)(size * Game1.Scale));
            Texture = texture;
            Side = dir;
            Game = game;
        }

        protected void GetSource()
        {
            source = Side switch
            {
                Direction.n => new Rectangle(xOffset, yOffset, size, size),
                Direction.w => new Rectangle(xOffset, yOffset + size + 1, size, size),
                Direction.e => new Rectangle(xOffset, yOffset + 2 * (size + 1), size, size),
                Direction.s => new Rectangle(xOffset, yOffset + 3 * (size + 1), size, size),
                _ => throw new ArgumentException("Invalid direction! Failed to make " + GetType().Name)
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, source, Color.White);
        }

        public void Update() { }
    }
}