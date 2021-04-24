using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class ItemSelection : HUDItemMapping, ISprite
    {
        private List<PlayerItems> itemList;
        public Rectangle Location { get; set; }
        private Dictionary<PlayerItems, Rectangle> inventoryItems;
        private readonly int itemNum = 13, totalFrames = 2, repeatedFrames = 30;
        private int index, currentFrame = 0, pos;
        private readonly List<Rectangle> sources;
        public Texture2D Texture { get; set; }
        public ItemSelection(Game1 game)
        {
            Texture = new HUDFactory(game).Texture;
            ResetIndex();
            inventoryItems = new Dictionary<PlayerItems, Rectangle>();
            sources = new List<Rectangle> { ItemMap[PlayerItems.ItemSelectorRed], ItemMap[PlayerItems.ItemSelectorBlue] };
            itemList = new List<PlayerItems> {
                PlayerItems.MagicalBoomerang,
                PlayerItems.Boomerang,
                PlayerItems.Bomb,
                PlayerItems.Bow,
                PlayerItems.Arrow,
                PlayerItems.SilverArrow,
                PlayerItems.RedCandle,
                PlayerItems.BlueCandle,
                PlayerItems.Flute,
                PlayerItems.Food,
                PlayerItems.RedPotion,
                PlayerItems.BluePotion,
                PlayerItems.MagicalRod,
                PlayerItems.None,
            };
        }

        public void GetCurrentItem(PlayerItems item)
        {
            if (Handle()) index = itemList.IndexOf(item);
        }
        public void GetInventory(Dictionary<PlayerItems, Rectangle> items) => inventoryItems = items;
        public PlayerItems GetSelectedItem() => ItemAtIndex();
        public void Draw(SpriteBatch spriteBatch)
        {
            pos = index;
            if (index == itemList.IndexOf(PlayerItems.Bow)) pos++;
            if (Handle() && itemList[index] != PlayerItems.None)
                spriteBatch.Draw(Texture, GetRectangle(), sources[currentFrame / repeatedFrames], Color.White);
        }
        private bool Handle() => inventoryItems.Count != 0;
        private void ResetIndex() => index = itemNum;

        public void HandleLeft()
        {
            index = (index + itemNum - 1) % itemNum;
            while (Search())
                index = (index + itemNum - 1) % itemNum;
            if (index == itemList.IndexOf(PlayerItems.Arrow) && inventoryItems.ContainsKey(PlayerItems.Bow))
                HandleLeft();
            ResetColor();
        }

        public void HandleRight()
        {
            index = (index + 1) % itemNum;
            while (Search())
                index = (index + 1) % itemNum;
            if (index == itemList.IndexOf(PlayerItems.Arrow) && inventoryItems.ContainsKey(PlayerItems.Bow))
                HandleRight();
            ResetColor();
        }
        private bool Search() => !InventoryHas() && Handle();
        private void ResetColor() => currentFrame = 0;

        private PlayerItems ItemAtIndex() => itemList[index];
        private PlayerItems ItemAtIndex(int position) => itemList[position];
        private bool InventoryHas() => inventoryItems.ContainsKey(ItemAtIndex());
        private Rectangle GetRectangle()
            => new Rectangle(LocationMapping[ItemAtIndex(pos)].X, LocationMapping[ItemAtIndex(pos)].Y,
                (int)(Height * Game1.Scale), (int)(Height * Game1.Scale));
        public void Update() => currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);
    }
}