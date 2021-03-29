using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace sprint0
{
    public class RoomMisc
    {
        public List<ISprite> RoomMiscs { get ; set; }
        private readonly MiscSpriteFactory miscFactory;
        public RoomMisc(Game1 game)
        {
            miscFactory = new MiscSpriteFactory(game);
            RoomMiscs = new List<ISprite>();
        }

        public void AddMisc(Vector2 location, string sprite)
            => RoomMiscs.Add(miscFactory.MakeSprite(sprite, location));

        public void AddMisc(ISprite misc) => RoomMiscs.Add(misc);

        public void Update()
        {
            foreach (ISprite _sprite in RoomMiscs)
                _sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (ISprite _sprite in RoomMiscs)
                _sprite.Draw(spriteBatch);
        }
    }
}
