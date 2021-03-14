﻿using Microsoft.Xna.Framework;
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

        public void HandleSword()
        {
            player.State = new UpWoodSwordState(player);
        }

        public void Update()
        {
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

        public void PickUpItem()
        {
            player.State = new PickUpItemState(player);
        }
    }
}
