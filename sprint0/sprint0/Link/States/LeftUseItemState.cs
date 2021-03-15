using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace sprint0
{
    class LeftUseItemState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly ISprite sprite;

        private int count = 0;
        private readonly int maxCount = 12; // animation time for use item

        public LeftUseItemState(IPlayer player)
        {
            this.player = player;
            sprite = Room.PlayerFactory.MakeSprite("link left item", player.Pos);
        }

        public void Update()
        {
            if (count > maxCount)
            {
                player.State = new LeftIdleState(player);
            }
            sprite.Location = new Rectangle((int)player.Pos.X, (int)player.Pos.Y, sprite.Location.Width, sprite.Location.Height);
            sprite.Update();
            count++;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            sprite.Draw(spritebatch);
        }
    }
}
