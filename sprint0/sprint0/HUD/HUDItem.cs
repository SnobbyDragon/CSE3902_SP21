using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Stuti Shah
//Updated: 04/03/21 by shah.1440
namespace sprint0
{
    public class HUDItem : HUDItemMapping, IHUD
    {

        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        public PlayerItems Item { get; set; }

        public HUDItem(Texture2D texture, Vector2 location)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, Width, Height);
            Texture = texture;
            Item = PlayerItems.None;

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (Item != PlayerItems.None && SmallItem())
                spriteBatch.Draw(Texture, new Rectangle(Location.X, Location.Y, (int)(Width * Game1.Scale), (int)(Height * Game1.Scale)), ItemMap[Item], Color.White);
            else if (Item != PlayerItems.None)
                spriteBatch.Draw(Texture, new Rectangle((Location.X - Width - 1), Location.Y, (int)(Width * 2 * Game1.Scale), (int)(Height * Game1.Scale)), ItemMap[Item], Color.White);
        }

        public void Update() { }

        public void SetAItem(PlayerItems item)
        {
            if ((ItemMap.ContainsKey(item) && IsSword(item)) || item == PlayerItems.None)
                Item = item;
        }
        public void SetItem(PlayerItems item)
        {
            if (ItemMap.ContainsKey(item) && Item == PlayerItems.None || item == PlayerItems.None)
                Item = item;
        }

        private bool SmallItem() => Item != PlayerItems.Compass && Item != PlayerItems.Raft && Item != PlayerItems.StepLadder;
        private bool IsSword(PlayerItems item) => item == PlayerItems.Sword || item == PlayerItems.MagicalSword || item == PlayerItems.WhiteSword;
    }
}
