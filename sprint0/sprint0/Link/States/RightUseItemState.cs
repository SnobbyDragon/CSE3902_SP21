using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace sprint0
{
    class RightUseItemState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly ISprite sprite;
        private int count = 0;

        public RightUseItemState(IPlayer player)
        {
            this.player = player;
            player.Direction = Direction.East;
            sprite = Room.PlayerFactory.MakeSprite(LinkEnum.LinkRightItem, player.Pos);
        }

        public void Update()
        {
            if (count > 12) player.State = new RightIdleState(player);
            sprite.Location = new Rectangle((int)player.Pos.X, (int)player.Pos.Y, sprite.Location.Width, sprite.Location.Height);
            sprite.Update();
            count++;
        }

        public void Draw(SpriteBatch spritebatch) => sprite.Draw(spritebatch);
    }
}
