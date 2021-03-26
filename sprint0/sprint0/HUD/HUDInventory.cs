using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

//Author: Stuti Shah
//Updated: 03/25/21 by shah.1440
namespace sprint0
{
    public class HUDInventory : HUDItemMapping, IHUD
    {
        private readonly Dictionary<PlayerItems, Rectangle> locationMapping;
        private Dictionary<PlayerItems, Rectangle> inventoryItems;
        private readonly Rectangle currentItem;
        public Rectangle Location { get; set; }
        public PlayerItems Item { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int height = 16, smallWidth = 8, bigWidth = 16, yPosTop = 24, yPosMiddle = 48, yPosBottom = 64, currentItemX = 68, maxItems = 15;

        public HUDInventory(Game1 game)
        {
            Texture = new HUDFactory(game).Texture;
            locationMapping = new Dictionary<PlayerItems, Rectangle>
            {
                { PlayerItems.Raft, GetSource(128, yPosTop, bigWidth, height)},
                { PlayerItems.BookOfMagic, GetSource(152, yPosTop, smallWidth, height) },

                { PlayerItems.RedRing, GetSource(164, yPosTop, smallWidth, height) },

                { PlayerItems.StepLadder, GetSource(176, yPosTop, bigWidth, height) },
                { PlayerItems.MagicalKey, GetSource(196, yPosTop, smallWidth, height) },
                { PlayerItems.PowerBracelet, GetSource(208, yPosTop, smallWidth, height) },

                { PlayerItems.MagicalBoomerang, GetSource(132, yPosMiddle, smallWidth, height) },
                { PlayerItems.Boomerang, GetSource(132, yPosMiddle, smallWidth, height) },

                { PlayerItems.Bomb, GetSource(156, yPosMiddle, smallWidth, height) },
                { PlayerItems.Bow, GetSource(184, yPosMiddle, smallWidth, height) },

                { PlayerItems.Arrow, GetSource(176, yPosMiddle, smallWidth, height) },
                { PlayerItems.SilverArrow, GetSource(176, yPosMiddle, smallWidth, height) },

                { PlayerItems.RedCandle, GetSource(204, yPosMiddle, smallWidth, height) },
                { PlayerItems.BlueCandle, GetSource(204, yPosMiddle, smallWidth, height) },

                { PlayerItems.Flute, GetSource(132, yPosBottom, smallWidth, height) },
                { PlayerItems.Food, GetSource(157, yPosBottom, smallWidth, height) },

                { PlayerItems.RedPotion, GetSource(180, yPosBottom, smallWidth, height) },
                { PlayerItems.BluePotion, GetSource(180, yPosBottom, smallWidth, height) },

                { PlayerItems.MagicalRod, GetSource(204, yPosBottom, smallWidth, height) },

            };
            inventoryItems = new Dictionary<PlayerItems, Rectangle>();
            currentItem = GetSource(currentItemX, yPosMiddle, smallWidth, height);
        }

        private Rectangle GetSource(int xPos, int yPos, int width, int height)
        {
            source = new Rectangle((int)(xPos * Game1.Scale), (int)((yPos + Game1.HUDHeight) * Game1.Scale), (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            return source;
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            if (inventoryItems.Count != 0)
            {
                foreach (KeyValuePair<PlayerItems, Rectangle> hudElement in inventoryItems)
                    if (locationMapping.ContainsKey(hudElement.Key))
                        spriteBatch.Draw(Texture, hudElement.Value, ItemMap[hudElement.Key], Color.White);
                spriteBatch.Draw(Texture, currentItem, ItemMap[Item], Color.White);
            }
        }

        public void SetItem(PlayerItems item)
        {
            Item = item;
        }

        public void AddItem(PlayerItems newItem)
        {
            ToSwitch(newItem);
            if (!inventoryItems.ContainsKey(newItem) && locationMapping.ContainsKey(newItem) && inventoryItems.Count <= maxItems)
                inventoryItems.Add(newItem, locationMapping[newItem]);
        }

        public void Update()
        {
        }

        private void ToSwitch(PlayerItems item)
        {
            switch (item)
            {
                case PlayerItems.BluePotion:
                    {
                        if (inventoryItems.ContainsKey(item)) inventoryItems.Remove(PlayerItems.RedPotion);
                        break;
                    }
                case PlayerItems.RedPotion:
                    {
                        if (inventoryItems.ContainsKey(item)) inventoryItems.Remove(PlayerItems.BluePotion);
                        break;
                    }

                case PlayerItems.BlueCandle:
                    {
                        if (inventoryItems.ContainsKey(item)) inventoryItems.Remove(PlayerItems.RedCandle);
                        break;
                    }
                case PlayerItems.RedCandle:
                    {
                        if (inventoryItems.ContainsKey(item)) inventoryItems.Remove(PlayerItems.BlueCandle);
                        break;
                    }

                case PlayerItems.MagicalBoomerang:
                    {
                        if (inventoryItems.ContainsKey(item)) inventoryItems.Remove(PlayerItems.Boomerang);
                        break;
                    }
                case PlayerItems.Boomerang:
                    {
                        if (inventoryItems.ContainsKey(item)) inventoryItems.Remove(PlayerItems.MagicalBoomerang);
                        break;
                    }

                case PlayerItems.SilverArrow:
                    {
                        if (inventoryItems.ContainsKey(item)) inventoryItems.Remove(PlayerItems.Arrow);
                        break;
                    }
                case PlayerItems.Arrow:
                    {
                        if (inventoryItems.ContainsKey(item)) inventoryItems.Remove(PlayerItems.SilverArrow);
                        break;
                    }
                default: break;

            }
        }
    }
}