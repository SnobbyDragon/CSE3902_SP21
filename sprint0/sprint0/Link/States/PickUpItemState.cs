using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace sprint0
{
    class PickUpItemState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly ISprite sprite;

        private int count;
        private readonly int maxCount = 40; // time for pick up item sprite to animate once

        public PickUpItemState(IPlayer player)
        {
            this.player = player;
            sprite = Room.PlayerFactory.MakeSprite("link pick up item", player.Pos);
            count = 0;
        }

        public void Stop()
        {
            
        }

        public void UseItem()
        {
            
        }

        public void HandleSword()
        {
            
        }

        public void Update()
        {
            if (count > maxCount)
            {
                player.State = new DownIdleState(player);
            }
            sprite.Update();
            count++;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            sprite.Draw(spritebatch);
        }
    }
}