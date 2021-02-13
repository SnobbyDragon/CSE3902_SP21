using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint0
{
    class UpWalkingState : IPlayerState
    {
        private IPlayer player;
        private ISprite sprite;
        public UpWalkingState(IPlayer player)
        {
            this.player = player;
            sprite = Game1.PlayerFactory.MakeSprite("link up walking", player.Position);
        }

        public void HandleUp()
        {
            
        }

        public void HandleDown()
        {
            throw new NotImplementedException();
        }

        public void HandleLeft()
        {
            throw new NotImplementedException();
        }

        public void HandleRight()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            player.Position += new Vector2(0, -3);
            sprite.Update();
        }

        public void Draw(SpriteBatch spritebatch)
        {
            sprite.Draw(spritebatch);
        }
    }
}
