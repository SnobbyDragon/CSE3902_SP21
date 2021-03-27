using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class RoomItems
    {
        public List<IItem> Items { get => items; set => items = value; }
        private List<IItem> items;
        public RoomItems()
        {
            items = new List<IItem>();
        }

        public void Update()
        {
            foreach (IItem item in items)
                item.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IItem item in items)
                item.Draw(spriteBatch);
        }
    }
}
