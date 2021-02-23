using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    class LeftWalkingState : IPlayerState
    {
        private IPlayer player;
        private ISprite sprite;
        public LeftWalkingState(IPlayer player)
        {
            this.player = player;
            sprite = Game1.PlayerFactory.MakeSprite("link left walking", player.Pos);
        }

        public void Stop()
        {
            player.State = new LeftIdleState(player);
        }

        public void HandleSword()
        {
            player.State = new LeftWoodSwordState(player);
        }

        public void Update()
        {
            player.Move(-1, 0);
            sprite.Location = player.Pos;
            sprite.Update();
        }

        public void Draw(SpriteBatch spritebatch)
        {
            sprite.Draw(spritebatch);
        }
    }
}