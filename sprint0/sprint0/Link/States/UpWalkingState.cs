using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint0
{
    class UpWalkingState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly ISprite sprite;

        public UpWalkingState(IPlayer player)
        {
            this.player = player;
            sprite = Room.PlayerFactory.MakeSprite(LinkEnum.LinkUpWalking, player.Pos);
        }

        public void Stop()
        {
            player.State = new UpIdleState(player);
        }

        public void PickUpItem()
        {
            player.State = new PickUpItemState(player);
        }

        public void HandleSword()
        {
            player.State = new UpWoodSwordState(player);
        }

        public void Update()
        {
            player.Move(0, -1);
            sprite.Location = new Rectangle((int)player.Pos.X, (int)player.Pos.Y, sprite.Location.Width, sprite.Location.Height);
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
