using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace sprint0
{
    class PickUpItemState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly ISprite sprite;

        private int count;
        private readonly int maxCount = 40;

        public PickUpItemState(IPlayer player)
        {
            this.player = player;
            sprite = Room.PlayerFactory.MakeSprite(LinkEnum.LinkPickUpItem, player.Pos);
            count = 0;
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