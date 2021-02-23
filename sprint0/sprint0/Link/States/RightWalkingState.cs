using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    class RightWalkingState : IPlayerState
    {
        private IPlayer player;
        private ISprite sprite;
        public RightWalkingState(IPlayer player)
        {
            this.player = player;
            sprite = Game1.PlayerFactory.MakeSprite("link right walking", player.Pos);
        }

        public void Stop()
        {
            player.State = new RightIdleState(player);
        }
        public void HandleSword()
        {
            player.State = new RightWoodSwordState(player);
        }

        public void Update()
        {
            player.Move(1, 0);
            sprite.Location = player.Pos;
            sprite.Update();
        }

        public void Draw(SpriteBatch spritebatch)
        {
            sprite.Draw(spritebatch);
        }
    }
}