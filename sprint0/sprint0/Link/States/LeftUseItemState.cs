using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace sprint0
{
    class LeftUseItemState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly ISprite sprite;

        private int count = 0;
        private readonly int maxCount = 12;

        public LeftUseItemState(IPlayer player)
        {
            this.player = player;
            sprite = Room.PlayerFactory.MakeSprite(LinkEnum.LinkLeftItem, player.Pos);
        }

        public void Update()
        {
            if (count > maxCount) player.State = new LeftIdleState(player);
            sprite.Location = new Rectangle((int)player.Pos.X, (int)player.Pos.Y, sprite.Location.Width, sprite.Location.Height);
            sprite.Update();
            count++;
        }

        public void Draw(SpriteBatch spritebatch) => sprite.Draw(spritebatch);
    }
}
