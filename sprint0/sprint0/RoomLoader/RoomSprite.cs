using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class RoomSprite
    {
        public List<ISprite> RoomSprites { get => roomSprites; set => roomSprites = value; }
        private List<ISprite> roomSprites, roomBaseSprites;
        private readonly DungeonFactory dungeonFactory;
        public RoomSprite(Game1 game)
        {
            dungeonFactory = new DungeonFactory(game);
            roomSprites = new List<ISprite>();
            roomBaseSprites = new List<ISprite>
            {
                dungeonFactory.MakeSprite("room border", new Vector2(0, Game1.HUDHeight * Game1.Scale)),
                dungeonFactory.MakeSprite("room floor plain", new Vector2(32*Game1.Scale, Game1.HUDHeight * Game1.Scale + 32*Game1.Scale)),
            };
        }

        public void Update()
        {
            foreach (ISprite _sprite in roomSprites)
                _sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (ISprite _sprite in roomBaseSprites)
                _sprite.Draw(spriteBatch);
            foreach (ISprite _sprite in roomSprites)
                _sprite.Draw(spriteBatch);
        }
    }
}
