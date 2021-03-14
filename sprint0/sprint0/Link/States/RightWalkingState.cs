using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace sprint0
{
    class RightWalkingState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly ISprite sprite;
        public RightWalkingState(IPlayer player)
        {
            this.player = player;
            sprite = Game1.PlayerFactory.MakeSprite("link right walking", player.Pos);
        }

        public void Stop()
        {
            player.State = new RightIdleState(player);
        }

        public void PickUpItem()
        {
            player.State = new PickUpItemState(player);
        }

        public void HandleSword()
        {
            player.State = new RightWoodSwordState(player);
        }

        public void Update()
        {
            player.Move(1, 0);
            sprite.Location = new Rectangle((int)player.Pos.X, (int)player.Pos.Y, sprite.Location.Width, sprite.Location.Height);
            sprite.Update();
        }

        public void UseItem()
        {
            player.State = new RightUseItemState(player);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            sprite.Draw(spritebatch);
        }
    }
}