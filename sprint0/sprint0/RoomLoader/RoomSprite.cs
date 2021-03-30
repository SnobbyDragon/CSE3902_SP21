using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class RoomSprite
    {
        public List<ISprite> RoomSprites { get => roomSprites; set => roomSprites = value; }
        private List<ISprite> roomSprites;

        public RoomSprite()
        {
            roomSprites = new List<ISprite>();
        }

        public void Update()
        {
            foreach (ISprite _sprite in roomSprites)
                _sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (ISprite _sprite in roomSprites)
                _sprite.Draw(spriteBatch);
        }
    }
}
