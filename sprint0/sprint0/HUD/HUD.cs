using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Stuti Shah
//Updated: 03/15/21 by shah.1440
namespace sprint0
{
    public class HUD : IHUD
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;
        private Rectangle levelSource;
        public PlayerItems Item { get; set; }
        private readonly int xOffset = 258, yOffset = 11,
            xLevelOffset = 584, yLevelOffset = 1, levelWidth = 64, levelHeight = 40,
            levelXPos = 16, levelYPos = 8;

        public HUD(Texture2D texture, Vector2 location)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, 0, 0);
            Texture = texture;
            source = new Rectangle(xOffset, yOffset, Game1.Width, Game1.HUDHeight);
            levelSource = new Rectangle(xLevelOffset, yLevelOffset, levelWidth, levelHeight);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle(Location.X, Location.Y, (int)(Game1.Width * Game1.Scale), (int)(Game1.HUDHeight * Game1.Scale)), source, Color.White);
            spriteBatch.Draw(Texture, new Rectangle((int)(levelXPos * Game1.Scale), (int)(levelYPos * Game1.Scale), (int)(levelWidth * Game1.Scale), (int)(levelHeight * Game1.Scale)), levelSource, Color.White);
        }

        public void Update() { }
        public void SetItem(PlayerItems item) { }
    }
}
