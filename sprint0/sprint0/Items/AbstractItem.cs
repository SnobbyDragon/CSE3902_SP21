using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

//Author: Stuti Shah
namespace sprint0
{
    public abstract class AbstractItem : IItem
    {
        public PlayerItems PlayerItems { get => PlayerItems.None; }
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        public int PickedUpDuration { get; set; }
        protected int width, height;
        protected Rectangle source;
        protected readonly int maxPickedUpDuration = 40;
        public AbstractItem() { }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (PickedUpDuration < maxPickedUpDuration)
                spriteBatch.Draw(Texture, Location, source, Color.White);
        }

        public virtual void Update()
        {
            if (PickedUpDuration >= 0) PickedUpDuration++;
        }
    }
}
