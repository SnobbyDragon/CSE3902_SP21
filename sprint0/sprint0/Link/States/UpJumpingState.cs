﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace sprint0
{
    class UpJumpingState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly ISprite sprite;
        private readonly int initialSpeed = -6, maxCount = 21;
        private int speed, count;

        public UpJumpingState(IPlayer player)
        {
            this.player = player;
            sprite = Room.PlayerFactory.MakeSprite(LinkEnum.LinkUpIdle, player.Pos);
            speed = initialSpeed;
            count = 0;
        }

        public void Update()
        {
            if (count >= maxCount) player.State = new UpIdleState(player);
            else if (count % 2 == 0) speed++;
            player.Move(0, speed);
            sprite.Location = new Rectangle((int)player.Pos.X, (int)player.Pos.Y, sprite.Location.Width, sprite.Location.Height);
            sprite.Update();
            count++;
        }

        public void Draw(SpriteBatch spritebatch) => sprite.Draw(spritebatch);
    }
}
