using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
//Updated: 03/15/21 by shah.1440
namespace sprint0
{
    class BombItem : IItem
    {
        public int PickedUpDuration { get; set; }
        public Rectangle Location { get; set; }
        private Texture2D texture;
        private int width, height;
        private Rectangle source;
        private ManageHUDInventory manageHUDInventory;

        public BombItem(Texture2D texture, Vector2 location)
        {
            this.texture = texture;
            width = 8;
            height = 14;
            PickedUpDuration = -2;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            source = new Rectangle(136, 0, width, height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Location, source, Color.White);
        }

        public void Update()
        {
            //no-op
        }
        public void GetPopulate(ManageHUDInventory HUDInventory)
        {
            manageHUDInventory = HUDInventory;
        }
        public void Increment()
        {
            manageHUDInventory.IncrementItem(HUDItems.Bomb);
        }

        public void Decrement()
        {
            manageHUDInventory.DecrementItem(HUDItems.Bomb);
        }

        public void ChangeNum(int num)
        {
            manageHUDInventory.ChangeNum(HUDItems.Bomb, num);
        }
    }
}
