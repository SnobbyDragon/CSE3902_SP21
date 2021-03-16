using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Stuti Shah
//Updated: 03/15/21 by shah.1440
namespace sprint0
{
    public class Rupee : IItem
    {
        public int PickedUpDuration { get; set; }
        private readonly int maxPickedUpDuration = 40;
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private List<Rectangle> sources;
        private readonly int xOffset = 72, yOffset = 0, width = 8, height = 16;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;
        private ManageHUDInventory manageHUDInventory;

        public Rupee(Texture2D texture, Vector2 location)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            PickedUpDuration = -2;
            sources = new List<Rectangle>()
            {
                new Rectangle(xOffset, yOffset, width, height),
                new Rectangle(xOffset, yOffset + height + 1, width, height)
            };

            currFrame = 0;
            totalFrames = 2;
            repeatedFrames = 8;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (PickedUpDuration < maxPickedUpDuration)
                spriteBatch.Draw(Texture, Location, sources[currFrame / repeatedFrames], Color.White);
        }

        public void Update()
        {
            currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
            if (PickedUpDuration >= 0) PickedUpDuration++;
        }

        public void GetPopulate(ManageHUDInventory HUDInventory)
        {
            manageHUDInventory = HUDInventory;
        }
        public void Increment()
        {
            manageHUDInventory.IncrementItem(HUDItems.Rupee);
        }

        public void Decrement()
        {
            manageHUDInventory.DecrementItem(HUDItems.Rupee);
        }

        public void ChangeNum(int num)
        {
            manageHUDInventory.ChangeNum(HUDItems.Rupee, num);
        }
    }
}
