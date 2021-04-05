using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace sprint0
{
    class RightWoodSwordState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly ISprite sprite;
        private int count = 0;

        public RightWoodSwordState(IPlayer player)
        {
            this.player = player;
            sprite = Room.PlayerFactory.MakeSprite(LinkEnum.LinkRightSword, player.Pos);
        }

        public void Update()
        {
            if (count > 24)
            {
                player.State = new RightIdleState(player);
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