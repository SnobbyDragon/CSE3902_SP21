﻿using Microsoft.Xna.Framework;
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

        public void Stop()
        {
            player.State = new UpIdleState(player);
        }

        public void HandleUp()
        {
            player.Move(0, -1);
        }

        public void Update()
        {
            sprite.Location = player.Position;
            sprite.Update();
        }

        public void Draw(SpriteBatch spritebatch)
        {
            sprite.Draw(spritebatch);
        }
    }
}