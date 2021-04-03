using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class RoomSprite
    {
        public List<ISprite> RoomSprites { get => roomSprites; set => roomSprites = value; }
        private List<ISprite> roomSprites, roomSpritesToAdd, roomSpritesToRemove;

        public RoomSprite()
        {
            roomSprites = new List<ISprite>();
            roomSpritesToAdd = new List<ISprite>();
            roomSpritesToRemove = new List<ISprite>();
        }

        private void AddNew()
        {
            if (roomSpritesToAdd.Count > 0)
            {
                roomSprites.AddRange(roomSpritesToAdd);
                roomSpritesToAdd.Clear();
            }
        }

        private void RemoveDestroyed()
        {
            foreach (ISprite sprite in roomSpritesToRemove)
                roomSprites.Remove(sprite);
            roomSpritesToRemove.Clear();
        }

        public void AddRoomSprite(ISprite sprite) => roomSpritesToAdd.Add(sprite);

        public void RemoveRoomSprite(ISprite sprite) => roomSpritesToRemove.Add(sprite);

        public void Update()
        {
            AddNew();
            foreach (ISprite _sprite in roomSprites)
                _sprite.Update();
            RemoveDestroyed();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (ISprite _sprite in roomSprites)
                _sprite.Draw(spriteBatch);
        }
    }
}
