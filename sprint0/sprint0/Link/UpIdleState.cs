using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint0
{
    class UpIdleState : IPlayerState
    {
        private IPlayer player;
        private ISprite sprite;

        public UpIdleState(IPlayer player)
        {
            this.player = player;
            sprite = Game1.PlayerFactory.MakeSprite("link up idle", player.Position);
        }

        public void HandleUp()
        {
            player.State = new UpWalkingState(player);
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
            // Idle no-op
        }

        public void Draw(SpriteBatch spritebatch)
        {
            sprite.Draw(spritebatch);
        }
    }
}
