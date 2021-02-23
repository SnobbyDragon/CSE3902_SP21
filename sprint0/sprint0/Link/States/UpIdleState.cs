using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint0
{
    class UpIdleState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly ISprite sprite;

        public UpIdleState(IPlayer player)
        {
            this.player = player;
            sprite = Game1.PlayerFactory.MakeSprite("link up idle", player.Pos);
        }

        public void HandleUp()
        {
            player.State = new UpWalkingState(player);
        }

        public void HandleDown()
        {
            player.State = new DownWalkingState(player);
        }

        public void HandleLeft()
        {
            player.State = new LeftWalkingState(player);
        }

        public void HandleRight()
        {
            player.State = new RightWalkingState(player);
        }

        public void HandleSword()
        {
            player.State = new UpWoodSwordState(player);
        }

        public void Update()
        {
            sprite.Location = player.Pos;
            sprite.Update();
        }

        public void Draw(SpriteBatch spritebatch)
        {
            sprite.Draw(spritebatch);
        }
        public void UseItem()
        {
            player.State = new UpUseItemState(player);
        }
    }
}
