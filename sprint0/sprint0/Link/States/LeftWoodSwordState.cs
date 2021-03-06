﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace sprint0
{
    class LeftWoodSwordState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly ISprite sprite;
        private int count = 0;

        public LeftWoodSwordState(IPlayer player)
        {
            this.player = player;
            player.Direction = Direction.West;
            sprite = Room.PlayerFactory.MakeSprite(LinkEnum.LinkLeftSword, player.Pos, player.CurrentSword);
        }

        public void Update()
        {
            if (count > 24) player.State = new LeftIdleState(player);
            sprite.Location = new Rectangle((int)player.Pos.X, (int)player.Pos.Y, sprite.Location.Width, sprite.Location.Height);
            sprite.Update();
            count++;
        }

        public void Draw(SpriteBatch spritebatch) => sprite.Draw(spritebatch);
    }
}