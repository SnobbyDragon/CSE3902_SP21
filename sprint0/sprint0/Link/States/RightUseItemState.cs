using Microsoft.Xna.Framework.Graphics;

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
            sprite = Game1.PlayerFactory.MakeSprite("link right item", player.Pos);
        }

        public void Update()
        {
            if (count > 12)
            {
                player.State = new RightIdleState(player);
            }
            sprite.Location = player.Pos;
            sprite.Update();
            count++;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            sprite.Draw(spritebatch);
        }
    }
}
