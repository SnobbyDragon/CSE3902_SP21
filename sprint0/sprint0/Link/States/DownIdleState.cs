using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace sprint0
{
    class DownIdleState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly ISprite sprite;

        public DownIdleState(IPlayer player)
        {
            this.player = player;
            sprite = Game1.PlayerFactory.MakeSprite("link down idle", player.Pos);
        }

        public void HandleUp()
        {
            player.State = new UpWalkingState(player);
        }

        public void HandleDown()
        {
            player.State = new DownWalkingState(player);
        }

        public void UseItem()
        {
            player.State = new DownUseItemState(player);
        }
        public void HandleLeft()
        {
            player.State = new LeftWalkingState(player);
        }

        public void HandleRight()
        {
            player.State = new RightWalkingState(player);
        }

        public void HandleSword()
        {
            player.State = new DownWoodSwordState(player);
        }

     

        public void Update()
        {
            sprite.Location = new Rectangle((int)player.Pos.X, (int)player.Pos.Y, sprite.Location.Width, sprite.Location.Height);
            sprite.Update();
        }

        public void Draw(SpriteBatch spritebatch)
        {
            sprite.Draw(spritebatch);
        }
    }
}
