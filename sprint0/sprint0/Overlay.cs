using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Overlay
    {
        private readonly List<ISprite> sprites, spritesToRemove, spritesToAdd;
        public List<ISprite> Sprites { get => sprites; }

        public Overlay()
        {
            sprites = new List<ISprite>();
            spritesToRemove = new List<ISprite>();
            spritesToAdd = new List<ISprite>();
        }

        private void AddNew()
        {
            if (spritesToAdd.Count > 0)
            {
                sprites.AddRange(spritesToAdd);
                spritesToAdd.Clear();
            }
        }

        private void RemoveDestroyed()
        {
            foreach (ISprite sprite in spritesToRemove)
                sprites.Remove(sprite);
            spritesToRemove.Clear();
        }

        public void AddOverlay(ISprite sprite) => spritesToAdd.Add(sprite);

        public void RemoveOverlay(ISprite sprite) => spritesToRemove.Add(sprite);

        public void Update()
        {
            AddNew();
            foreach (ISprite sprite in sprites)
                sprite.Update();
            RemoveDestroyed();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (ISprite sprite in sprites)
                sprite.Draw(spriteBatch);
        }
    }
}
