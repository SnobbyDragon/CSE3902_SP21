using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    class DownWalkingState : IPlayerState
    {
        private IPlayer player;
        private ISprite sprite;
        public DownWalkingState(IPlayer player)
        {
            this.player = player;
            sprite = Game1.PlayerFactory.MakeSprite("link down walking", player.Pos);
        }

        public void Stop()
        {
            player.State = new DownIdleState(player);
        }

        public void HandleDown()
        {
            player.Move(0, 1);
        }

        public void HandleSword()
        {
            player.State = new DownWoodSwordState(player);
        }

        public void Update()
        {
            sprite.Location = player.Pos;
            sprite.Update();
        }

        public void Draw(SpriteBatch spritebatch)
        {
            sprite.Location = player.Pos;
            sprite.Draw(spritebatch);
        }
    }
}