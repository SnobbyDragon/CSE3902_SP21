﻿using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    class LeftIdleState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly ISprite sprite;

        public LeftIdleState(IPlayer player)
        {
            this.player = player;
            sprite = Game1.PlayerFactory.MakeSprite("link left idle", player.Pos);
        }

        public void HandleUp()
        {
            player.Direction = Direction.n;
            player.State = new UpWalkingState(player);
        }

        public void HandleDown()
        {
            player.Direction = Direction.s;
            player.State = new DownWalkingState(player);
        }

        public void HandleLeft()
        {
            player.Direction = Direction.w;
            player.State = new LeftWalkingState(player);
        }

        public void HandleRight()
        {
            player.Direction = Direction.e;
            player.State = new RightWalkingState(player);
        }
        public void UseItem()
        {
            player.State = new LeftUseItemState(player);
        }
        public void HandleSword()
        {
            player.State = new LeftWoodSwordState(player);
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
    }
}
