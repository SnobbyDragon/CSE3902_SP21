﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace sprint0
{
    class RightJumpingState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly ISprite sprite;
        private readonly int initialSpeed = -6, maxCount = 21;
        private int speed, count;

        public RightJumpingState(IPlayer player)
        {
            this.player = player;
            player.Direction = Direction.East;
            sprite = Room.PlayerFactory.MakeSprite(LinkEnum.LinkRightIdle, player.Pos);
            speed = initialSpeed;
            count = 0;
        }

        public void Update()
        {
            if (count >= maxCount) player.State = new RightIdleState(player);
            else if (count % 2 == 0) speed++;
            player.Move(0, speed);
            sprite.Location = new Rectangle((int)player.Pos.X, (int)player.Pos.Y, sprite.Location.Width, sprite.Location.Height);
            sprite.Update();
            count++;
        }

        public void Draw(SpriteBatch spritebatch) => sprite.Draw(spritebatch);
    }
}
