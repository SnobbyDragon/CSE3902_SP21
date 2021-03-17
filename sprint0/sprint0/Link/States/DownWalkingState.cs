using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace sprint0
{
    class DownWalkingState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly ISprite sprite;

        public DownWalkingState(IPlayer player)
        {
            this.player = player;
            sprite = Room.PlayerFactory.MakeSprite("link down walking", player.Pos);
        }

        public void Stop()
        {
            player.State = new DownIdleState(player);
        }

        public void UseItem()
        {
            player.State = new DownUseItemState(player);
        }

        public void PickUpItem()
        {
            player.State = new PickUpItemState(player);
        }

        public void HandleSword()
        {
            player.State = new DownWoodSwordState(player);
        }

        public void Update()
        {
            player.Move(0, 1);
            sprite.Location = new Rectangle((int)player.Pos.X, (int)player.Pos.Y, sprite.Location.Width, sprite.Location.Height);
            sprite.Update();
        }

        public void Draw(SpriteBatch spritebatch)
        {
            sprite.Draw(spritebatch);
        }
    }
}