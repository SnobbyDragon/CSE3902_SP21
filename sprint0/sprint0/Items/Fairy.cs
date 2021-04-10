using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson

namespace sprint0
{
    public class Fairy : IItem
    {
        public int PickedUpDuration { get; set; }
        private readonly int maxPickedUpDuration = 40;
        public Rectangle Location { get; set; }
        public int Damage { get => int.MaxValue; }
        public Texture2D Texture { get; set; }
        private readonly List<Rectangle> sources;
        private readonly int totalFrames;
        private int currentFrame;
        private readonly int repeatedFrames;
        private readonly int xPos = 40, yPos = 0, width = 7, height = 16;
        private Vector2 destination;
        private readonly Random rand;
        private readonly Game1 game;
        public PlayerItems PlayerItems { get => PlayerItems.Fairy; }

        public Fairy(Texture2D texture, Vector2 location, Game1 game)
        {
            this.game = game;
            Texture = texture;
            PickedUpDuration = -2;
            totalFrames = 2;
            currentFrame = 0; repeatedFrames = 10;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            sources = SpritesheetHelper.GetFramesH(xPos, yPos, width, height, totalFrames);
            rand = new Random();
            GenerateDest(200);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (PickedUpDuration < maxPickedUpDuration)
                spriteBatch.Draw(Texture, Location, sources[currentFrame / repeatedFrames], Color.White);
            else
                spriteBatch.Draw(Texture, game.Room.Player.Pos + new Vector2(-8, -8), sources[currentFrame / repeatedFrames], Color.White);
            //fairy becomes small on purpose
        }

        public void Update()
        {
            currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);
            int offset = 200;
            Vector2 dist = destination - Location.Location.ToVector2();
            if (dist.Length() < 5) GenerateDest(offset);
            else
            {
                dist.Normalize();
                dist = dist.ApproxDirection().ToVector2();
                Location = new Rectangle((int)(Location.X + dist.X), (int)(Location.Y + dist.Y), Location.Width, Location.Height);
            }
            if (PickedUpDuration >= 0) PickedUpDuration++;
        }

        private void GenerateDest(int offset)
        {
            int xlowerBound = Location.X - offset;
            int ylowerBound = Location.Y - offset;
            int xupperBound = Location.X + offset;
            int yupperBound = Location.X + offset;

            if (xlowerBound < Game1.BorderThickness * Game1.Scale)
                xlowerBound = (int)(Game1.BorderThickness * Game1.Scale);
            if (xupperBound > (Game1.Width - Game1.BorderThickness) * Game1.Scale)
                xupperBound = (int)((Game1.Width - Game1.BorderThickness) * Game1.Scale);
            if (ylowerBound < (Game1.HUDHeight + Game1.BorderThickness) * Game1.Scale)
                ylowerBound = (int)((Game1.HUDHeight + Game1.BorderThickness) * Game1.Scale);
            if (yupperBound > (Game1.HUDHeight + Game1.MapHeight - Game1.BorderThickness) * Game1.Scale)
                yupperBound = (int)((Game1.HUDHeight + Game1.MapHeight - Game1.BorderThickness) * Game1.Scale);
            destination = new Vector2(
                rand.Next(xlowerBound, xupperBound),
                rand.Next(ylowerBound, yupperBound));
        }

        public void RegisterHit() { }
    }
}
