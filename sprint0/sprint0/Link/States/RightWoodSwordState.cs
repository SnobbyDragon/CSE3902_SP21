﻿using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    internal class RightWoodSwordState : IPlayerState
    {
        private IPlayer player;
        private ISprite sprite;
        private int count = 0;
        public RightWoodSwordState(IPlayer player)
        {
            this.player = player;
            sprite = Game1.PlayerFactory.MakeSprite("link right sword", player.Position);
        }

        public void HandleSword()
        {
            player.State = new RightWoodSwordState(player);
        }

        public void Update()
        {
            if (count > 24)
            {
                player.State = new RightIdleState(player);
            }
            sprite.Location = player.Position;
            sprite.Update();
            count++;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            sprite.Draw(spritebatch);
        }
    }
}